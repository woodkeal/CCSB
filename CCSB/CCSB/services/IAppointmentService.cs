using CCSB.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CCSB.services
{
    public interface IAppointmentService
    {
        public List<AdminViewModel> GetAdminList();
        public List<UserViewModel> GetUserList(); 

    }
}
