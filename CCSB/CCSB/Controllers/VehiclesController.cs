using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CCSB.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using CCSB.Utility;
using System.Text.RegularExpressions;

namespace CCSB.Controllers
{
    public class VehiclesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VehiclesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Vehicles
        [Authorize]
        public async Task<IActionResult> Index(string option, string search)
        {
            if (User.IsInRole("User"))
            {
                //Gives list results based on license plate from the logged in user
                if (option == "License")
                {
                    return View(await _context.Vehicles.Include(v => v.Customer).Where(x =>
                    x.LicensePlate == search && x.Customer.Email == User.Identity.Name ||
                    x.Customer.Email == User.Identity.Name && search == null).ToListAsync());
                }
                //Gives list results based on length plate from the logged in user
                if (option == "Length")
                {
                    return View(await _context.Vehicles.Include(v => v.Customer).Where(x =>
                    x.Length.ToString() == search && x.Customer.Email == User.Identity.Name ||
                    x.Customer.Email == User.Identity.Name && search == null).ToListAsync());
                }
                //Gives list results from the logged in user
                else
                {
                    return View(await _context.Vehicles.Include(v => v.Customer).Where(x => x.Customer.Email == User.Identity.Name).ToListAsync());
                }
            }


            if (User.IsInRole("Admin"))
            {
                //Gives list results based on name from all users
                if (option == "Name")
                {
                    return View(await _context.Vehicles.Include(v => v.Customer).Where(x =>
                    x.Customer.FirstName + ' ' + x.Customer.LastName == search ||
                    x.Customer.FirstName + ' ' + x.Customer.MiddleName + ' ' + x.Customer.LastName == search ||
                    x.Customer.FirstName == search ||
                    x.Customer.LastName == search ||
                    search == null).ToListAsync());
                }
                //Gives list results based on licenseplate from all users
                if (option == "License")
                {
                    return View(await _context.Vehicles.Include(v => v.Customer).Where(x => x.LicensePlate == search || search == null).ToListAsync());
                }
                //Gives list results based on length from all users
                if (option == "Length")
                {
                    return View(await _context.Vehicles.Include(v => v.Customer).Where(x => x.Length.ToString() == search || search == null).ToListAsync());
                }
                //Gives list results from all users
                else
                {
                    var applicationDbContext = _context.Vehicles.Include(v => v.Customer);
                    return View(await applicationDbContext.ToListAsync());
                }
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        // GET: Vehicles/Details/5
        [Authorize]
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicles = await _context.Vehicles
                .Include(v => v.Customer)
                .FirstOrDefaultAsync(m => m.LicensePlate == id);
            if (vehicles == null)
            {
                return NotFound();
            }

            return View(vehicles);
        }

        // GET: Vehicles/Create
        [Authorize]
        public IActionResult Create()
        {
            if (User.IsInRole("Admin"))
            {
                ViewData["ApplicationUserId"] = new SelectList(_context.Users, "Id", "FullName");
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        // POST: Vehicles1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LicensePlate,Mileage,Length,PowereSupply,Brand,Model,KindOfVehicle,ApplicationUserId")] Vehicles vehicles)
        {
            if (ModelState.IsValid)
            {
                if (LicenseplateValidator(vehicles.LicensePlate))
                {
                    _context.Add(vehicles);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ModelState.AddModelError("", "Gegevens konden niet verwerkt worden.");
                }
            }
            ViewData["ApplicationUserId"] = new SelectList(_context.Users, "Id", "FullName", vehicles.ApplicationUserId);
            return View(vehicles);
        }

        // GET: Vehicles/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(string id)
        {
            if (User.IsInRole("Admin"))
            {
                if (id == null)
                {
                    return NotFound();
                }

                var vehicles = await _context.Vehicles.FindAsync(id);
                if (vehicles == null)
                {
                    return NotFound();
                }
                ViewData["ApplicationUserId"] = new SelectList(_context.Users, "Id", "FullName", vehicles.ApplicationUserId);
                return View(vehicles);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        // POST: Vehicles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("LicensePlate,Mileage,Length,PowereSupply,Brand,Model,KindOfVehicle,ApplicationUserId")] Vehicles vehicles)
        {
            if (id != vehicles.LicensePlate)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vehicles);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VehiclesExists(vehicles.LicensePlate))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["ApplicationUserId"] = new SelectList(_context.Users, "Id", "FullName", vehicles.ApplicationUserId);
            return View(vehicles);
        }

        // GET: Vehicles/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicles = await _context.Vehicles
                .Include(v => v.Customer)
                .FirstOrDefaultAsync(m => m.LicensePlate == id);
            if (vehicles == null)
            {
                return NotFound();
            }

            return View(vehicles);
        }

        // POST: Vehicles/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var vehicles = await _context.Vehicles.FindAsync(id);
            _context.Vehicles.Remove(vehicles);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VehiclesExists(string id)
        {
            return _context.Vehicles.Any(e => e.LicensePlate == id);
        }

        private bool LicenseplateValidator(string plate)
        {
            string acceptedNumbers = "1239456789";
            string acceptedChars = "GHJKLNPRSTXZ";

            // 1
            if (acceptedChars.Contains(plate.Substring(0, 1)) && acceptedChars.Contains(plate.Substring(1, 1))
                && plate.Substring(2, 1) == "-" && acceptedNumbers.Contains(plate.Substring(3, 1))
                && acceptedNumbers.Contains(plate.Substring(4, 1)) && plate.Substring(5, 1) == "-"
                && acceptedNumbers.Contains(plate.Substring(6, 1)) && acceptedNumbers.Contains(plate.Substring(7, 1)))
            {
                return true;
            }
            // 2
            if (acceptedNumbers.Contains(plate.Substring(0, 1)) && acceptedNumbers.Contains(plate.Substring(1, 1))
                && plate.Substring(2, 1) == "-" && acceptedNumbers.Contains(plate.Substring(3, 1))
                && acceptedNumbers.Contains(plate.Substring(4, 1)) && plate.Substring(5, 1) == "-"
                && acceptedChars.Contains(plate.Substring(6, 1)) && acceptedChars.Contains(plate.Substring(7, 1)))
            {
                return true;
            }
            // 3
            if (acceptedNumbers.Contains(plate.Substring(0, 1)) && acceptedNumbers.Contains(plate.Substring(1, 1))
                && plate.Substring(2, 1) == "-" && acceptedChars.Contains(plate.Substring(3, 1))
                && acceptedChars.Contains(plate.Substring(4, 1)) && plate.Substring(5, 1) == "-"
                && acceptedNumbers.Contains(plate.Substring(6, 1)) && acceptedNumbers.Contains(plate.Substring(7, 1)))
            {
                return true;
            }
            // 4
            if (acceptedChars.Contains(plate.Substring(0, 1)) && acceptedChars.Contains(plate.Substring(1, 1))
                && plate.Substring(2, 1) == "-" && acceptedNumbers.Contains(plate.Substring(3, 1))
                && acceptedNumbers.Contains(plate.Substring(4, 1)) && plate.Substring(5, 1) == "-"
                && acceptedChars.Contains(plate.Substring(6, 1)) && acceptedChars.Contains(plate.Substring(7, 1)))
            {
                return true;
            }
            // 5
            if (acceptedChars.Contains(plate.Substring(0, 1)) && acceptedChars.Contains(plate.Substring(1, 1))
                && plate.Substring(2, 1) == "-" && acceptedChars.Contains(plate.Substring(3, 1))
                && acceptedChars.Contains(plate.Substring(4, 1)) && plate.Substring(5, 1) == "-"
                && acceptedNumbers.Contains(plate.Substring(6, 1)) && acceptedNumbers.Contains(plate.Substring(7, 1)))
            {
                return true;
            }
            // 6
            if (acceptedNumbers.Contains(plate.Substring(0, 1)) && acceptedNumbers.Contains(plate.Substring(1, 1))
                && plate.Substring(2, 1) == "-" && acceptedChars.Contains(plate.Substring(3, 1))
                && acceptedChars.Contains(plate.Substring(4, 1)) && plate.Substring(5, 1) == "-"
                && acceptedChars.Contains(plate.Substring(6, 1)) && acceptedChars.Contains(plate.Substring(7, 1)))
            {
                return true;
            }
            // 7
            if (acceptedNumbers.Contains(plate.Substring(0, 1)) && acceptedNumbers.Contains(plate.Substring(1, 1))
                && plate.Substring(2, 1) == "-" && acceptedChars.Contains(plate.Substring(3, 1))
                && acceptedChars.Contains(plate.Substring(4, 1)) && acceptedChars.Contains(plate.Substring(5, 1))
                && plate.Substring(6, 1) == "-" && acceptedNumbers.Contains(plate.Substring(7, 1)))
            {
                return true;
            }
            // 8
            if (acceptedNumbers.Contains(plate.Substring(0, 1)) && plate.Substring(1, 1) == "-"
                && acceptedChars.Contains(plate.Substring(2, 1)) && acceptedChars.Contains(plate.Substring(3, 1))
                && acceptedChars.Contains(plate.Substring(4, 1)) && plate.Substring(5, 1) == "-"
                && acceptedNumbers.Contains(plate.Substring(6, 1)) && acceptedNumbers.Contains(plate.Substring(7, 1)))
            {
                return true;
            }
            // 9
            if (acceptedChars.Contains(plate.Substring(0, 1)) && acceptedChars.Contains(plate.Substring(1, 1))
                && plate.Substring(2, 1) == "-" && acceptedNumbers.Contains(plate.Substring(3, 1))
                && acceptedNumbers.Contains(plate.Substring(4, 1)) && acceptedNumbers.Contains(plate.Substring(5, 1))
                && plate.Substring(6, 1) == "-" && acceptedChars.Contains(plate.Substring(7, 1)))
            {
                return true;
            }
            // 10
            else if (acceptedChars.Contains(plate.Substring(0, 1)) && plate.Substring(1, 1) == "-"
                && acceptedNumbers.Contains(plate.Substring(2, 1)) && acceptedNumbers.Contains(plate.Substring(3, 1))
                && acceptedNumbers.Contains(plate.Substring(4, 1)) && plate.Substring(5, 1) == "-"
                && acceptedChars.Contains(plate.Substring(6, 1)) && acceptedChars.Contains(plate.Substring(7, 1)))
            {
                return true;
            }
            // 11
            else if (acceptedChars.Contains(plate.Substring(0, 1)) && acceptedChars.Contains(plate.Substring(1, 1))
                && acceptedChars.Contains(plate.Substring(2, 1)) && plate.Substring(3, 1) == "-"
                && acceptedNumbers.Contains(plate.Substring(4, 1)) && acceptedNumbers.Contains(plate.Substring(5, 1))
                && plate.Substring(6, 1) == "-" && acceptedChars.Contains(plate.Substring(7, 1)))
            {
                return true;
            }
            // 13
            else if (acceptedNumbers.Contains(plate.Substring(0, 1)) && plate.Substring(1, 1) == "-"
                && acceptedChars.Contains(plate.Substring(2, 1)) && acceptedChars.Contains(plate.Substring(3, 1))
                && plate.Substring(4, 1) == "-" && acceptedNumbers.Contains(plate.Substring(5, 1))
                && acceptedNumbers.Contains(plate.Substring(6, 1)) && acceptedNumbers.Contains(plate.Substring(7, 1)))
            {
                return true;
            }
            // 14
            else if (acceptedNumbers.Contains(plate.Substring(0, 1)) && acceptedNumbers.Contains(plate.Substring(1, 1))
                && acceptedNumbers.Contains(plate.Substring(2, 1)) && plate.Substring(3, 1) == "-"
                && acceptedChars.Contains(plate.Substring(4, 1)) && acceptedChars.Contains(plate.Substring(5, 1))
                && plate.Substring(6, 1) == "-" && acceptedNumbers.Contains(plate.Substring(7, 1)))
            {
                return true;
            }
            else
            {
                ModelState.AddModelError("LicensePlate", "Dit is geen geldige kenteken.");
                return false;
            }
        }
    }
}