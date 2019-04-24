using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace timesheet.api.request
{
    public class TimeLog
    {
        public int TaskId { get; set; }

        public int? SundayValue { get; set; }

        public int? MondayValue { get; set; }

        public int? TuesdayValue { get; set; }

        public int? WednesdayValue { get; set; }

        public int? ThursdayValue { get; set; }

        public int? FridayValue { get; set; }

        public int? SaturdayValue { get; set; }


        public DateTime SundayDate { get; set; }

        public DateTime MondayDate { get; set; }

        public DateTime TuesdayDate { get; set; }

        public DateTime WednesdayDate { get; set; }

        public DateTime ThursdayDate { get; set; }

        public DateTime FridayDate { get; set; }

        public DateTime SaturdayDate { get; set; }
    }
}
