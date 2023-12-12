using Excellerent.SharedModules.DTO;
using Excellerent.SharedModules.Services;
using Excellerent.Timesheet.Domain.Dtos;
using Excellerent.Timesheet.Domain.Entities;
using Excellerent.Timesheet.Domain.Interfaces.Repository;
using Excellerent.Timesheet.Domain.Interfaces.Service;
using Excellerent.Timesheet.Domain.Mapping;
using Excellerent.Timesheet.Domain.Models;
using LinqKit;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Excellerent.Timesheet.Domain.Services
{
    public class TimeSheetService : CRUD<TimeSheetEntity, TimeSheet>, ITimeSheetService
    {
        private readonly ITimeSheetRepository _timeSheetRepository;
        private readonly ITimeEntryRepository _timeEntryRepository;


        public TimeSheetService(ITimeSheetRepository timeSheetRepository, ITimeEntryRepository timeEntryRepository) : base(timeSheetRepository)
        {
            _timeSheetRepository = timeSheetRepository;
            _timeEntryRepository = timeEntryRepository;
        }

        public async Task<IEnumerable<TimeSheetEntity>> GetTimeSheetByEmployee(Guid empId, DateTime fromDate)
        {
            var data = _timeSheetRepository.GetTimeSheetByEmployee(empId, fromDate);
            return (await data).ToList().Select(x => new TimeSheetEntity(x));
        }
        public async Task<TimeSheet> GetEmployeeLastSheet(Guid employeeId)
        {
            return await _timeSheetRepository.GetLastEmployeeSheet(employeeId);
        }
        public async Task<TimeSheet> NewSheet(Guid employeeId, TimeEntry entry)
        {
            TimeSheet timeSheet = GetNewTimeSheet(entry);
            timeSheet.EmployeeId = employeeId;
            timeSheet.TotalHours = entry.Hour;
            timeSheet.TimeEntry = new List<TimeEntry>();
            timeSheet.TimeEntry.Add(entry);
            return await _timeSheetRepository.AddAsync(timeSheet);

        }
        public TimeSheet GetNewTimeSheet(TimeEntry entry)
        {
            TimeSheet sheetEntity = new TimeSheet();
            int diff = (int)(entry.Date.DayOfWeek - 1);
            sheetEntity.FromDate = DateAndTime.DateAdd(DateInterval.Day, -diff, entry.Date);
            sheetEntity.ToDate = DateAndTime.DateAdd(DateInterval.Day, 6, sheetEntity.FromDate);
            return sheetEntity;
        }

        public async Task<TimeSheet> AddToExistingTimeSheet(TimeSheet timeSheet, TimeEntry timeEntry)
        {
            timeEntry.TimesheetGuid = timeSheet.Guid;
            timeSheet.TotalHours = GetSheetTotalHour(timeSheet);
            await _timeSheetRepository.UpdateAsync(timeSheet);
            return timeSheet;
        }
        public int GetSheetTotalHour(TimeSheet sheet)
        {
            return sheet.TimeEntry.Sum(x => x.Hour);
        }

        public async Task<int> GetTimeEntryTotalHour(TimeSheet timeSheet) 
        {
            var predicate = PredicateBuilder.New<TimeEntry>();

            predicate = predicate.And(timeEntry => timeEntry.TimesheetGuid == timeSheet.Guid);

            var timeEntries = await _timeEntryRepository.FindAsync(predicate);

            return timeEntries.Sum(timeEntry => timeEntry.Hour);
        }

        public async Task<TimeSheet> GetLastSheet(Guid employeeId)
        {

            return await _timeSheetRepository.GetLastEmployeeSheet(employeeId);
        }

        public async Task<TimeSheet> GetSheetForDay(TimeEntry entryEntity, Guid employeeId)
        {
            TimeSheet sheet = GetNewTimeSheet(entryEntity);
            var oldSheet = await _timeSheetRepository.FindOneAsync((x => x.FromDate.Date == sheet.FromDate.Date && x.ToDate.Date == sheet.ToDate.Date && x.EmployeeId == employeeId));
            if (oldSheet == null)
            {
                return sheet;
            }
            return oldSheet;
        }

        public async Task<ResponseDTO> GetTimeSheet(Guid id)
        {
            try
            {
                var predicate = PredicateBuilder.New<TimeSheet>();

                predicate = predicate.And(timeSheet => timeSheet.Guid == id);

                var timeSheet = await _timeSheetRepository.GetTimeSheet(predicate);

                return new ResponseDTO(ResponseStatus.Success, "Time Shee by Id", timeSheet?.MapToDto());
            }
            catch (Exception ex)
            {
                return new ResponseDTO(ResponseStatus.Error, ex.Message, null);
            }
        }
        public async Task<ResponseDTO> GetTimeSheet(Guid employeeId, DateTime? dateTime)
        {
            DateTime localDateTime = dateTime ?? DateTime.Now;
            localDateTime = (DateTime)localDateTime.Date;

            DateTime fromDate = localDateTime.AddDays((-1 * (int)localDateTime.DayOfWeek) + 1);
            DateTime toDate = fromDate.AddDays(6);

            return await GetTimeSheet(employeeId, fromDate, toDate);
        }
        public async Task<ResponseDTO> GetTimeSheet(Guid employeeId, DateTime fromDate, DateTime toDate)
        {
            try
            {
                var predicate = PredicateBuilder.New<TimeSheet>();

                predicate = predicate.And(timeSheet => timeSheet.EmployeeId == employeeId)
                    .And(timeSheet => timeSheet.FromDate == fromDate)
                    .And(timeSheet => timeSheet.ToDate == toDate);

                var timeSheet = await _timeSheetRepository.GetTimeSheet(predicate);

                return new ResponseDTO(ResponseStatus.Success, "Time Sheet by employee Id, from Date, and to Date", timeSheet?.MapToDto());
            }
            catch (Exception ex)
            {
                return new ResponseDTO(ResponseStatus.Error, ex.Message, null);
            }
        }

        public async Task<ResponseDTO> AddTimeSheet(Guid employeeId, TimeEntryDto timeEntryDto)
        {
            TimeSheetDto timeSheetDto = new TimeSheetDto();
            DateTime localDateTime = (DateTime)timeEntryDto.Date.Date;
            DateTime fromDate = localDateTime.AddDays((-1 * (int)localDateTime.DayOfWeek) + 1);
            DateTime toDate = fromDate.AddDays(6);

            timeSheetDto.Guid = Guid.NewGuid();
            timeSheetDto.FromDate = fromDate;
            timeSheetDto.ToDate = toDate;
            timeSheetDto.TotalHours = 0;
            timeSheetDto.Status = 0;
            timeSheetDto.EmployeeId = employeeId;

            return await AddTimeSheet(timeSheetDto, timeEntryDto);
        }
        public async Task<ResponseDTO> AddTimeSheet(TimeSheetDto timeSheetDto, TimeEntryDto timeEntryDto)
        {
            try
            {
                var timeSheet = await _timeSheetRepository.AddTimeSheet(timeSheetDto.MapToModel(timeEntryDto));

                return new ResponseDTO(ResponseStatus.Success, "Timesheet Added Successfully", timeSheet?.MapToDto());
            }
            catch (Exception ex)
            {
                return new ResponseDTO(ResponseStatus.Error, ex.Message, null);
            }
        }

        public async Task<TimeSheet> GetTimesheetForEntryDate(TimeEntry entry, Guid employeeId)
        {
            TimeSheet timeSheet = GetNewTimeSheet(entry);
            var sheet = await _timeSheetRepository.GetTimesheetForEntryDate(timeSheet, employeeId, entry);
            if (sheet != null && sheet.TimeEntry.Any())
            {
                timeSheet.TotalHours = GetSheetTotalHour(sheet);
            }
            return timeSheet;
        }

        public async Task<TimeSheet> GetSheetById(Guid id)
        {
            return await _timeSheetRepository.GetByGuidAsync(id);
        }
        public async Task<TimeSheetEntity> UpdateTimesheet(TimeSheetEntity timeSheet)
        {
            await _timeSheetRepository.UpdateAsync(timeSheet.MapToModel());
            return timeSheet;
        }
    }   
}
