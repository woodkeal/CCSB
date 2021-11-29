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
        // generate Contractid die niet veranderd kan worden alleen 
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        // Random nummer voor contract
        public int ContractId { get; set;}
        // Appointmentdate van Appointment word begin datum van het contract.
        public DateTime DateCreated { get; set; }
        // Appointmentdate + 1 jaar (standaard contract lengte)
        public DateTime EndDate { get; set; }
        [Key]
        public string LicensePlate { get; set; }
    }
}
