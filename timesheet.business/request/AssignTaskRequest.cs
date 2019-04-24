using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace timesheet.api.request
{
    public class AssignTaskRequest
    {
        public int EmployeeId { get; set; }

        public int TaskId { get; set; }
    }
}
