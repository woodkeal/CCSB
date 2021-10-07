using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CCSB.Utility;
using CCSB.Models;

namespace CCSB.Models
{
    public class AccountController : Controller
    {
        private readonly ApplicationDBcontext _db;

        public AccountController(ApplicationDBcontext db)
        {
            _db = db;
        }

        public IActionResult Login()
        {
            return View();
        }
    }
}
