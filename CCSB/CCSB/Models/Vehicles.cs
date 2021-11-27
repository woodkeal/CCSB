using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CCSB.Models
{
    public partial class Vehicles
    {
        [Key]
        [DisplayName("Kenteken")]
        [Required(ErrorMessage = "{0} is een verplicht veld.")]
        public string LicensePlate { get; set; }

        [DisplayName("Kilometer Stand")]
        [Required(ErrorMessage = "{0} is een verplicht veld.")]
        public int Mileage { get; set; }

        [DisplayName("Lengte")]
        [Required(ErrorMessage = "{0} is een verplicht veld.")]
        public int Length { get; set; }

        [DisplayName("Stroom")]
        [Required(ErrorMessage = "{0} is een verplicht veld.")]
        public bool PowereSupply { get; set; }

        [DisplayName("Merk")]
        [Required(ErrorMessage = "{0} is een verplicht veld.")]
        public string Brand { get; set; }

        [DisplayName("Model")]
        [Required(ErrorMessage = "{0} is een verplicht veld.")]
        public string Model { get; set; } = "Camper";

        public string Color { get; set; }
        public int BuildYear { get; set; }
        public int SleepingPlaces { get; set; }
        public bool BicycleCarrier { get; set; }
        public bool Airco { get; set; }

        [DisplayName("Gebruiker")]
        public string ApplicationUserId { get; set; }
        public virtual ApplicationUser Customer { get; set; }
        public virtual Camper Camper { get; set; }
        public virtual Caravan Caravan { get; set; }
    }
}
