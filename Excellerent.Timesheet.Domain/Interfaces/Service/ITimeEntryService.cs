using Excellerent.SharedModules.DTO;
using Excellerent.SharedModules.Interface.Service;
using Excellerent.Timesheet.Domain.Dtos;
using Excellerent.Timesheet.Domain.Entities;
using Excellerent.Timesheet.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Excellerent.Timesheet.Domain.Interfaces.Service
{
    public interface ITimeEntryService : ICRUD<TimeEntryEntity, TimeEntry>
    {
        Task<TimeEntry> NewEntry(TimeEntry entry, Guid employeeId);
        Task<ResponseDTO> GetTimeEntry(Guid timeEntryId);
        Task<ResponseDTO> GetTimeEntryForUpdateOrDelete(Guid timeEntryId);
        Task<ResponseDTO> GetTimeEntries(Guid timeSheetId, DateTime? date, Guid? projectId);
        Task<ResponseDTO> AddTimeEntry(Guid employeeId, TimeEntryDto timeEntryDto);

        Task<ResponseDTO> UpdateTimeEntry(TimeEntryDto timeEntryDto);
        Task<List<TimeEntry>> ApproveTimeSheet(Guid tsGuid);
        Task<TimeSheet> GetTimesheetByTimesheetId(Guid id);
    }
}
