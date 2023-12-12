using Excellerent.ResourceManagement.Domain.Entities;
using Excellerent.ResourceManagement.Domain.Interfaces.Repository;
using Excellerent.ResourceManagement.Domain.Interfaces.Services;
using Excellerent.ResourceManagement.Domain.Models;


using Excellerent.SharedModules.Services;

using System.Collections.Generic;

using System.Threading.Tasks;

namespace Excellerent.ResourceManagement.Domain.Services
{
    public class EmployeeService : CRUD<EmployeeEntity, Employee>, IEmployeeService
    {
        IEmployeeRepository _employeeRepository;


        public EmployeeService(IEmployeeRepository employeeRepository) : base(employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<Employee> AddNewEmployeeEntry(Employee employee)
        {
            return await _employeeRepository.AddAsync(employee);

        }

        public async Task<List<Employee>> GetAllEmployeesAsync()
        {
            return await _employeeRepository.GetEmployeesAsync();
        }

        public async Task<Employee> GetEmployeesByEmailAsync(string email)
        {
            return await _employeeRepository.GetEmployeesByEmailAsync(email);
        }
        public async Task<bool> CheckIfEmailExists(string email)
        {
            bool returnresult = false;
            var result = await GetEmployeesByEmailAsync(email);
            if (result == null)
            {
                returnresult = true;
            }
            else
            {
                returnresult = false;
            }
            return  returnresult;
        }

    }
}
