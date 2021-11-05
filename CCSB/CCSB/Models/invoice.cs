using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CCSB.Models
{
    public class invoice
    {
        [Key]
        public int InvoiceNumber { get; set; }
        public string CustomerName { get; set; }
        public string Address { get; set; }
        public DateTime InvoiceDate { get; set; }
    }
}
