using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace timesheet.model
{
    public class EmployeeTask
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        public int EmployeeId { get; set; }

        public int TaskId { get; set; }

        public virtual Employee Employee { get; set; }

        public virtual Task Task { get; set; }
    }
}
