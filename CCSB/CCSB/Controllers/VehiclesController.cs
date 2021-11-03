using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CCSB.Controllers
{
    public class VehiclesController : Controller
    {
        public IActionResult Index()
        {
            if (User.IsInRole("User"))
            {
                return View("Vehicles");
            }
            else if (User.IsInRole("Admin"))
            {
                return View("Register");
            }
            else 
            {
                return RedirectToAction("Login", "Account");
            }
        }

        public IActionResult Vehicles() 
        {
            if (User.IsInRole("User"))
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        public IActionResult Register()
        {
            if (User.IsInRole("Admin"))
            {
                return View();
            }
            else {
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(VehiclesController model)
        {

            if (ModelState.IsValid)
            {
                
            }
            return View();
        }
    }
}
