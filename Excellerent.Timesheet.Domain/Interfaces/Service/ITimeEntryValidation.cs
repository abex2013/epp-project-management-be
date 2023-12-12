using Excellerent.SharedModules.DTO;
using Excellerent.Timesheet.Domain.Entities;
using Excellerent.Timesheet.Domain.Models;
using System;

namespace Excellerent.Timesheet.Domain.Interfaces.Service
{
    public interface ITimeEntryValidation
    {
        ResponseDTO IsEntryValid(TimeEntry entry, Guid employeeId);
    }
}
