using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace timesheet.api.response
{
    public class EmployeeTimeLog
    {
        public int NumberOfHours { get; set; }

        public string DayOfWeek { get; set; }

        public int WeekOfYear { get; set; }

        public string  Task { get; set; }
    }
}
