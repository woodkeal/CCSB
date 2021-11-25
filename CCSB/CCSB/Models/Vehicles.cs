using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CCSB.Models
{
    public class Vehicles
    {
        [Key]
        [DisplayName("Kenteken")]
        [Required(ErrorMessage = "{0} is een verplicht veld.")]
        public string LicensePlate { get; set; }

        [DisplayName("Kilometer Stand")]
        [Required(ErrorMessage = "{0} is een verplicht veld.")]
        public string Mileage { get; set; }

        [DisplayName("Lengte")]
        [Required(ErrorMessage = "{0} is een verplicht veld.")]
        public string Length { get; set; }

        [DisplayName("Stroom")]
        [Required(ErrorMessage = "{0} is een verplicht veld.")]
        public bool PowereSupply { get; set; }

        [DisplayName("Merk")]
        [Required(ErrorMessage = "{0} is een verplicht veld.")]
        public string Brand { get; set; }

        [DisplayName("Model")]
        [Required(ErrorMessage = "{0} is een verplicht veld.")]
        public string Model { get; set; } = "Camper";

        [DisplayName("Soort")]
        [Required(ErrorMessage = "{0} is een verplicht veld.")]
        public string KindOfVehicle { get; set; }
        public string ApplicationUserId { get; set; }
        public ApplicationUser Customer { get; set; }
    }
}
