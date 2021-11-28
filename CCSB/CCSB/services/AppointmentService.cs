using CCSB.Models;
using CCSB.Models.ViewModels;
using CCSB.Utility;
using Microsoft.AspNetCore.Identity.UI.Services;
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
        private readonly IEmailSender _emailSender;

        public AppointmentService(ApplicationDbContext db, IEmailSender emailSender)
        {
            _db = db;
            _emailSender = emailSender;
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
        //adds an appointment
        public async Task<int> AddUpdate(AppointmentViewModel model)
        {
            var appointmentDate = DateTime.Parse(model.AppointmentDate, CultureInfo.CreateSpecificCulture("nl-NL"));
            if (model != null & model.Id > 0)
            {
                //gives succescode
                return 1;
            }
            else
            {
                Appointment appointment = new Appointment()
                {
                    Title = model.Title,
                    Description = model.Description,
                    AppointmentDate = appointmentDate,
                    ApplicationUserId = model.ApplicationUserId,
                };
                //sends email to the logged in user if appointment is made.

                //TODO: Fix ApplicationUserId being NULL 
               /* var email = _db.Users.FirstOrDefault(u=>u.Id == model.ApplicationUserId).Email;
                await _emailSender.SendEmailAsync(email, "Groetjes!",
                    $"Er is een afspraak voor u ingepland!");*/
                _db.Appointments.Add(appointment);
                await _db.SaveChangesAsync();
                return 2;
            }
        }
        //gets the appointments of users
        public List<AppointmentViewModel> UserAppointments(string userid)
        {
            return _db.Appointments.Where(a => a.ApplicationUserId == userid).ToList().Select(
                c => new AppointmentViewModel()
                {
                    Id = c.Id,
                    Description = c.Description,
                    AppointmentDate = c.AppointmentDate.ToString("yyyy-MM-dd HH:mm"),
                    Title = c.Title,
                }).ToList();
        }
        //gets the appointments of all the users for admin.
        public List<AppointmentViewModel> AllAppointments()
        {
            return _db.Appointments.ToList().Select(
                c => new AppointmentViewModel()
                {
                    Id = c.Id,
                    Description = c.Description,
                    AppointmentDate = c.AppointmentDate.ToString("yyyy-MM-dd HH:mm"),
                    Title = c.Title,
                }).ToList();
        }
        //gets specific appointments by the ID 
        public AppointmentViewModel GetById(int id)
        {
            return _db.Appointments.Where(a => a.Id == id).ToList().Select(
                c => new AppointmentViewModel()
                {
                    Id = c.Id,
                    Description = c.Description,
                    AppointmentDate = c.AppointmentDate.ToString("d-MM-yyyy HH:mm"),
                    Title = c.Title,
                    ApplicationUserId = c.ApplicationUserId,
                    UserName = _db.Users.Where(u => u.Id == c.ApplicationUserId).Select(u => u.FullName).FirstOrDefault(),
                }).SingleOrDefault();
        }

        //TODO: Delete, update and read appointments. CRUD
    }
}
