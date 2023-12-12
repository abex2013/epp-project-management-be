using System;

namespace Excellerent.Timesheet.Presentation.Models
{
    public class TimeEntryVm
    {
        public string Note { get; set; }
        public DateTime Date { get; set; }
        public int Index { get; set; }
        public int Hour { get; set; }
        public Guid ProjectId { get; set; }
    }
}
