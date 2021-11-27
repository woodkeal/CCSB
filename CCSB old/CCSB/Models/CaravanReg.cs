using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CCSB.Models
{
    public partial class CaravanReg
    {
        // Items for ticket
        public string EmptyWeight { get; set; }
        public bool HoldingTank { get; set; }
        public virtual Vehicles Kenteken { get; set; }

    }
}
