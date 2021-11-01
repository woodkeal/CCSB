using CCSB.Models;
using CCSB.Models.ViewModels;
using CCSB.Utility;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace CCSB.Services
{
    public class AppointmentService : IAppointmentService
    {

        private readonly ApplicationDbContext _db;

        public AppointmentService(ApplicationDbContext db)
        {
            _db = db;
        }

        public List<AdminViewModel> GetAdminList()
        {
            var Admins = (from user in _db.Users
                         join userRole in _db.UserRoles on user.Id equals userRole.UserId
                         join role in _db.Roles.Where(x => x.Name == Helper.Admin) on userRole.RoleId equals role.Id
                         select new AdminViewModel
                         {
                             Id = user.Id,
                             Name = string.IsNullOrEmpty(user.MiddleName) ?
                             user.FirstName + " " + user.LastName :
                             user.FirstName + " " + user.MiddleName + " " + user.LastName
                         }
                         ).OrderBy(u => u.Name).ToList();
            return Admins;
        }

        public List<UserViewModel> GetUserList()
        {
            var Users = (from user in _db.Users
                         join userRole in _db.UserRoles on user.Id equals userRole.UserId
                         join role in _db.Roles.Where(x => x.Name == Helper.User) on userRole.RoleId equals role.Id
                         select new UserViewModel
                         {
                             Id = user.Id,
                             Name = string.IsNullOrEmpty(user.MiddleName) ?
                             user.FirstName + " " + user.LastName :
                             user.FirstName + " " + user.MiddleName + " " + user.LastName
                         }
              ).OrderBy(u => u.Name).ToList();
            return Users;
        }
        public async Task<int> AddUpdate(AppointmentViewModel model)
        {
            var appointmentDate = DateTime.Parse(model.AppointmentDate, CultureInfo.CreateSpecificCulture("en-US")); //parse doesnt work. Convert.ToDateTime is a temporary fix

            if (model != null & model.Id > 0)
            {
                return 1;
            }
            else
            {
                Appointment appointment = new Appointment()
                {
                    Title = model.Title,
                    Description = model.Description,
                    AppointmentDate = appointmentDate,
                    AdminId = model.AdminId,
                    UserId = model.UserId,
                };
                _db.Appointments.Add(appointment);
                await _db.SaveChangesAsync();
                return 2;
            }
        }

    }
}
