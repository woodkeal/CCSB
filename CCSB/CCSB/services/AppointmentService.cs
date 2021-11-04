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
            var appointmentDate = DateTime.Parse(model.AppointmentDate, CultureInfo.CreateSpecificCulture("en-US"));

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
                    UserId = model.UserId,
                };
                _db.Appointments.Add(appointment);
                await _db.SaveChangesAsync();
                return 2;
            }
        }
        public List<AppointmentViewModel> UserAppointments(string userid)
        {
            return _db.Appointments.Where(a => a.UserId == userid).ToList().Select(
                c => new AppointmentViewModel()
                {
                    Id = c.Id,
                    Description = c.Description,
                    AppointmentDate = c.AppointmentDate.ToString("yyyy-MM-dd HH:mm:ss"),
                    Title = c.Title,
                }).ToList();
        }
        public AppointmentViewModel GetById(int id)
        {
            return _db.Appointments.Where(a => a.Id == id).ToList().Select(
                c => new AppointmentViewModel()
                {
                    Id = c.Id,
                    Description = c.Description,
                    AppointmentDate = c.AppointmentDate.ToString("d-MM-yyyy HH:mm"),
                    Title = c.Title,
                    UserId = c.UserId,
                    UserName = _db.Users.Where(u => u.Id == c.UserId).Select(u => u.FullName).FirstOrDefault(),

                }).SingleOrDefault();
        }
    }
}
