using Excellerent.SharedModules.Seed;
using System;

namespace Excellerent.ApplicantTracking.Domain.Models
{
    public class ApplicantAreaOfInterest : BaseAuditModel
    {
        public Guid LUPositionToApplyGuid { get; set; }
        public LUPositionToApply LuPositionToApply { get; set; } 
        public Guid LUProficiencyLevelGuid { get; set; }
        public virtual LUProficiencyLevel ProficiencyLevel { get; set; }
        public int YearsOfExpierence { get; set; }
        public int MonthOfExpierence { get; set; }
        public string PrimarySkillSetID { get; set; }
        public string SecondarySkillSetID { get; set; }
        public string OtherSkillSet { get; set; }
        public Guid ApplicantGuid { get; set; }
        public virtual Applicant ApplicantInfo { get; set; }
    }
}
