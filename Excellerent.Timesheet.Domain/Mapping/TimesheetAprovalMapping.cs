using Excellerent.Timesheet.Domain.Models;

namespace Excellerent.Timesheet.Domain.Mapping
{
    public static class TimesheetAprovalMapping
    {
        public static TimesheetAproval MapToModel(this TimesheetAprovalDto timesheetAprovalDto)
        {
            TimesheetAproval timesheetAproval = new TimesheetAproval();

            timesheetAproval.TimesheetId = timesheetAprovalDto.TimesheetId;
            timesheetAproval.ProjectId = timesheetAprovalDto.ProjectId;
            timesheetAproval.Status = timesheetAprovalDto.Status;
            return timesheetAproval;
        }
        public static TimesheetAprovalDto MapToDto(this TimesheetAproval timesheetAproval)
        {
            TimesheetAprovalDto timesheetAprovalDto = new TimesheetAprovalDto();

            timesheetAprovalDto.TimesheetId = timesheetAproval.TimesheetId;
            timesheetAprovalDto.ProjectId = timesheetAproval.ProjectId;
            timesheetAprovalDto.Status = timesheetAprovalDto.Status;

            return timesheetAprovalDto;
        }
    }

}
