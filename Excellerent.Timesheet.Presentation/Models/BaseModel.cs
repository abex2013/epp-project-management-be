using System;

namespace Excellerent.Timesheet.Presentation.Models
{
    public abstract class BaseModel
    {
        public Guid? Id { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? CreatedDate { get; set; }
        public abstract T MapToEntity<T>() where T : class;
    }
}
