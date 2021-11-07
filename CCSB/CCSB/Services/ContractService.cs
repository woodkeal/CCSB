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
    public class ContractService : IContractService
    {

        private readonly ApplicationDbContext _db;

        public DateTime DatumVan { get; set; }

        public ContractService(ApplicationDbContext db)
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
        public async Task<int> AddUpdate(Contract model)
        {
            var startDate = Convert.ToDateTime(model.DatumVan, CultureInfo.CreateSpecificCulture("en-US")); //parse doesnt work. Convert.ToDateTime is a temporary fix.
            var endDate = startDate.AddMinutes(Convert.ToDouble(model.Duration));

            if (model != null & model.Id > 0)
            {
                return 1;
            }
            else
            {
                Contract Contracts = new Contract()
                {
                    Title = model.Title,
                    Description = model.Description,
                    DatumVan = DatumVan,
                    DatumTot = endDate,
                    Duration = model.Duration,
                    AdminId = model.AdminId,
                    UserId = model.UserId,
                };
                _db.Contracts.Add(Contracts);
                await _db.SaveChangesAsync();
                return 2;
            }
        }

    }
}
