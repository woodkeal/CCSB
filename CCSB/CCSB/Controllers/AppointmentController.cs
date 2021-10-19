using CCSB.services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CCSB.Controllers
{
    public class AppointmentController : Controller
    {
        private readonly IAppointmentService _appointmentService;
        public AppointmentController(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService; 
        }

        public IActionResult Index()
        {
            ViewBag.AdminList = _appointmentService.GetAdminList();
            return View();
        }
    }
}
