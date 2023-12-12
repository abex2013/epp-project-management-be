using Excellerent.SharedModules.Seed;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Excellerent.ResourceManagement.Domain.Models
{
    public class EmergencyContact : BaseAuditModel
    {
        [Required]
        [RegularExpression(@"^[a-zA-Z\s]*$", ErrorMessage ="First Name must string with no space!")]
        [StringLength(25, ErrorMessage = "First Name length can't be more than 25")]
        [Display(Name = "First Name")]
        //MinimumLength = 3,
        public string FirstName { get; set; }
        [Required]
        [RegularExpression(@"^[a-zA-Z\s]*$", ErrorMessage = "Father Name must string with no space!")]
        [StringLength(25, ErrorMessage = " Father Name length can't be more than 25")]
        [Display(Name = "Father Name")]
        public string FatherName { get; set; }
        [RegularExpression(@"^[a-zA-Z\s]*$", ErrorMessage = "Relationship Name must string with no space!")]
        [StringLength(25, ErrorMessage = "Relationship length can't be more than 25 ")]
        public string Relationship { get; set; }
        [Required]
        public int EmployeeId { get; set; }

        public List<EmergencyAddress> Address { get; set; } = new List<EmergencyAddress>();

        public EmergencyContact(string firstName, string fatherName, string relationship, int employeeId)
        {
            FirstName = firstName;
            FatherName = fatherName;
            Relationship = relationship;
            EmployeeId = employeeId;
        }

        public EmergencyContact()
        {
        }
    }
}
