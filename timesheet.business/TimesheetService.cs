using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using timesheet.api.request;
using timesheet.data;
using timesheet.model;

namespace timesheet.business
{
    public class TimesheetService : ITimesheetService
    {
        public readonly TimesheetDb _db;

        public TimesheetService(TimesheetDb db)
        {
            _db = db;
        }

        public IQueryable<IGrouping<int, Object>> GetEmployeeTimesheet(int employeeId, int year, int weekOfYear)
        {
            var query = _db.Timesheets
                .Where(t => t.EmployeeID == employeeId && t.WeekOfYear == weekOfYear && t.Date.Year == year)
                .Select(t => new { t.TaskID, t.Date, t.NumberOfHours })
                .OrderBy(t => t.Date)
                .GroupBy(t => t.TaskID); 
            return query;
        }

        public void SaveWeeklyRecord(AddLogRequest req)
        {
            if (req.TimeLogs == null || req.TimeLogs.Length == 0)
                return;

            var existingRecord = _db.Timesheets.Where(x => x.EmployeeID == req.EmployeeId && x.WeekOfYear == req.WeekOfYear).ToList();
            _db.Timesheets.RemoveRange(existingRecord);

            var timeSheets = new List<Timesheet>();
            foreach (TimeLog timelog in req.TimeLogs)
            {
                timeSheets.Add(GetNewTimesheet(req.EmployeeId, req.WeekOfYear, timelog.TaskId, timelog.SundayDate, timelog.SundayValue));
                timeSheets.Add(GetNewTimesheet(req.EmployeeId, req.WeekOfYear, timelog.TaskId, timelog.MondayDate, timelog.MondayValue));
                timeSheets.Add(GetNewTimesheet(req.EmployeeId, req.WeekOfYear, timelog.TaskId, timelog.TuesdayDate, timelog.TuesdayValue));
                timeSheets.Add(GetNewTimesheet(req.EmployeeId, req.WeekOfYear, timelog.TaskId, timelog.WednesdayDate, timelog.WednesdayValue));
                timeSheets.Add(GetNewTimesheet(req.EmployeeId, req.WeekOfYear, timelog.TaskId, timelog.ThursdayDate, timelog.ThursdayValue));
                timeSheets.Add(GetNewTimesheet(req.EmployeeId, req.WeekOfYear, timelog.TaskId, timelog.FridayDate, timelog.FridayValue));
                timeSheets.Add(GetNewTimesheet(req.EmployeeId, req.WeekOfYear, timelog.TaskId, timelog.SaturdayDate, timelog.SaturdayValue));
            }
            _db.Timesheets.AddRange(timeSheets);
            _db.SaveChanges();
        }

        public bool RecordExists(int employeeId, int year, int weekOfYear, int taskId)
        {
            return _db.Timesheets.Any(x => x.EmployeeID == employeeId && x.Date.Year == year && x.WeekOfYear == weekOfYear && x.TaskID == taskId);
        }

        private Timesheet GetNewTimesheet(int employeeId, int weekOfYear, int taskId, DateTime date, int? value)
        {
            return new Timesheet
            {
                EmployeeID = employeeId,
                TaskID = taskId,
                WeekOfYear = weekOfYear,
                Date = date,
                NumberOfHours = value ?? 0
            };
        }

    }
}
