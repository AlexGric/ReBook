using Domain.Models;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace DataAccess.Context
{
    public class IdentityInitializer
    {
        private readonly UserManager<User> userManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public IdentityInitializer(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
        }
        public async Task SeedAsync()
        {
            var login = "admin@mail.ru";
            var pass = "qwerty";

            if ((await userManager.FindByEmailAsync(login)) == null)
            {
                var user = new User() { UserName = login, Email = login };
                var saveuser = await userManager.CreateAsync(user, pass);
                if (saveuser.Succeeded)
                {
                    if ((await roleManager.FindByNameAsync("admin")) == null)
                    {
                        var saverole = await roleManager.CreateAsync(new IdentityRole("admin"));
                        if (saverole.Succeeded)
                        {
                            await userManager.AddToRoleAsync(user, "admin");
                        }
                    }
                }

            }
        }
    }
}
