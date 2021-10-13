﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CCSB.Models
{
    public class CustomerDetails
    {
        [Key]
        public int CustomerID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Insertion { get; set; }
        public string City { get; set; }
        public string BankAccount { get; set; }
        public string PostalCode { get; set; }
        public string Email { get; set; }
    }
}