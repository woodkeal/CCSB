using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CCSB.Models
{
    public class Customer : ApplicationUser
    {
        public string City { get; set; }
        public string BankAccount { get; set; }
        public string PostalCode { get; set; }
        public string Address { get; set; }

        //Navigation Property
        public List<Vehicles> Vehicles { get; set; }
    }
}
