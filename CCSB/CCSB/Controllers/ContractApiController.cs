using CCSB.Models;
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
    public class ContractApiController : ControllerBase
    {
        private readonly IContractService _ContractService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly string loginUserId;
        private readonly string role;

        public ContractApiController(IContractService contractService, IHttpContextAccessor httpContextAccessor)
        {
            _ContractService = contractService;
            _httpContextAccessor = httpContextAccessor;
            loginUserId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            role = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Role);
        }
        [HttpPost]
        [Route("SaveCalendarData")]
        public IActionResult SaveCalendarData(Contract data)
        {
            CommonResponse<int> commonResponse = new CommonResponse<int>();
            try
            {
                commonResponse.Status = _ContractService.AddUpdate(data).Result;
                if (commonResponse.Status == 1)
                {
                    commonResponse.Message = Helper.ContractUpdated;
                }
                else if (commonResponse.Status == 2)
                {
                    commonResponse.Message = Helper.ContractAdded;
                }
            }
            catch (Exception ex)
            {
                commonResponse.Message = ex.Message;
                commonResponse.Status = Helper.Failure_code;
            }
            return Ok(commonResponse);
        }
    }
}

