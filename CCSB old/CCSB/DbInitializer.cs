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

                //Creeert Admin
                ApplicationUser Admin1 = new ApplicationUser();
                Admin1.UserName = "Timhoutman1999@gmail.com";
                Admin1.Email = "Timhoutman1999@gmail.com";
                Admin1.EmailConfirmed = true;
                Admin1.FirstName = "Tim";
                Admin1.MiddleName = "";
                Admin1.LastName = "Houtman";
                _userManager.CreateAsync(Admin1, "qpwoeiQ1!").GetAwaiter().GetResult();
                _userManager.AddToRoleAsync(Admin1, "Admin").GetAwaiter().GetResult();

                //Creeert Admin
                ApplicationUser Admin2 = new ApplicationUser(); 
                Admin2.UserName = "emiel.vreemann29@gmail.com";
                Admin2.Email = "emiel.vreemann29@gmail.com";
                Admin2.EmailConfirmed = true;
                Admin2.FirstName = "Emiel";
                Admin2.MiddleName = "";
                Admin2.LastName = "Vreemann";
               _userManager.CreateAsync(Admin2, "Banaan127!").GetAwaiter().GetResult();
               _userManager.AddToRoleAsync(Admin2, "Admin").GetAwaiter().GetResult();

                //Creeert Admin
                ApplicationUser Admin4 = new ApplicationUser();
                Admin4.UserName = "Gtrouerbach@icloud.com";
                Admin4.Email = "Gtrouerbach@icloud.com";
                Admin4.EmailConfirmed = true;
                Admin4.FirstName = "Giovanni";
                Admin4.MiddleName = "";
                Admin4.LastName = "Trouerbach";
                _userManager.CreateAsync(Admin4, "qpwoeiQ1!").GetAwaiter().GetResult();
                _userManager.AddToRoleAsync(Admin4, "Admin").GetAwaiter().GetResult();

                // Creeert User
                ApplicationUser user1 = new ApplicationUser();
                user1.UserName = "j.van.gaalen@gmail.com";
                user1.Email = "j.van.gaalen@gmail.com";
                user1.EmailConfirmed = true;
                user1.FirstName = "Jan";
                user1.MiddleName = "van";
                user1.LastName = "Gaalen";
                _userManager.CreateAsync(user1, "qpwoeiQ1!").GetAwaiter().GetResult();
                _userManager.AddToRoleAsync(user1, "User").GetAwaiter().GetResult();

                // Creeert User
                ApplicationUser user2 = new ApplicationUser();
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


