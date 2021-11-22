using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CCSB.Models
{
    public class Contract
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ContractId { get; set; }
        public DateTime DatumVan { get; set; }
        public DateTime? DatumTot {
            get
            {
                return DatumVan.AddYears(1);
            }
        }
        public string Id { get; }
        public Vehicles vehicles { get; }
    }
}
