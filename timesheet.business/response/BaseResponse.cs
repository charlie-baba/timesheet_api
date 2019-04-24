using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace timesheet.api.response
{
    public class BaseResponse
    {
        public string Code { get; set; }

        public string Description { get; set; }
    }
}
