using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CCSB.Models
{
    public class Contract
    {
        [Key]
        public string Kenteken { get; set; }
        public string Voornaam { get; set; }
        public string Achternaam { get; set; }
        public string Tussenvoegsels { get; set; }
        public DateTime DatumVan { get; set; }
        public DateTime DatumTot { get; set; }
        public int ContractId { get; set; }
    }
}
