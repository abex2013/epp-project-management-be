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
    public interface ITimeSheetService : ICRUD<TimeSheetEntity, TimeSheet>
    {
        Task<IEnumerable<TimeSheetEntity>> GetTimeSheetByEmployee(Guid empId, DateTime fromDate);
        Task<TimeSheet> GetEmployeeLastSheet(Guid employeeId);
        Task<TimeSheet> NewSheet(Guid employeeId, TimeEntry entry);
        Task<TimeSheet> AddToExistingTimeSheet(TimeSheet timeSheet, TimeEntry timeEntry);
        int GetSheetTotalHour(TimeSheet sheet);
        Task<int> GetTimeEntryTotalHour(TimeSheet timeSheet);
        Task<TimeSheet> GetLastSheet(Guid employeeId);
        TimeSheet GetNewTimeSheet(TimeEntry entry);
        // TimeSheet GetSheetForDay(TimeEntryEntity entryEntity, int employeeId);
        Task<TimeSheet> GetSheetForDay(TimeEntry entryEntity, Guid employeeId);
        
        // Get Timesheet by Timesheet Id
        Task<ResponseDTO> GetTimeSheet(Guid id);
        // Get Timesheet by Employee Id and Date
        Task<ResponseDTO> GetTimeSheet(Guid employeeId, DateTime? date);
        // Get Timesheet by Employee Id, fromDate, and toDate
        Task<ResponseDTO> GetTimeSheet(Guid employeeId, DateTime fromDate, DateTime toDate);

        // Add Timesheet
        Task<ResponseDTO> AddTimeSheet(Guid employeeId, TimeEntryDto timeEntryDto);
        Task<ResponseDTO> AddTimeSheet(TimeSheetDto timeSheetDto, TimeEntryDto timeEntryDto);
        Task<TimeSheet> GetTimesheetForEntryDate(TimeEntry entry, Guid employeeId);
        Task<TimeSheet> GetSheetById(Guid id);
        Task<TimeSheetEntity> UpdateTimesheet(TimeSheetEntity timeSheet);
    }
}
