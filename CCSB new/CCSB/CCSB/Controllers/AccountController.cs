using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CCSB.Utility;
using CCSB.Models;
using Microsoft.AspNetCore.Identity;
using CCSB.Models.ViewModels;
using CCSB.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity.UI.Services;

namespace CCSB.Models
{
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _db;
        UserManager<ApplicationUser> _userManager;
        SignInManager<ApplicationUser> _signInManager;
        RoleManager<IdentityRole> _roleManager;
        private readonly IEmailSender _emailSender;

        public AccountController(ApplicationDbContext db,
            IEmailSender emailSender,
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager,
            SignInManager<ApplicationUser> signInManager)
        {
            _db = db;
            _roleManager = roleManager;
            _signInManager = signInManager;
            _userManager = userManager;
            _emailSender = emailSender;
        }

        public IActionResult Login()
        {
            //Checks if an user is logged in
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View();   
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if(ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);
                if(result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "inloggen mislukt");
            }
            return View(model);
        }

        public IActionResult Register()
        {
            //Checks if an user is logged in
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View();
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model) 
        {

            if (ModelState.IsValid)
            {
                //Passed data from register form
                Customer user = new Customer()
                {
                    UserName = model.Email,
                    Email = model.Email,
                    FirstName = model.FirstName,
                    MiddleName = model.MiddleName,
                    LastName = model.LastName,
                    City = model.City,
                    BankAccount = model.BankAccount,
                    PostalCode = model.PostalCode,
                    Address = model.Address
                };

                //Tries to register user in the database
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded) 
                {
                    //Add user to role user
                    await _userManager.AddToRoleAsync(user, "User");

                    //Signs in user imidiatly after registering
                    await _signInManager.SignInAsync(user, isPersistent: false);

                    //Send email when registered succesfully
                    await _emailSender.SendEmailAsync(user.Email, "Welkom!",
                    $"Er is een account aangemaakt bij CCSB!");

                    return RedirectToAction("Index", "Home");
                }
                
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View();
        }
        
        public async Task<IActionResult> LogOff()
        {
            //Logs out user
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
