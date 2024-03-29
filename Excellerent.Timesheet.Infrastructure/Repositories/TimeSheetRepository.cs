﻿using Excellerent.SharedInfrastructure.Context;
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
    public class TimeSheetRepository : AsyncRepository<TimeSheet>, ITimeSheetRepository
    {
        private readonly EPPContext _context;
        public TimeSheetRepository(EPPContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TimeSheet>> GetTimeSheetByEmployee(Guid empId, DateTime fromDate)
        {
            return await _context.TimeSheets.Where(x => x.EmployeeId == empId && x.FromDate == fromDate).Include(x => x.TimeEntry).ToListAsync();
        }
        public async Task<TimeSheet> GetLastEmployeeSheet(Guid employeeId)
        {
            return _context.TimeSheets.Where(x => x.EmployeeId == employeeId).OrderBy(x => x.ToDate).Include(x => x.TimeEntry).LastOrDefault();
        }

        public async Task<TimeSheet> GetTimeSheet(Expression<Func<TimeSheet, bool>> predicate)
        {
            return await FindOneAsync(predicate);
        }

        public async Task<TimeSheet> AddTimeSheet(TimeSheet timesheet)
        {
            return await AddAsync(timesheet);
        }
        public async Task<TimeSheet> GetTimesheetForEntryDate(TimeSheet timeSheet, Guid employeeId, TimeEntry entry)
        {
            var sheetId = _context.TimeSheets.Where(s => s.FromDate.Date == timeSheet.FromDate.Date && s.EmployeeId == employeeId).OrderBy(x => x.ToDate).FirstOrDefault();
            var sheet = new TimeSheet();
            if (sheetId != null)
            {
                sheet.TimeEntry.AddRange(_context.TimeEntry.Where(T => T.TimesheetGuid == sheetId.Guid && T.Date.Date == entry.Date.Date));
            }
            return sheet;
        }
    }
}
