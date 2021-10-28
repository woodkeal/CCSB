using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CCSB.Models
{
    public class Appointment
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string AdminId { get; set; }
        public string UserId { get; set; }

    }
}
