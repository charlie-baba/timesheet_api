using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace timesheet.api.request
{
    public class AddLogRequest
    {
        public int EmployeeId { get; set; }
        
        public int WeekOfYear { get; set; }

        public TimeLog[] TimeLogs { get; set; }
    }
}
