using Excellerent.SharedModules.Seed;
using System;

namespace Excellerent.ProjectManagement.Domain.Models
{
    public class Employee : BaseAuditModel
    {
        public string Name { get; set; }
        public string Role { get; set; }
        public DateTime HiredDate { get; set; }

        public Employee(Employee employee)
        {
            Name = employee.Name;
            Role = employee.Role;
            HiredDate = employee.HiredDate;
        }
        public Employee()
        {

        }
        public Employee(Guid guid,string name,string role, DateTime hiredDate)
        {
            Guid = guid;
            Name = name;
            Role = role;
            HiredDate = hiredDate;

        }
    }
}
