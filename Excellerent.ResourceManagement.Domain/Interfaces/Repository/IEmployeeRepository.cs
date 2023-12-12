using Excellerent.ResourceManagement.Domain.Models;
using Excellerent.SharedModules.Seed;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Excellerent.ResourceManagement.Domain.Interfaces.Repository
{
    public interface IEmployeeRepository : IAsyncRepository<Employee>
    {
        Task<Employee> CreateEmployeeAsync(Employee emp);
        Task<List<Employee>> GetEmployeesAsync();
        Task<Employee> UpdateEmployeeAsync(string id);
        Task<Employee> GetEmployeesByEmailAsync(string email);
    }
}
