using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using timesheet.data;
using timesheet.model;

namespace timesheet.business
{
    public class TaskService : ITaskService
    {
        public readonly TimesheetDb _db;

        public TaskService(TimesheetDb db)
        {
            _db = db;
        }

        public IQueryable<Task> GetAllTasks()
        {
            return _db.Tasks;
        }

        public IQueryable<Task> GetEmployeeTasks(int employeeId)
        {
            return _db.EmployeeTasks.Where(t => t.EmployeeId == employeeId)
                .Select(t => t.Task);
        }
    }
}
