using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using timesheet.api.request;
using timesheet.model;

namespace timesheet.business
{
    public interface ITimesheetService
    {
        IQueryable<IGrouping<int, Object>> GetEmployeeTimesheet(int employeeId, int Year, int weekOfYear);

        void SaveWeeklyRecord(AddLogRequest req);

        bool RecordExists(int employeeId, int year, int weekOfYear, int taskId);
    }
}
