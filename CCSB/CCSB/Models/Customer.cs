using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CCSB.Models
{
    public class Customer : ApplicationUser
    {
        public int CustomerID { get; set; }
        public string City { get; set; }
        public string BankAccount { get; set; }
        public string PostalCode { get; set; }
    }
}
