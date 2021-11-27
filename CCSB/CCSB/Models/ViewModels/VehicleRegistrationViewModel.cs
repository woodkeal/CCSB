using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CCSB.Models.ViewModels
{
    public class VehicleRegistrationViewModel
    {
        public string LicensePlate { get; set; }
        public int Mileage { get; set; }
        public int Length { get; set; }
        public bool PowereSupply { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string KindOfVehicle { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }

        //// Items for ticket
        //public string Color { get; set; }
        //public string BuildYear { get; set; }
        //public string SleepingPlaces { get; set; }
        //public bool BicycleCarrier { get; set; }
        //public bool Airco { get; set; }
        //public string Pk { get; set; }
        //public bool TowBar { get; set; }
        //public string EmptyWeight { get; set; }
        //public bool HoldingTank { get; set; }

    }
}
