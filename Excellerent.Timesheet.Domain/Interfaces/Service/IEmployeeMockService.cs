using Excellerent.Timesheet.Domain.Models;
using System.Collections.Generic;

namespace Excellerent.Timesheet.Domain.Interfaces.Service
{
    public interface IEmployeeMockService
    {
        List<EmployeeMock> GetEmployee(int? id);
    }
}
