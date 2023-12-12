using Excellerent.SharedModules.Seed;
using Excellerent.Timesheet.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Excellerent.Timesheet.Domain.Interfaces.Repository
{
    public interface ITimeSheetRepository : IAsyncRepository<TimeSheet>
    {
        Task<IEnumerable<TimeSheet>> GetTimeSheetByEmployee(Guid empId, DateTime fromDate);
        Task<TimeSheet> GetLastEmployeeSheet(Guid employeeId);
        Task<TimeSheet> GetTimeSheet(Expression<Func<TimeSheet, bool>> predicate);

        Task<TimeSheet> AddTimeSheet(TimeSheet timesheet);
        Task<TimeSheet> GetTimesheetForEntryDate(TimeSheet timesheet, Guid employeeId, TimeEntry entry);
    }
}
