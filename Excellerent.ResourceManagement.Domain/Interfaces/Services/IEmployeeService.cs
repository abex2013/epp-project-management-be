using Excellerent.ResourceManagement.Domain.Entities;
using Excellerent.ResourceManagement.Domain.Models;
using Excellerent.SharedModules.Interface.Service;

using System.Collections.Generic;

using System.Threading.Tasks;

namespace Excellerent.ResourceManagement.Domain.Interfaces.Services
{
    public interface IEmployeeService : ICRUD<EmployeeEntity, Employee>
    {
        Task<List<Employee>> GetAllEmployeesAsync();
        Task<Employee> GetEmployeesByEmailAsync(string email);
        Task<Employee> AddNewEmployeeEntry(Employee employee);
        Task<bool> CheckIfEmailExists(string email);

    }
}
