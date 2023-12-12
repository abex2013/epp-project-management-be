using Excellerent.SharedModules.Seed;
using Excellerent.Timesheet.Domain.Models;
using System;

namespace Excellerent.Timesheet.Domain.Entities
{
    public class TimesheetAprovalEntity : BaseEntity<TimesheetAproval>
    {
        public Guid TimesheetId { get; set; }
        public Guid ProjectId { get; set; }
        public int Status { get; set; }

        public override TimesheetAproval MapToModel()
        {
            TimesheetAproval tsa = new TimesheetAproval();
            tsa.TimesheetId = TimesheetId;
            tsa.ProjectId = ProjectId;
            tsa.Status = Status;
            return tsa;
        }

        public override TimesheetAproval MapToModel(TimesheetAproval t)
        {
            throw new NotImplementedException();
        }

        public TimesheetAprovalEntity()
        {

        }
    }
}
