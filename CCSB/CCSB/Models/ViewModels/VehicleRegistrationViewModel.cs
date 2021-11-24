using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CCSB.Models.ViewModels
{
    public class VehicleRegistrationViewModel
    {
        public string LicensePlate { get; set; }
        public string Mileage { get; set; }
        public string Length { get; set; }
        public bool PowereSupply { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string KindOfVehicle { get; set; }
        public string CustomerId { get; set; }
        public string UserName { get; set; }

        // Items for ticket
        public string Color { get; set; }
        public string BuildYear { get; set; }
        public string SleepingPlaces { get; set; }
        public bool BicycleCarrier { get; set; }
        public bool Airco { get; set; }
    }
}
