using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CCSB.Models
{
    public partial class Caravan
    {
        public int? EmptyWeight { get; set; }
        public bool? HoldingTank { get; set; }
        public string LicensePlate { get; set; }

        public virtual Vehicles LicensePlateNavigation { get; set; }
    }
}
