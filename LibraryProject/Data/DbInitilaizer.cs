using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace LibraryProject.Data
{
    public class DbInitilaizer
    {
        public static async Task SeedRolesAsync(RoleManager<IdentityRole>roleManager)
        {
            string[] roles = {"User","LibraryOwner" };
            foreach (var role in roles)
            {
                if(await roleManager.RoleExistsAsync(role))
                {
                    await roleManager.CreateAsync(new IdentityRole(role));
                }
            }
        }
    }
}
