using Excellerent.ResourceManagement.Domain.Entities;
using Excellerent.ResourceManagement.Domain.Models;
using Excellerent.ResourceManagement.Infrastructure.Dtos;
using System.Collections.Generic;
using System.Linq;

namespace Excellerent.ResourceManagement.Infrastructure.Mapping
{
    public  static class EmergenecyContactMapping
    {

        public static EmergencyContactDto ToDto(this EmergencyContact entity)
        {    
          return new EmergencyContactDto
        {
            FirstName = entity.FirstName,
            FatherName = entity.FatherName,
            Relationship = entity.Relationship,
            EmployeeId = entity.EmployeeId,
            Address = entity.Address?.Select(x => new EmergencyAddress()).ToList(),

            };
    }
        public static EmergencyContact ToEntity(this EmergencyContactDto dto)
        {
            return new EmergencyContact
            {
                FirstName = dto.FirstName,
                FatherName = dto.FatherName,
                Relationship = dto.Relationship,
                EmployeeId = dto.EmployeeId,
                Address = dto.Address?.Select(model=> new EmergencyAddress()).ToList(),

            };
        }
    }
}
