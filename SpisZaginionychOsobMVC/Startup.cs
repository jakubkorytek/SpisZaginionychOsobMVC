using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using SpisZaginionychOsobMVC.Models;
using System.Linq;

[assembly: OwinStartupAttribute(typeof(SpisZaginionychOsobMVC.Startup))]

namespace SpisZaginionychOsobMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            InitializeRolesAndAdmin();
        }

        private void InitializeRolesAndAdmin()
        {
            ApplicationDbContext context = new ApplicationDbContext();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            void CreateRoles(params string[] names)
            {
                foreach (var name in names)
                {
                    if (!roleManager.RoleExists(name))
                    {
                        var role = new IdentityRole
                        {
                            Name = name
                        };
                        roleManager.Create(role);
                    }
                }
            }

            CreateRoles("Admin", "Editor", "Banned");

            var adminEmail = "admin@admin.com";
            string password = "Admin123$";



            if (userManager.Users.Count(x => x.Email == adminEmail) == 0)
            {
                var user = new ApplicationUser
                {
                    UserName = "Admin",
                    Email = adminEmail,
                    EmailConfirmed = true
                };

                var chkUser = userManager.Create(user, password);

                if (chkUser.Succeeded)
                {
                    var result1 = userManager.AddToRole(user.Id, "Admin");
                }
            }
        }
    }
}