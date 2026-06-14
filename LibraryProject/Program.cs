
using LibraryProject.Data;
using LibraryProject.Interface.LibraryInterface;
using LibraryProject.Interface.TokenInterface;
using LibraryProject.Repository;
using LibraryProject.Service;
using Microsoft.EntityFrameworkCore;

namespace LibraryProject
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDbContext<AppDbContext>(op => op.UseSqlServer(builder.Configuration.GetConnectionString("MyConn")));
            //builder.Services.AddIdentity<>();
            builder.Services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();
            builder.Services.AddScoped<ILibraryRepository,LibraryRepository>();
            builder.Services.AddScoped<ILibraryService,LibraryService>();
            builder.Services.AddScoped<IToken,TokenService>();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
            }

            app.UseHttpsRedirection();


            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
