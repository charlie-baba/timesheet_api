using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using timesheet.api.request;
using timesheet.api.response;
using timesheet.business;

namespace timesheet.api.controllers
{
    [Route("api/v1/employee")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll(string text)
        {
            var items = _employeeService.GetEmployees().ToList();
            return new ObjectResult(items);
        }

        [HttpGet("weeklyEffort/{year}/{week}")]
        public IActionResult TotalWeeklyEffort([FromRoute] int year, int week)
        {
            var items = _employeeService.GetEmployeesWeeklyEffort(year, week).ToList();
            return new ObjectResult(items);
        }

        [HttpPost("assignTask")]
        public IActionResult AssignTask([FromBody] AssignTaskRequest request)
        {
            BaseResponse response;
            try
            {
                if (_employeeService.IsTaskAssigned(request.EmployeeId, request.TaskId)) 
                {
                    response = new BaseResponse { Code = "02", Description = "This task has already been assigned to this employee." };
                }
                else
                {
                    _employeeService.AssignTask(request.EmployeeId, request.TaskId);
                    response = new BaseResponse { Code = "00", Description = "Task assigned successfully" };
                }
            }
            catch (Exception e)
            {
                response = new BaseResponse { Code = "ZZ", Description = "Server Error." };
            }
            return Ok(response);
        }
    }
}