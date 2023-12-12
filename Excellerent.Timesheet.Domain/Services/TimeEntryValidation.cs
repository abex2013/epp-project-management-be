using Excellerent.SharedModules.DTO;
using Excellerent.Timesheet.Domain.Entities;
using Excellerent.Timesheet.Domain.Interfaces.Service;
using Excellerent.Timesheet.Domain.Models;
using Microsoft.VisualBasic;
using System;

namespace Excellerent.Timesheet.Domain.Services
{
    public class TimeEntryValidation : ITimeEntryValidation
    {
        private readonly ITimeSheetService _service;

        public TimeEntryValidation(ITimeSheetService service)
        {
            _service = service;
        }
        public ResponseDTO IsEntryValid(TimeEntry entry, Guid employeeId)
        {
            return (entry.Date.Date > DateTime.Today) ? new ResponseDTO(ResponseStatus.Error, "Cannot log time for future date.", entry)
             : (entry.Date.Date <= DateAndTime.DateAdd(DateInterval.Day, -21, DateTime.Today)) ? new ResponseDTO(ResponseStatus.Error, "Cannot log time for days older than 3 weeks.", entry)
             : (_service.GetTimesheetForEntryDate(entry, employeeId).Result.TotalHours + entry.Hour > 24) ?
             new ResponseDTO(ResponseStatus.Error, "Cannot log time more than 24 hrs for a single day.", entry)
             : new ResponseDTO(ResponseStatus.Success, "entry is valid", entry);

        }
    }
}
