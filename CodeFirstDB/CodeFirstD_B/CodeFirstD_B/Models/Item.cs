using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CodeFirstD_B.Models
{
    public class Item
    {
        public int Id { get; set; }
        public string Borrower { get; set; }
    }
}
