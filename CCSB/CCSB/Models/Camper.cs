using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CCSB.Models
{
    public partial class Camper
    {
        public int? Pk { get; set; }
        public bool? TowBar { get; set; }
        public string LicensePlate { get; set; }
        public virtual Vehicles LicensePlateNavigation { get; set; }
    }
}
