using Excellerent.ProjectManagement.Domain.Models;
using Excellerent.SharedModules.Seed;
using System;

namespace Excellerent.ProjectManagement.Domain.Interfaces.RepositoryInterface
{
    public interface IProjectStatusRepository : IAsyncRepository<ProjectStatus>
    {
        public ProjectStatus GetProjectStatusById(Guid statusId);
    }
}
