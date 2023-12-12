using Excellerent.SharedModules.Interface.Service;
using Excellerent.Timesheet.Domain.Entities;
using Excellerent.Timesheet.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Excellerent.Timesheet.Domain.Interfaces.Service
{
    public interface ITimesheetAprovalService : ICRUD<TimesheetAprovalEntity, TimesheetAproval>
    {
        Task<IEnumerable<TimesheetAprovalDto>> GetTimesheetApprovalStatus(Guid tsGuid);
    }
}
