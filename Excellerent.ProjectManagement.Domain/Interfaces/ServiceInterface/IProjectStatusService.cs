using Excellerent.ProjectManagement.Domain.Entities;
using Excellerent.ProjectManagement.Domain.Models;
using Excellerent.SharedModules.Interface.Service;
using System;

namespace Excellerent.ProjectManagement.Domain.Interfaces.ServiceInterface
{
    public interface IProjectStatusService : ICRUD<ProjectStatusEntity, ProjectStatus>

    {
        public ProjectStatus GetProjectStatusById(Guid id);
    }
}
