using Excellerent.Timesheet.Domain.Interfaces.Service;
using Excellerent.Timesheet.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Excellerent.Timesheet.Presentation.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ProjectMockController : ControllerBase
    {
        private readonly IProjectMockService _projectMockService;

        public ProjectMockController(IProjectMockService projectMockService)
        {
            _projectMockService = projectMockService;
        }

        [HttpGet]
        public List<ProjectMock> Get(int? id)
        {
            return _projectMockService.GetProject(id);
        }
        [HttpGet("ByClient")]
        public List<ProjectMock> GetByClient(int id)
        {
            return _projectMockService.GetProjectByClient(id);
        }
    }
}
