using Excellerent.Timesheet.Domain.Interfaces.Service;
using Excellerent.Timesheet.Domain.Models;
using System.Collections.Generic;
using System.Linq;

namespace Excellerent.Timesheet.Domain.Services
{
    public class ProjectMockService : IProjectMockService
    {
        private readonly List<ProjectMock> _project;
        public ProjectMockService()
        {
            _project = new List<ProjectMock>();
            _project.AddRange(
                new List<ProjectMock>
                {
                    new ProjectMock {
                        Name = "E-Commerce",
                        ClientId = 1,
                        Id = 1,
                    },
                    new ProjectMock {
                        Name = "Epp",
                        ClientId = 2,
                        Id = 2,
                    },
                    new ProjectMock {
                        Name = "Connect Plus",
                        ClientId = 1,
                        Id = 3,
                    }
                });
        }
        public List<ProjectMock> GetProject(int? id)
        {
            return id == null ? _project : _project.Where(x => x.Id == id).ToList();
        }

        public List<ProjectMock> GetProjectByClient(int id)
        {
            return _project.Where(x => x.ClientId == id).ToList();
        }
    }
}
