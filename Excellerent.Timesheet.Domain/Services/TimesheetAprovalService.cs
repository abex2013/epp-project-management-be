using Excellerent.SharedModules.Services;
using Excellerent.Timesheet.Domain.Entities;
using Excellerent.Timesheet.Domain.Interfaces.Repository;
using Excellerent.Timesheet.Domain.Interfaces.Service;
using Excellerent.Timesheet.Domain.Mapping;
using Excellerent.Timesheet.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Excellerent.Timesheet.Domain.Services
{
    public class TimesheetAprovalService : CRUD<TimesheetAprovalEntity, TimesheetAproval>, ITimesheetAprovalService
    {
        private readonly ITimesheetAprovalRepository _repository;

        public TimesheetAprovalService(ITimesheetAprovalRepository repository) : base(repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<TimesheetAprovalDto>> GetTimesheetApprovalStatus(Guid tsGuid)
        {
            var result = _repository.FindAsync(x => x.TimesheetId == tsGuid).Result.ToList();
            return result.Select(x => x.MapToDto());
        }
    }
}
