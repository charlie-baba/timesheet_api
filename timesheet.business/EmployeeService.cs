using System;
using System.Linq;
using timesheet.data;
using timesheet.model;

namespace timesheet.business
{
    public class EmployeeService : IEmployeeService
    {
        public readonly TimesheetDb _db;

        public EmployeeService(TimesheetDb dbContext)
        {
            _db = dbContext;
        }

        public IQueryable<Employee> GetEmployees()
        {
            return _db.Employees;
        }

        public IQueryable<object> GetEmployeesWeeklyEffort(int year, int week)
        {
            var weeksTimesheets = _db.Timesheets.Where(t => t.WeekOfYear == week && t.Date.Year == year);
            var yearsTimesheets = _db.Timesheets.Where(t => t.Date.Year == year);

            var query = _db.Employees.Select(t => new
            {
                t.Id, t.Code, t.Name,
                Sum = weeksTimesheets.Where(x => x.EmployeeID == t.Id).Sum(x => x.NumberOfHours),
                Total = yearsTimesheets.Where(x => x.EmployeeID == t.Id).Sum(x => x.NumberOfHours),
                Weeks = yearsTimesheets.Where(x => x.EmployeeID == t.Id).Select(x => x.WeekOfYear).Distinct().Count()
            });
            return query;
        }

        public bool IsTaskAssigned(int employeeId, int taskId)
        {
            return _db.EmployeeTasks.Any(x => x.EmployeeId == employeeId && x.TaskId == taskId);
        }

        public int AssignTask(int employeeId, int taskId)
        {
            var employeeTask = new EmployeeTask
            {
                EmployeeId = employeeId,
                TaskId = taskId
            };
            _db.EmployeeTasks.Add(employeeTask);
            return _db.SaveChanges();
        }
    }
}
