using Excellerent.SharedModules.Seed;
using System;

namespace Excellerent.Timesheet.Domain.Models
{
    public enum ApprovalStatus
    {
        Requested,
        Approved,
        Rejected
    }
    public class TimesheetAproval :  BaseAuditModel
    {
        public Guid TimesheetId { get; set; }
        public Guid ProjectId { get; set; }
        public int Status { get; set; }

    }
}
