﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CCSB.Controllers
{
    public class AgendaController : Controller
    {
        public IActionResult Agenda()
        {
            return View();
        }
    }
}