using Excellerent.SharedModules.DTO;
using Excellerent.SharedModules.Services;
using Excellerent.Timesheet.Domain.Dtos;
using Excellerent.Timesheet.Domain.Entities;
using Excellerent.Timesheet.Domain.Interfaces.Repository;
using Excellerent.Timesheet.Domain.Interfaces.Service;
using Excellerent.Timesheet.Domain.Mapping;
using Excellerent.Timesheet.Domain.Models;
using LinqKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Excellerent.Timesheet.Domain.Services
{
    public class TimeEntryService : CRUD<TimeEntryEntity, TimeEntry>, ITimeEntryService
    {
        private readonly ITimeEntryRepository _timeEntryRepository;
        private readonly ITimeSheetService _timesheetService;
        private readonly ITimesheetAprovalService _timesheetAprovalService;

        public TimeEntryService(ITimeEntryRepository repository, ITimeSheetService timeSheetService, ITimesheetAprovalService timesheetAprovalService) : base(repository)
        {
            _timeEntryRepository = repository;
            _timesheetService = timeSheetService;
            _timesheetAprovalService = timesheetAprovalService;
        }

        public async Task<TimeEntry> NewEntry(TimeEntry entry, Guid employeeId)
        {
            var existingSheet = await _timesheetService.GetLastSheet(employeeId);
            if (existingSheet != null)
            {
                var preList = _timeEntryRepository.FindAsync(x => x.TimesheetGuid == existingSheet.Guid).Result.ToList();
            }
            if (existingSheet != null && existingSheet.ToDate > entry.Date)
            {
                var preEntry = existingSheet.TimeEntry.Find(x => x.Date.Date == entry.Date.Date && x.ProjectId == entry.ProjectId);
                if (preEntry != null)
                {
                    preEntry.Hour += entry.Hour;
                    await _timeEntryRepository.UpdateAsync(preEntry);
                    await _timesheetService.AddToExistingTimeSheet(existingSheet,new TimeEntry(preEntry));
                    return preEntry;
                }
                else
                {
                    entry.TimesheetGuid = existingSheet.Guid;
                    await _timeEntryRepository.AddAsync(entry);
                    await _timesheetService.AddToExistingTimeSheet(existingSheet, entry);
                    return entry;
                }
            }
            else
            {
                var sheet = _timesheetService.NewSheet(employeeId, entry);
                return entry;
            }
        }

        public int EntiesTotalHrs(TimeEntry entry, Guid employeeId)
        {
            TimeSheet sheet = _timesheetService.GetSheetForDay(entry, employeeId).Result;
            List<TimeEntry> entries = _timeEntryRepository.FindAsync(e => e.TimesheetGuid == sheet.Guid).Result.ToList();
            sheet.TimeEntry.AddRange(entries);
            return _timesheetService.GetSheetTotalHour(sheet);
        }
        public async Task<TimeSheet> GetTimesheetByTimesheetId(Guid id)
        {
            var sheet = await _timesheetService.GetSheetById(id);
            sheet.TimeEntry.AddRange(await _timeEntryRepository.FindAsync(e => e.TimesheetGuid == id));
            return sheet;
        }
        public async Task<List<TimeEntry>> ApproveTimeSheet(Guid tsGuid)
        {
            TimesheetAprovalEntity tsApproval = new TimesheetAprovalEntity();

            var result = _timeEntryRepository.FindAsync(x => x.TimesheetGuid == tsGuid).Result.ToList();
            if (result != null)
            {
                foreach (var te in result)
                {
                    tsApproval.ProjectId = te.ProjectId;
                    tsApproval.TimesheetId = te.TimesheetGuid;
                    tsApproval.Status = (int)ApprovalStatus.Requested;
                    await _timesheetAprovalService.Add(tsApproval);
                }
            }
            return result.Count == 0 ? null : result;
        }

        public async Task<ResponseDTO> GetTimeEntry(Guid timeEntryId)
        {
            try
            {
                var predicate = PredicateBuilder.New<TimeEntry>();

                predicate = predicate.And(timeEntry => timeEntry.Guid == timeEntryId);

                TimeEntry timeEntry = await _timeEntryRepository.GetTimeEntry(predicate);

                return new ResponseDTO(ResponseStatus.Success, "Time Entry by Id", timeEntry?.MapToDto());
            }
            catch (Exception ex)
            {
                return new ResponseDTO(ResponseStatus.Error, ex.Message, null);
            }
        }

        public async Task<ResponseDTO> GetTimeEntryForUpdateOrDelete(Guid timeEntryId)
        {
            try
            {
                var predicate = PredicateBuilder.New<TimeEntry>();

                predicate = predicate.And(timeEntry => timeEntry.Guid == timeEntryId);

                TimeEntry timeEntry = await _timeEntryRepository.GetTimeEntryForUpdateOrDelete(predicate);

                return new ResponseDTO(ResponseStatus.Success, "Time Entry by Id for Update or Delete", timeEntry?.MapToDto());
            }
            catch (Exception ex)
            {
                return new ResponseDTO(ResponseStatus.Error, ex.Message, null);
            }
        }

        public async Task<ResponseDTO> GetTimeEntries(Guid timeSheetId, DateTime? date, Guid? projectId)
        {
            try
            {
                var predicate = PredicateBuilder.New<TimeEntry>();

                predicate = predicate.And(timeEntry => timeEntry.TimesheetGuid == timeSheetId);

                if (date != null)
                {
                    predicate = predicate.And(timeEntry => timeEntry.Date == date);
                }
                
                if (projectId != null)
                {
                    predicate = predicate.And(timeEntry => timeEntry.ProjectId == projectId);
                }

                var timeEntries = await _timeEntryRepository.GetTimeEntries(predicate);

                return new ResponseDTO(ResponseStatus.Success, "List of Time Entry by timesheet, date, and project Id", timeEntries.Select(x => x.MapToDto()));
            }
            catch (Exception ex)
            {
                return new ResponseDTO(ResponseStatus.Error, ex.Message, null);
            }
        }

        public async Task<ResponseDTO> AddTimeEntry(Guid employeeId, TimeEntryDto timeEntryDto)
        {
            try
            {
                ResponseDTO timesheetResponse = await _timesheetService.GetTimeSheet(employeeId, timeEntryDto.Date);

                if (timesheetResponse.Ex != null)
                {
                    return timesheetResponse;
                }
                else if (timesheetResponse.Data != null)
                {
                    timeEntryDto.TimeSheetId = (timesheetResponse.Data as TimeSheetDto).Guid;
                    timeEntryDto.Guid = Guid.NewGuid();
                    timeEntryDto.Date = (DateTime)timeEntryDto.Date.Date;

                    var timeEntry = await _timeEntryRepository.AddTimeEntry(timeEntryDto.MapToModel());

                    return new ResponseDTO(ResponseStatus.Success, "Time Entry Added Successfully", timeEntryDto);
                }
                else
                {
                    timeEntryDto.Guid = Guid.NewGuid();
                    timeEntryDto.Date = (DateTime)timeEntryDto.Date.Date;
                    return await _timesheetService.AddTimeSheet(employeeId, timeEntryDto);
                }
            }
            catch (Exception ex)
            {
                return new ResponseDTO(ResponseStatus.Error, ex.Message, null);
            }
        }

        public async Task<ResponseDTO> UpdateTimeEntry(TimeEntryDto timeEntryDto)
        {
            try
            {
                ResponseDTO timeEntryResponse = await GetTimeEntryForUpdateOrDelete(timeEntryDto.Guid);

                if (timeEntryResponse.Ex != null)
                {
                    return timeEntryResponse;
                }
                else if (timeEntryResponse.Data != null)
                {
                    await _timeEntryRepository.UpdateTimeEntry(timeEntryDto.MapToModel());

                    return new ResponseDTO(ResponseStatus.Success, "TimeEntry updated successfully.", null);
                }
                else
                {
                    return new ResponseDTO(ResponseStatus.Info, "Can not update nonexistent TimeEntry", null);
                }
            }
            catch (Exception ex)
            {
                return new ResponseDTO(ResponseStatus.Error, ex.Message, null);
            }
        }
    }
}
