using Excellerent.Timesheet.Domain.Models;
using System.Collections.Generic;

namespace Excellerent.Timesheet.Domain.Interfaces.Service
{
    public interface IProjectMockService
    {
        List<ProjectMock> GetProject(int? id);
        List<ProjectMock> GetProjectByClient(int id);
    }
}
