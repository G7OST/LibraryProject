using LibraryProject.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;

namespace LibraryProject.Data
{
    public  class AppDbContext:IdentityDbContext<Appuser>
    {
        public  AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
       public DbSet<Library>Library {  get; set; }
       public DbSet<Section> Section { get; set; }
        public DbSet<Book> Book { get; set; }

    }
}
