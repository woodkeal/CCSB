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
            if (User.IsInRole("User")) {
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
                    x.Length == search && x.Customer.Email == User.Identity.Name || 
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
                    return View(await _context.Vehicles.Include(v => v.Customer).Where(x => x.Length == search || search == null).ToListAsync());
                }
                //Gives list results from all users
                else
                {
                    var applicationDbContext = _context.Vehicles.Include(v => v.Customer);
                    return View(await applicationDbContext.ToListAsync());
                }
            }
            else {
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
                ViewData["CustomerId"] = new SelectList(_context.Users, "Id", "FullName");
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
                _context.Add(vehicles);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CustomerId"] = new SelectList(_context.Users, "Id", "FullName", vehicles.ApplicationUserId);
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
                ViewData["CustomerId"] = new SelectList(_context.Users, "Id", "FullName", vehicles.ApplicationUserId);
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
        public async Task<IActionResult> Edit(string id, [Bind("LicensePlate,Mileage,Length,PowereSupply,Brand,Model,KindOfVehicle,CustomerId")] Vehicles vehicles)
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
            ViewData["CustomerId"] = new SelectList(_context.Users, "Id", "FullName", vehicles.ApplicationUserId);
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
    }
}
