using Excellerent.Timesheet.Domain.Entities;
using System;
using System.Collections.Generic;

namespace Excellerent.Timesheet.Presentation.Models
{
    public class TimeSheetVm : BaseModel
    {
        public TimeSheetVm()
        {
            TimeEntry = new List<TimeEntryVm>();
        }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public int? TotalHours { get; set; }
        public int Status { get; set; }
        public Guid EmployeeId { get; set; }
        public List<TimeEntryVm> TimeEntry { get; set; }
        public override T MapToEntity<T>()
        {
            TimeSheetEntity timeSheetEntity = new TimeSheetEntity();
            timeSheetEntity.FromDate = FromDate;
            timeSheetEntity.ToDate = ToDate;
            timeSheetEntity.TotalHours = TotalHours;
            timeSheetEntity.Status = Status;
            timeSheetEntity.EmployeeId = EmployeeId;
            return timeSheetEntity as T;
        }
    }
}
