using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CCSB.Models
{
    public class Plate
    {
        [Key]
        public int InvoiceNumber { get; set; }
        public string Type { get; set; }
        public string LicensePlate { get; set; }
        public int Length { get; set; }
        public int AmountPerMeter { get; set; }
    }
}