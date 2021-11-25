using CCSB.Models.ViewModels;
using CCSB.Services;
using CCSB.Utility;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CCSB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentApiController : ControllerBase
    {
        private readonly IAppointmentService _appointmentService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly string loginUserId;
        private readonly string role; 

        public AppointmentApiController(IAppointmentService appointmentService, IHttpContextAccessor httpContextAccessor)
        {
            _appointmentService = appointmentService;
            _httpContextAccessor = httpContextAccessor;
            loginUserId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            role = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Role);
        }
        //saves the Calendar data
        [HttpPost]
        [Route("SaveCalendarData")]
        public IActionResult SaveCalendarData(AppointmentViewModel data)
        {
            CommonResponse<int> commonResponse = new CommonResponse<int>();
            try
            {
                commonResponse.Status = _appointmentService.AddUpdate(data).Result;
                //gives status message if succesfull 
                if (commonResponse.Status == 1)
                {
                    //gives status message if update succesfull 
                    commonResponse.Message = Helper.AppointmentUpdated;
                }
                else if (commonResponse.Status == 2)
                {
                    //gives status message if add succesfull 
                    commonResponse.Message = Helper.AppointmentAdded;
                }
            }
            //gives failure code
            catch (Exception ex)
            {
                commonResponse.Message = ex.Message;
                commonResponse.Status = Helper.Failure_code;
            }
            return Ok(commonResponse);
        }
        //gets the calendar data
        [HttpGet]
        [Route("GetCalendarData")]
        public IActionResult GetCalendarData()
        {
            CommonResponse<List<AppointmentViewModel>> commonResponse = new CommonResponse<List<AppointmentViewModel>>();
            try
            {
                //gets calendar data if logged in as a user 
                if (role == Helper.User)
                {
                    commonResponse.Dataenum = _appointmentService.UserAppointments(loginUserId);
                    commonResponse.Status = Helper.Succes_code;
                }
                //gets calendar data of all the users if logged in as an admin 
                else if (role == Helper.Admin)
                {
                    commonResponse.Dataenum = _appointmentService.AllAppointments();
                    commonResponse.Status = Helper.Succes_code;
                }
            }
            //gives failure code
            catch (Exception ex)
            {
                commonResponse.Message = ex.Message;
                commonResponse.Status = Helper.Failure_code;
            }
            return Ok(commonResponse);
        }
        //gets calendar data per appointment 
        [HttpGet]
        [Route("GetCalendarDataById/{id}")]
        public IActionResult GetCalendarDataById(int id)
        {
            CommonResponse<AppointmentViewModel> commonResponse = new CommonResponse<AppointmentViewModel>();
            try
            {
                commonResponse.Dataenum = _appointmentService.GetById(id);
                commonResponse.Status = Helper.Succes_code;
            }
            //gives failure code
            catch (Exception ex)
            {
                commonResponse.Message = ex.Message;
                commonResponse.Status = Helper.Failure_code;
            }
            return Ok(commonResponse);
        }
    }
}
   
