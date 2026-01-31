using GymManagmentDAL.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagmentDAL.Data.DataSeeding
{
    public static class IdentityDbContextSeeding
    {
        public static bool SeedData(RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager)
        {
            try
            {
                var HasUser = userManager.Users.Any();
                var HasRole = roleManager.Roles.Any();
                if (HasRole && HasUser)
                    return false;

                if (!HasRole)
                {
                    var Roles = new List<IdentityRole>()
                    {
                        new () { Name="SuperAdmin" },
                        new () { Name="Admin" }
                    };
                    foreach (var role in Roles)
                    {
                        if (!roleManager.RoleExistsAsync(role.Name!).Result)
                        {
                            roleManager.CreateAsync(role).Wait();
                        }
                    }
                }

                if (!HasUser)
                {
                    var MainAdmin = new ApplicationUser()
                    {
                        FirstName="Abdulrahman",
                        LastName="Ahmed",
                        UserName="AbdoAhmed",
                        Email="abdo144418@gmail.com",
                        PhoneNumber="01143685049"
                    };
                    userManager.CreateAsync(MainAdmin, "Abdo1444#18").Wait();
                    userManager.AddToRoleAsync(MainAdmin, "SuperAdmin").Wait();
                    
                    var Admin = new ApplicationUser()
                    {
                        FirstName="Hani",
                        LastName="Eldaramali",
                        UserName="HaniEl",
                        Email="hani99el@gmail.com",
                        PhoneNumber="01143680044"
                    };
                    userManager.CreateAsync(Admin, "Hani99#el").Wait();
                    userManager.AddToRoleAsync(Admin, "Admin").Wait();
                }

                return true;
            }
            catch (Exception ex) 
            {
                Console.WriteLine($"Seed Failed: {ex}");
                return false;
            }
        }
    }
}
