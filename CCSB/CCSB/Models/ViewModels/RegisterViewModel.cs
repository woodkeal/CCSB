using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CCSB.Models.ViewModels
{
    public class RegisterViewModel
    {
        [DisplayName("Voornaam")]
        [Required(ErrorMessage = "{0} is een verplicht veld.")]
        public string FirstName { get; set; }

        [DisplayName("Tussenvoegsels")]
        public string MiddleName { get; set; }

        [DisplayName("Achternaam")]
        [Required(ErrorMessage = "{0} is een verplicht veld.")]
        public string LastName { get; set; }

        [EmailAddress]
        [Required(ErrorMessage = "{0} is een verplicht veld.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "{0} is een verplicht veld.")]
        [DataType(DataType.Password)]
        [DisplayName("Wachtwoord")]
        [StringLength(10, ErrorMessage = "Het {0} moet minstens {1} tekens bevatten.",
         MinimumLength = 6)]
        public string Password { get; set; }

        [DisplayName("Bevestig wachtwoord")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Wachtwoorden komen niet overeen")]
        public string PasswordConfirm { get; set; }

        //[DisplayName("Rol")]
        //[Required(ErrorMessage = "{0} is een verplicht veld.")]
        //public string RoleName { get; set; }

        [DisplayName("City")]
        [Required(ErrorMessage = "{0} is een verplicht veld.")]
        public string City { get; set; }

        [DisplayName("BankAccount")]
        [Required(ErrorMessage = "{0} is een verplicht veld.")]
        public string BankAccount { get; set; }

        [DisplayName("PostalCode")]
        [Required(ErrorMessage = "{0} is een verplicht veld.")]
        public string PostalCode { get; set; }

        [DisplayName("Address")]
        [Required(ErrorMessage = "{0} is een verplicht veld.")]
        public string Address { get; set; }
    }
}
