using Excellerent.ResourceManagement.Domain.Entities;
using Excellerent.ResourceManagement.Domain.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Excellerent.ResourceManagement.Infrastructure.Dtos
{
    public class EmergencyContactDto
    {
        [Required ]
        //[Display("First Name")]
        public string FirstName { get; set; }
        [Required]
        public string FatherName { get; set; }
      
        public string Relationship { get; set; }
        [Required]
        public int EmployeeId { get; set; }
        [Required]
        public List<EmergencyAddress> Address { get; set; }

        public EmergencyContactDto(string firstName, string fatherName, string relationship, int employeeId, List<EmergencyAddress> address)
        {
            FirstName = firstName;
            FatherName = fatherName;
            Relationship = relationship;
            EmployeeId = employeeId;
            Address = address;
        }

        public EmergencyContactDto()
        {

        }

        public EmergencyContactDto(EmergencyContactDto dto)
        {

        }

    }
}
