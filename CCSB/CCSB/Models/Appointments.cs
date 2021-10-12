using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CCSB.Models
{
    public class Appointments
    {
        [Key]
        public int Invoice { get; set; }
        public int Contract { get; set; } 
        public DateTime Date { get; set; }

    }
}
