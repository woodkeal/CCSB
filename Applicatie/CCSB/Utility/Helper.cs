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
