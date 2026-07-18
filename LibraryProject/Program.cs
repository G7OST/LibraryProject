
using LibraryProject.Data;
using LibraryProject.Interface.BookInterface;
using LibraryProject.Interface.LibraryInterface;
using LibraryProject.Interface.SectionInterface;
using LibraryProject.Interface.TokenInterface;
using LibraryProject.Models;
using LibraryProject.Repository;
using LibraryProject.Service;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace LibraryProject
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDbContext<AppDbContext>(op => op.UseSqlServer(builder.Configuration.GetConnectionString("MyConn")));
            builder.Services.AddIdentity<Appuser, IdentityRole>().AddEntityFrameworkStores<AppDbContext>();
            builder.Services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddSwaggerGen();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddScoped<ILibraryRepository, LibraryRepository>();
            builder.Services.AddScoped<ILibraryService, LibraryService>();
            builder.Services.AddScoped<IToken, TokenService>();
            builder.Services.AddScoped<ISectionRepository, SectionRepository>();
            builder.Services.AddScoped<ISectionService, SectionService>();
            builder.Services.AddScoped<IBookRepository, BookRepository>();
            var app = builder.Build();
            using (var scope = app.Services.CreateScope())
            {
                var rolemaneger = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                await DbInitilaizer.SeedRolesAsync(rolemaneger);
            }
            

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
