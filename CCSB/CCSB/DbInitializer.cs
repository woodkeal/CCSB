using CCSB.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
 
 
namespace CCSB.DatabaseInitializer
{
    public class DbInitializer : IDbInitializer
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public DbInitializer(ApplicationDbContext db,
        UserManager<ApplicationUser> userManager,
        RoleManager<IdentityRole> roleManager)
        {
            _db = db;
            _userManager = userManager;
            _roleManager = roleManager;

        }
        public void Initialize()
        {
            try
            {
                if (_db.Database.GetPendingMigrations().Count() > 0)
                {
                    _db.Database.Migrate();
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
            }
            if (_db.Roles.Any())
            {
                return;
            }
            else
            {
                _roleManager.CreateAsync(new IdentityRole() { Name = "Admin" }).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole() { Name = "User" }).GetAwaiter().GetResult();
                ApplicationUser user = new ApplicationUser();

                //Creeert Admin
                user.UserName = "Timhoutman1999@gmail.com";
                user.Email = "Timhoutman1999@gmail.com";
                user.EmailConfirmed = true;
                user.FirstName = "Tim";
                user.MiddleName = "";
                user.LastName = "Houtman";
                _userManager.CreateAsync(user, "qpwoeiQ1!").GetAwaiter().GetResult();
                _userManager.AddToRoleAsync(user, "Admin").GetAwaiter().GetResult();

                ApplicationUser user1 = new ApplicationUser();
                // Creeert User
                user1.UserName = "j.van.gaalen@gmail.com";
                user1.Email = "j.van.gaalen@gmail.com";
                user1.EmailConfirmed = true;
                user1.FirstName = "Jan";
                user1.MiddleName = "van";
                user1.LastName = "Gaalen";
                _userManager.CreateAsync(user1, "qpwoeiQ1!").GetAwaiter().GetResult();
                _userManager.AddToRoleAsync(user1, "User").GetAwaiter().GetResult();

                ApplicationUser user2 = new ApplicationUser();
                // Creeert User
                user2.UserName = "henk.hoofd@gmail.com";
                user2.Email = "henk.hoofd@gmail.com";
                user2.EmailConfirmed = true;
                user2.FirstName = "Henk";
                user2.MiddleName = "";
                user2.LastName = "Hoofd";
                _userManager.CreateAsync(user2, "qpwoeiQ1!").GetAwaiter().GetResult();
                _userManager.AddToRoleAsync(user2, "User").GetAwaiter().GetResult();
            }
        }
    }
}


