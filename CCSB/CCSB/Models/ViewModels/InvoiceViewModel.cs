using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CCSB.Models.ViewModels
{
    public class InvoiceViewModel
    {
        public int InvoiceNumber { get; set; }
        public string CustomerName { get; set; }
        public string Address { get; set; }
        public DateTime InvoiceDate { get; set; }
        public DateTime ExperationDate { get; set; }

        public string Type { get; set; }
        public string LicensePlate { get; set; }
        public int Length { get; set; }
        public int AmountPerMeter { get; set; }
    }
}
