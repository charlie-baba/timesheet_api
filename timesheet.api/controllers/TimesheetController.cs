using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using timesheet.api.request;
using timesheet.api.response;
using timesheet.business;

namespace timesheet.api.controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class TimesheetController : ControllerBase
    {
        private readonly ITimesheetService _timesheetService;

        public TimesheetController(ITimesheetService timesheetService)
        {
            _timesheetService = timesheetService;
        }

        [HttpGet("{employeeId}/{year}/{weekOfYear}")]
        public IActionResult GetAll([FromRoute] int employeeId, int year, int weekOfYear)
        {
            var items = _timesheetService.GetEmployeeTimesheet(employeeId, year, weekOfYear).ToDictionary(d => d.Key, d => d.ToList());
            return new ObjectResult(items);
        }

        [HttpPost("addtimelog")]
        public IActionResult AddTImeLog([FromBody] AddLogRequest req)
        {
            BaseResponse response;
            try
            {
                _timesheetService.SaveWeeklyRecord(req);
                response = new BaseResponse { Code = "00", Description = "Record saved successfully" };
                
            } catch(Exception e)
            {
                response = new BaseResponse { Code = "ZZ", Description = "Server Error." };
            }
            return Ok(response);
        }
    }
}