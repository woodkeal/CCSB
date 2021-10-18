using CCSB.Models.ViewModels;
using CCSB.Utility;
using System.Collections.Generic;
using System.Linq;
using CCSB.Models;


namespace CCSB.services
{
    public class AppointmentService : IAppointmentService
    {
        public List<AdminViewModel> GetAdminList()
        {
            var admins = (from user in _db.Users
                         join userRole in _db.UserRoles on user.Id equals userRole.UserId
                         join role in _db.Roles.Where(x => x.Name == Helper.Admin) on userRole.RoleId equals role.Id
                         select new AdminViewModel
                         {
                             Id = user.Id,
                             Name = string.IsNullOrEmpty(user.MiddleName) ?
                             user.FirstName + " " + user.Lastname :
                             user.FirstName + " " + user.MiddleName + " " + user.Lastname
                         }
                         ).OrderBy(u => u.Name).ToList();
            return admins;
        }

        public List<UserViewModel> GetUserList()
        {
            var Users = (from user in _db.Users
                         join userRole in _db.UserRoles on user.Id equals userRole.UserId
                         join role in _db.Roles.Where(x => x.Name == Helper.User) on userRole.RoleId equals role.Id
                         select new AdminViewModel
                         {
                             Id = user.Id,
                             Name = string.IsNullOrEmpty(user.MiddleName) ?
                             user.FirstName + " " + user.Lastname :
                             user.FirstName + " " + user.MiddleName + " " + user.Lastname
                         }
              ).OrderBy(u => u.Name).ToList();
            return Users;
        }
    }
}
