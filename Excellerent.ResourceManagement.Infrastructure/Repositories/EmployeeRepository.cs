using Excellerent.ResourceManagement.Domain.Interfaces.Repository;
using Excellerent.ResourceManagement.Domain.Models;
using Excellerent.SharedInfrastructure.Context;
using Excellerent.SharedInfrastructure.Repository;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Linq;

namespace Excellerent.ResourceManagement.Infrastructure.Repositories
{
    public class EmployeeRepository : AsyncRepository<Employee>, IEmployeeRepository
    {
        private readonly EPPContext _context;

        public EmployeeRepository(EPPContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Employee> CreateEmployeeAsync(Employee emp)
        {
            await _context.Employees.AddAsync(emp);
            _context.SaveChanges();
            return emp;
        
        }

        public async  Task<List<Employee>> GetEmployeesAsync()
        {

            return await _context.Employees.Include(nationalities => nationalities.Nationality)
                .Include(personaladdress => personaladdress.EmployeeAddress).Include(emergencycontact => emergencycontact.EmergencyContact)
                .Include(familydetail => familydetail.FamilyDetails).Include(employeeorganization => employeeorganization.EmployeeOrganization)
                .ToListAsync();
        }

        public async Task<Employee> GetEmployeesByEmailAsync(string email)
        {
            var result =  await _context.Employees.Where(x => x.PersonalEmail == email).FirstOrDefaultAsync();
            if (result == null) 
            {
                result = await _context.Employees.Where(x => x.PersonalEmail2 == email).FirstOrDefaultAsync();
            }
            if (result == null) 
            {
                result = await _context.Employees.Where(x => x.PersonalEmail3 == email).FirstOrDefaultAsync();
            }
            return result;
        }

       

        public Task<IReadOnlyList<Employee>> GetEmployeesByNameAsync(string Name)
        {
            throw new NotImplementedException();
        }

        public Task<Employee> UpdateEmployeeAsync(string id)
        {
            throw new NotImplementedException();
        }
    }
}
