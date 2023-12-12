using Excellerent.ResourceManagement.Domain.Models;
using Excellerent.SharedModules.Seed;
using System;
using System.Collections.Generic;

namespace Excellerent.ResourceManagement.Domain.Entities
{
    public class EmployeeEntity : BaseEntity<Employee>
    {
        public EmployeeEntity()
        {

        }

        public string FirstName
        {
            get; set;
        }
        public string FatherName
        {
            get; set;
        }
        public string GrandfatherName
        {
            get; set;
        }
        public string MobilePhone
        {
            get; set;
        }
        public string Phone1
        {
            get; set;
        }
        public string Phone2
        {
            get; set;
        }
        public string PersonalEmail
        {
            get; set;
        }

        public string PersonalEmail2
        {
            get; set;
        }

        public string PersonalEmail3
        {
            get; set;
        }
        public DateTime DateofBirth
        {
            get; set;
        }
        public string Gender
        {
            get; set;
        }
        public List<Nationality> Nationality { get; set; }
        public string Photo { get; set; }

        public List<EmergencyContact> EmergencyContact { get; set; }
        public List<FamilyDetails> FamilyDetails { get; set; }
        public EmployeeOrganization EmployeeOrganization { get; set; }

        public List<PersonalAddress> EmployeeAddress { get; set; }

        public override Employee MapToModel()
        {
            Employee employee = new Employee();
            employee.FirstName = FirstName;
            employee.FatherName = FatherName;
            employee.GrandfatherName = GrandfatherName;
            employee.MobilePhone = MobilePhone;
            employee.Phone1 = Phone1;
            employee.Phone2 = Phone2;
            employee.PersonalEmail = PersonalEmail;
            employee.PersonalEmail2 = PersonalEmail2;
            employee.PersonalEmail3 = PersonalEmail3;
            employee.DateofBirth = DateofBirth;
            employee.Gender = Gender;
            employee.Nationality = Nationality;
            employee.Photo = Photo;
            employee.EmergencyContact = EmergencyContact;
            employee.FamilyDetails = FamilyDetails;
            employee.EmployeeOrganization = EmployeeOrganization;
            employee.EmployeeAddress = EmployeeAddress;

            return employee;
        }

        public override Employee MapToModel(Employee t)
        {
            //what was the point of this ? 
            Employee employee = t;
            return employee;
        }
    }
}
