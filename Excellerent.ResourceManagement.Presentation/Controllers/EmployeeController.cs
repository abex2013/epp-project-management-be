
using Excellerent.ResourceManagement.Domain.Entities;
using Excellerent.ResourceManagement.Domain.Interfaces.Services;
using Excellerent.ResourceManagement.Domain.Models;
using Excellerent.SharedModules.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace Excellerent.ResourceManagement.Presentation.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
  
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        public async Task<ResponseDTO> Get()
        {
            return new ResponseDTO(ResponseStatus.Success,"Entry Succesfull",await _employeeService.GetAllEmployeesAsync());
        }
        [HttpPost]
        public async Task<ResponseDTO> Post(EmployeeEntity employee)
        {
            if (await _employeeService.CheckIfEmailExists(employee.PersonalEmail))
            {
                return new ResponseDTO(ResponseStatus.Success, "Entry Succesfull", await _employeeService.AddNewEmployeeEntry(employee.MapToModel()));
            }
            else 
            {
                return new ResponseDTO(ResponseStatus.Error, "There is already registered employee with the email you provided",employee);
            }
        }
    }
}
