using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CCSB.Utility
{
    public static class Helper
    {
        public static readonly string Admin = "Admin";
        public static readonly string User = "User";

        public static string SomethingWentWrong = "Er ging iets mis. Probeer het opnieuw.";

        public static string AppointmentAdded = "Afspraak succesvol opgeslagen.";
        public static string AppointmentConfirmed = "Afspraak bevestigd.";
        public static string AppointmentUpdated = "Afspraak succesvol gewijzigd.";
        public static string AppointmentDeleted = "Afspraak succesvol verwijderd.";
        public static string AppointmentExists = "Afspraak bestaat al op gegeven datum en tijdstip.";
        public static string AppointmentNotExists = "Afspraak bestaat niet.";
        public static string AppointmentAddError = "Er ging iets mis. Afspraak niet toegevoegd.";
        public static string AppointmentConfirmError = "Er ging iets mis. Afspraak niet bevestigd.";
        public static string AppointmentUpdateError = "Er ging iets mis. Afspraak niet gewijzigd.";

        public static string VehicleAdded = "Voertuig succesvol opgeslagen.";
        public static string VehicleConfirmed = "Voertuig bevestigd.";
        public static string VehicleUpdated = "Voertuig succesvol gewijzigd.";
        public static string VehicleDeleted = "Voertuig succesvol verwijderd.";
        public static string VehicleExists = "Voertuig bestaat al op gegeven datum en tijdstip.";
        public static string VehicleNotExists = "Voertuig bestaat niet.";
        public static string VehicleAddError = "Er ging iets mis. Voertuig niet toegevoegd.";
        public static string VehicleConfirmError = "Er ging iets mis. Voertuig niet bevestigd.";
        public static string VehicleUpdateError = "Er ging iets mis. Voertuig niet gewijzigd.";

        public static int Succes_code = 1;
        public static int Failure_code = 0;

        public static List<SelectListItem> GetRolesForDropDown(bool isAdmin) 
        {
            var items = new List<SelectListItem>
            {
                new SelectListItem{Value=Helper.Admin , Text=Helper.Admin},
                new SelectListItem{Value=Helper.User , Text=Helper.User}
            };

            return items.OrderBy(s=> s.Text).ToList();
        }
    }
}
