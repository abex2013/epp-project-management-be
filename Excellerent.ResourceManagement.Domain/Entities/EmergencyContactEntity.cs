using Excellerent.ResourceManagement.Domain.Models;
using Excellerent.SharedModules.Seed;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Excellerent.ResourceManagement.Domain.Entities
{
    public class EmergencyContactEntity : BaseEntity<EmergencyContact>
    {
        public string FirstName { get; set; }
        public string FatherName { get; set; }
        public string Relationship { get; set; }
        public int EmployeeId { get; set; }
        public List<EmergencyAddressEntity> Address { get; set; } = new List<EmergencyAddressEntity>();




        public EmergencyContactEntity(EmergencyContact m) : base(m)
        {
            CreatedDate = m.CreatedDate;
            FirstName = m.FirstName;
            FatherName = m.FatherName;
            Relationship = m.Relationship;
            EmployeeId = m.EmployeeId;
            //Address = (IReadOnlyList<EmergencyAddressEntity>)m.Address;
            Address = m.Address.Select(x => new EmergencyAddressEntity()).ToList();



        }



        public override EmergencyContact MapToModel()
        {
            EmergencyContact econtact = new EmergencyContact();
            econtact.CreatedDate = CreatedDate;
            econtact.FirstName = FirstName;
            econtact.FatherName = FatherName;
            econtact.Relationship = Relationship;
            econtact.EmployeeId = EmployeeId;
            econtact.Address = Address?.Select(x => x.MapToModel()).ToList();
            return econtact;

        }

        public override EmergencyContact MapToModel(EmergencyContact t)
        {
            t.CreatedDate = CreatedDate;
            t.FirstName = FirstName;
            t.FatherName = FatherName;
            t.Relationship = Relationship;
            t.EmployeeId = EmployeeId;
            t.Address = Address?.Select(x => x.MapToModel()).ToList();
            return t;
        }

        public EmergencyContactEntity()
        {

        }

        public EmergencyContactEntity(int employeeId, string firstName, string fatherName, string relationship)
        {
            FirstName = firstName;
            FatherName = fatherName;
            EmployeeId = employeeId;
            Relationship = relationship;
         
        }

        public EmergencyContactEntity(EmergencyContactEntity entity)
        {
        }
    }
}
