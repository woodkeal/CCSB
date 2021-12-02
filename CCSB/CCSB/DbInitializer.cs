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
                Admin1.UserName = "Admin";
                Admin1.Email = "camperencarvanstalling@gmail.com";
                Admin1.EmailConfirmed = true;
                Admin1.FirstName = "Carlo";
                Admin1.MiddleName = "";
                Admin1.LastName = "van der Stal";
                _userManager.CreateAsync(Admin1, "qpwoeiQ1!").GetAwaiter().GetResult();
                _userManager.AddToRoleAsync(Admin1, "Admin").GetAwaiter().GetResult();

            }
        }
    }
}


