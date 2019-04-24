using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace timesheet.api.response
{
    public class EmployeeTimeLogResponse : BaseResponse
    {
        List<EmployeeTimeLog> TimeLogs { get; set; }
    }
}
