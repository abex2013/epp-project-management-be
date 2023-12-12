using Excellerent.APIModularization.Controllers;
using Excellerent.APIModularization.Logging;
using Excellerent.SharedModules.DTO;
using Excellerent.Timesheet.Domain.Dtos;
using Excellerent.Timesheet.Domain.Entities;
using Excellerent.Timesheet.Domain.Interfaces.Service;
using Excellerent.Timesheet.Domain.Mapping;
using Excellerent.Timesheet.Domain.Models;
using Excellerent.Timesheet.Presentation.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Excellerent.Timesheet.Presentation.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [Authorize]
    public class TimeSheetController : AuthorizedController
    {
        private readonly ITimeSheetService _timeSheetService;
        private readonly ITimeEntryService _timeEntryService;
        private readonly ITimeEntryValidation _validate;
        private readonly ITimesheetAprovalService _timesheetAprovalService;
        private readonly string _feature = "Timesheet";

        public TimeSheetController(IHttpContextAccessor htttpContextAccessor, IConfiguration configuration, IBusinessLog _businessLog, ITimeSheetService timeSheetService, ITimeEntryService timeEntryService, ITimeEntryValidation validate, ITimesheetAprovalService timesheetAprovalService) : base(htttpContextAccessor, configuration, _businessLog, "Timesheet")
        {
            _timeSheetService = timeSheetService;
            _timeEntryService = timeEntryService;
            _validate = validate;
            _timesheetAprovalService = timesheetAprovalService;
        }

        [HttpGet("TimeSheetByEmployee/{id?}")]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<TimeSheetVm>>> GetTimeSheetByEmployee(Guid id, DateTime fromDate)
        {
            try
            {
                var result = await _timeSheetService.GetTimeSheetByEmployee(id, fromDate);
                return Ok(result);
            }
            catch (Exception)
            {
                return NoContent();
            }
        }

        /*
        [HttpPost("TimeEntries")]
        [AllowAnonymous]
        public async Task<ResponseDTO> NewTimeEntry([FromBody]TimeEntryDto entry, [FromQuery]Guid employeeId)
        {
            //return _validate.IsEntryValid(entry, employeeId).ResponseStatus == ResponseStatus.Success ? new ResponseDTO(ResponseStatus.Success, "Entry Successful", await _timeEntryService.NewEntry(entry, employeeId)) : _validate.IsEntryValid(entry, employeeId);

            if (entry.Date.Date > DateTime.Today) 
            {
                return new ResponseDTO(ResponseStatus.Error, "Cannot log time for future date.", entry);
            }

            if ((await _timeSheetService.GetTimeEntryTotalHour(_timeSheetService.GetSheetForDay(entry.MapToModel(), employeeId).Result)) + entry.Hour > 24) 
            {
                return new ResponseDTO(ResponseStatus.Error, "Cannot log time more than 24 hrs for a day.", entry);
            }

            TimeEntry timeEntry = await _timeEntryService.NewEntry(entry.MapToModel(), employeeId);

            return new ResponseDTO(ResponseStatus.Success, "Entry successful.", timeEntry.MapToDto());
        }
        //*/
        #region Time Entry

        [AllowAnonymous]
        [HttpGet("TimeEntries/{id}")]
        public Task<ResponseDTO> GetTimeEntry(Guid id)
        {
            return _timeEntryService.GetTimeEntry(id);
        }

        [AllowAnonymous]
        [HttpGet("TimeEntries")]
        public Task<ResponseDTO> GetTimeEntries(Guid timeSheetId, DateTime? date, Guid? projectId)
        {
            return _timeEntryService.GetTimeEntries(timeSheetId, date, projectId);
        }
        
        [AllowAnonymous]
        [HttpPost("TimeEntries")]
        public Task<ResponseDTO> AddTimeEntry([FromQuery]Guid employeeId, [FromBody]TimeEntryDto timeEntryDto)
        {
            return _timeEntryService.AddTimeEntry(employeeId, timeEntryDto);
        }
        //*/

        [AllowAnonymous]
        [HttpPut("TimeEntries")]
        public Task<ResponseDTO> UpdateTimeEntry(TimeEntryDto timeEntryDto)
        {
            return _timeEntryService.UpdateTimeEntry(timeEntryDto);
        }           

        #endregion

        #region Timesheet

        [AllowAnonymous]
        [HttpGet("Timesheets/{id}")]
        public Task<ResponseDTO> GetTimesheet(Guid id)
        {
            return _timeSheetService.GetTimeSheet(id);
        }

        [AllowAnonymous]
        [HttpGet("Timesheets")]
        public Task<ResponseDTO> GetTimesheet(Guid employeeId, DateTime? date)
        {
            return _timeSheetService.GetTimeSheet(employeeId, date);
        }
        [HttpGet("GetTimesheetById")]
        [AllowAnonymous]
        public async Task<ResponseDTO> GetTimesheetById(Guid Id)
        {
            return new ResponseDTO(ResponseStatus.Success, "", await _timeEntryService.GetTimesheetByTimesheetId(Id));
        }
        [HttpPut("UpdateTimesheet")]
        [AllowAnonymous]
        public async Task<ResponseDTO> UpdateTimesheet(TimeSheetEntity timeSheet)
        {
            return new ResponseDTO(ResponseStatus.Success, "Update Successful.", await _timeSheetService.UpdateTimesheet(timeSheet));
        }

        #endregion
        [HttpPost("TimesheetAproval")]
        [AllowAnonymous]
        public async Task<ResponseDTO> Approve(Guid timesheetGuid)
        {
            try
            {
                var  timeEntry = await _timeEntryService.ApproveTimeSheet(timesheetGuid);
                return new ResponseDTO(ResponseStatus.Success, "Timesheet Successfully Submited for Approval.", timeEntry);
            }
            catch (Exception)
            {
                return new ResponseDTO(ResponseStatus.Error, "No Timesheet found for Timesheet Id: ", timesheetGuid);
            }
        }

        [HttpGet("GetTimesheetAprovalStatus")]
        [AllowAnonymous]
        public async Task<ResponseDTO> GetApprovalStatus(Guid timesheetGuid)
        {
            try
            {
                var timeEntry = await _timesheetAprovalService.GetTimesheetApprovalStatus(timesheetGuid);
                return new ResponseDTO(ResponseStatus.Success, null, timeEntry);
            }
            catch (Exception)
            {
                return new ResponseDTO(ResponseStatus.Error, "No Timesheet found for Timesheet Id: ", timesheetGuid);
            }
        }
    }
}
