using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CCSB.Models.ViewModels
{
    public class AppointmentViewModel
    {
        public int? Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string AppointmentDate { get; set; }
        public string AdminId { get; set; }
        public string UserId { get; set; } 
        public string AdminName { get; set; }
        public string UserName { get; set; }
        public bool IsForClient { get; set; }

    }
}
