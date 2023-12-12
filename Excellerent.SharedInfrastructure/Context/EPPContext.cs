
using Excellerent.ApplicantTracking.Domain.Models;

using Excellerent.ProjectManagement.Domain.Models;

using Excellerent.ResourceManagement.Domain.Models;

using Excellerent.SharedModules.Seed;
using Excellerent.Timesheet.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Employee = Excellerent.ResourceManagement.Domain.Models.Employee;

namespace Excellerent.SharedInfrastructure.Context
{
    public class EPPContext : DbContext
    {

        public EPPContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Applicant> Applicants { get; set; }
        public DbSet<ApplicantAreaOfInterest> ApplicantAreaOfInterest { get; set; }
        public DbSet<LUPositionToApply> PositionToApply { get; set; }
        public DbSet<LUProficiencyLevel> ProficiencyLevel { get; set; }

        public DbSet<LUSkillPositionAssociation> SkillPositionAssociation { get; set; }


        public DbSet<LUSkillSet> SkillSet { get; set; }
        public DbSet<LUFieldOfStudy> FieldOfStudie { get; set; }
        public DbSet<TimeSheet> TimeSheets { get; set; }
        public DbSet<TimeEntry> TimeEntry { get; set; }
        public DbSet<Education> Educations { get; set; }
        public DbSet<EducationProgramme> EducationProgrammes { get; set; }
        public DbSet<TimesheetAproval> TimesheetAprovals { get; set; }

        public DbSet<AssignResource> AssignResources { get; set; }
        public DbSet<Client> Client { get; set; }
        public DbSet<Project> Project { get; set; }
        public DbSet<ProjectStatus> ProjectStatus { get; set; }

        public DbSet<EmergencyContact> emergencycontacts { get; set; }

        public DbSet<EmployeeOrganization> EmployeeOrganizations { get; set; }

        public DbSet<Country> Countries { get; set; }

        public DbSet<DutyBranch> DutyBranches { get; set; }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<Nationality> Nationalities { get; set; }

        public DbSet<FamilyDetails> FamilyDetails { get; set; }

        public DbSet<EmergencyAddress> EmergencyAddresses { get; set; }

        public DbSet<PersonalAddress> PersonalAddresses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            modelBuilder.Entity<TimesheetAproval>().HasKey(table => new {
                table.TimesheetId,
                table.ProjectId
            });
        }


        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<BaseAuditModel>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedDate = DateTime.Now;
                        entry.Entity.CreatedbyUserGuid = Guid.Empty;
                        break;

                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }

    }
}
