using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CCSB.Models
{
    public class Vehicles
    {
        [Key]
        public string LicensePlate { get; set; }
        public string Mileage { get; set; }
        public string Length { get; set; }
        public bool PowereSupply { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public bool KindOfVehicle { get; set; }

    }
}
