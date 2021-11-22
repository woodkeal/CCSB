using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CCSB.Models.ViewModels
{
    public class ContractViewModel
    {
        public int ContractId { get; set; }
        public DateTime DatumVan { get; set; }
        public DateTime? DatumTot
        {
            get
            {
                return DatumVan.AddYears(1);
            }
        }
    }
}
