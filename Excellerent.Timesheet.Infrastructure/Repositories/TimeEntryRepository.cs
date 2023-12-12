using Excellerent.SharedInfrastructure.Context;
using Excellerent.SharedInfrastructure.Repository;
using Excellerent.Timesheet.Domain.Interfaces.Repository;
using Excellerent.Timesheet.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Excellerent.Timesheet.Infrastructure.Repositories
{
    public class TimeEntryRepository : AsyncRepository<TimeEntry>, ITimeEntryRepository
    {
        private readonly EPPContext _context;
        public TimeEntryRepository(EPPContext context) : base(context)
        {
            _context = context;
        }

        public async Task<TimeSheet> GetSheetForADay(Guid employeeId, TimeEntry entry)
        {
            return (TimeSheet)_context.TimeSheets.Where(x => x.EmployeeId == employeeId).OrderBy(x => x.ToDate).Include(x => x.TimeEntry.Where(c => c.Date.Date == entry.Date.Date).ToList());
        }

        public async Task<TimeEntry> GetTimeEntry(Expression<Func<TimeEntry, bool>> predicate)
        {
            return await FindOneAsync(predicate);
        }

        public async Task<TimeEntry> GetTimeEntryForUpdateOrDelete(Expression<Func<TimeEntry, bool>> predicate)
        {
            return await FindOneAsyncForDelete(predicate);
        }

        public async Task<IEnumerable<TimeEntry>> GetTimeEntries(Expression<Func<TimeEntry, bool>> predicate)
        {
            return await FindAsync(predicate);
        }

        public async Task<TimeEntry> AddTimeEntry(TimeEntry timeEntry)
        {
            return await AddAsync(timeEntry);
        }

        public async Task UpdateTimeEntry(TimeEntry timeEntry)
        {
            await UpdateAsync(timeEntry);
        }
        public async Task<IQueryable<TimeEntry>> GetEntryByTimeSheetGuid(Guid tsGuid)
        {
            //var data = _context.TimeEntry.AsQueryable();
            //IQueryable<TimeEntry> query = new TimeEntry();
            var result = _context.TimeEntry.Where(x => x.TimesheetGuid == tsGuid);


            //  var result = data.Where(x => x.TimesheetGuid == tsGuid);

            //return result.AsQueryable();
            return result;
        }

    }
}
