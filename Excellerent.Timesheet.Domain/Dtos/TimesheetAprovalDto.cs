using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excellerent.Timesheet.Domain.Models
{
    public class TimesheetAprovalDto
    {
        public Guid TimesheetId { get; set; }
        public Guid ProjectId { get; set; }
        public int Status { get; set; }
    }
}
