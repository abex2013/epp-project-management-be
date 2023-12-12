using Excellerent.Timesheet.Domain.Interfaces.Service;
using Excellerent.Timesheet.Domain.Models;
using System.Collections.Generic;
using System.Linq;

namespace Excellerent.Timesheet.Domain.Services
{
    public class ClientMockService : IClientMockService
    {
        private readonly List<ClientMock> _client;
        private readonly IProjectMockService _projectService;

        public ClientMockService(IProjectMockService projectService)
        {
            _projectService = projectService;

            _client = new List<ClientMock>();
            _client.AddRange(
                new List<ClientMock>
                {
                    new ClientMock {
                        Id = 1,
                        Name = "Security Finance Corporation (SFC)",
                        Pojects = _projectService.GetProjectByClient(1)

                    },
                    new ClientMock {
                        Id = 2,
                        Name = "Exellerent Solutions",
                        Pojects = _projectService.GetProjectByClient(2)

                    },
                    new ClientMock {
                        Id = 3,
                        Name = "RedZone",
                    },

                });
        }
        public List<ClientMock> GetClient(int? id)
        {
            return id == null ? _client : _client.Where(x => x.Id == id).ToList();
        }
    }
}
