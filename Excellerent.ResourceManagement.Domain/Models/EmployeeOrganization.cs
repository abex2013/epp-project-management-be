using System;
using System.ComponentModel.DataAnnotations.Schema;
using Excellerent.SharedModules.Seed;
using System.ComponentModel.DataAnnotations;


namespace Excellerent.ResourceManagement.Domain.Models
{
    public class EmployeeOrganization : BaseAuditModel
    {
        [Required]
        public int DutyStation { get; set; }

        [Required]
        public int DutyBranch { get; set; }
        [ForeignKey("Employees")]
        public Guid EmployeeId { get; set; }

        [Required]
        [EmailAddress]
        public string CompaynEmail { get; set; }

        [Required]
        [Phone]
        public string PhoneNumber { get; set; }

        [Required]
        public DateTime JoiningDate { get; set; }

        public DateTime TerminationDate { get; set; }

        [Required]
        public int EmploymentType { get; set; }

        public string Department { get; set; }

        [Required]
        public Guid ReportingManager { get; set; }

        [Required]
        public string JobTitle { get; set; }

        [Required]
        public int Status { get; set; }
    }
}
