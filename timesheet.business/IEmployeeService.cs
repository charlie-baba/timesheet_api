using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using timesheet.model;

namespace timesheet.business
{
    public interface IEmployeeService
    {
        IQueryable<Employee> GetEmployees();

        IQueryable<object> GetEmployeesWeeklyEffort(int year, int week);

        int AssignTask(int employeeId, int taskId);

        bool IsTaskAssigned(int employeeId, int taskId);
    }
}
