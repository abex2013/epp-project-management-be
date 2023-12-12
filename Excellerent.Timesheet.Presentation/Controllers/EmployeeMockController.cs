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
    public class EmployeeMockController : ControllerBase
    {
        private readonly IEmployeeMockService _employeeService;

        public EmployeeMockController(IEmployeeMockService employeeService)
        {
            _employeeService = employeeService;
        }
        [HttpGet]
        public List<EmployeeMock> Get(int? id)
        {
            return _employeeService.GetEmployee(id);
        }
    }
}
