using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using CCSB.Models;
using System.Threading.Tasks;

namespace CCSB.Models
{
    public class Contract
    {
        [Key]
        // generate Contractid die niet veranderd kan worden alleen 
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        // Random nummer voor contract
        public int ContractId { get;set;}
        // Appointmentdate van Appointment word begin datum van het contract.
        private DateTime Appointmentdate = DateTime.Now;
        private DateTime ContractEnd = DateTime.Now.AddYears(1);
        // Appointmentdate + 1 jaar (standaard contract lengte)
        public DateTime DateCreated
        {
            get { return Appointmentdate; }
            set { Appointmentdate = value; }    
        }
        public virtual Vehicles LicensePlate { get; set; }
    }
}
