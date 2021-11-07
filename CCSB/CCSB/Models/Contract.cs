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
        public int Duration { get; internal set; }
        public string Title { get; internal set; }
        public string Description { get; internal set; }
        public string AdminId { get; internal set; }
        public string UserId { get; internal set; }
        public int Id { get; internal set; }
    }
}
