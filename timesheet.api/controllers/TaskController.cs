using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using timesheet.business;

namespace timesheet.api.controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService _taskService;

        public TaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll(string text)
        {
            var tasks = _taskService.GetAllTasks().ToList();
            return new ObjectResult(tasks);
        }

        [HttpGet("{employeeId}")]
        public IActionResult GetEmploeeTasks([FromRoute] int employeeId)
        {
            var tasks = _taskService.GetEmployeeTasks(employeeId).ToList();
            return new ObjectResult(tasks);
        }
    }
}