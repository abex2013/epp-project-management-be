using Excellerent.ApplicantTracking.Domain.Models;
using Excellerent.SharedModules.Seed;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Excellerent.ApplicantTracking.Domain.Entities
{
    public class ApplicantAreaOfInterestEntities : BaseEntity<ApplicantAreaOfInterest>
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
        //[NotMapped]
        //public IEnumerable<LUSkillSet> LUSkillSetCollection { get; set; }
        //[NotMapped]
        public string[] SelectedIDArray { get; set; }
        // [NotMapped]
        public string[] SelectedIDSecondArray { get; set; }
        // [NotMapped]
        public string[] SelectedIDOtherArray { get; set; }
        public ApplicantAreaOfInterestEntities()
        {
        }
        public ApplicantAreaOfInterestEntities(ApplicantAreaOfInterest applicantInterest) : base(applicantInterest)
        {
            Guid = applicantInterest.Guid;
            CreatedDate = applicantInterest.CreatedDate;
            LUPositionToApplyGuid = applicantInterest.LUPositionToApplyGuid;
            LUProficiencyLevelGuid = applicantInterest.LUProficiencyLevelGuid;
            SelectedIDArray = applicantInterest.PrimarySkillSetID.Split(',').ToArray();
            SelectedIDSecondArray = applicantInterest.SecondarySkillSetID.Split(',').ToArray();
            SelectedIDOtherArray = applicantInterest.OtherSkillSet.Split(',').ToArray();
            ApplicantGuid = applicantInterest.ApplicantGuid;
        }

        public override ApplicantAreaOfInterest MapToModel()
        {
            ApplicantAreaOfInterest applicantInterest = new ApplicantAreaOfInterest();
            applicantInterest.Guid = Guid.NewGuid();
            applicantInterest.CreatedDate = CreatedDate;
            applicantInterest.LUPositionToApplyGuid = LUPositionToApplyGuid;
            applicantInterest.LUProficiencyLevelGuid = LUProficiencyLevelGuid;
            applicantInterest.PrimarySkillSetID = string.Join(",", SelectedIDArray);
            applicantInterest.SecondarySkillSetID = string.Join(",", SelectedIDSecondArray);
            applicantInterest.OtherSkillSet = string.Join(",", SelectedIDOtherArray);
            applicantInterest.ApplicantGuid = ApplicantGuid;
            applicantInterest.IsActive = IsActive;
            applicantInterest.IsDeleted = IsDeleted;
            return applicantInterest;
        }

        public override ApplicantAreaOfInterest MapToModel(ApplicantAreaOfInterest t)
        {
            ApplicantAreaOfInterest applicantToUpdate = t;
            applicantToUpdate.Guid = Guid;
            applicantToUpdate.CreatedDate=CreatedDate;
            applicantToUpdate.LUPositionToApplyGuid = LUPositionToApplyGuid;
            applicantToUpdate.LUProficiencyLevelGuid = LUProficiencyLevelGuid;
            applicantToUpdate.PrimarySkillSetID = string.Join(",", SelectedIDArray); 
            applicantToUpdate.SecondarySkillSetID = string.Join(",", SelectedIDSecondArray);
            applicantToUpdate.OtherSkillSet= string.Join(",", SelectedIDOtherArray);
            ApplicantGuid = applicantToUpdate.ApplicantGuid;
            applicantToUpdate.IsActive = IsActive;
            applicantToUpdate.IsDeleted = IsDeleted;
            applicantToUpdate.IsActive = IsActive;
            applicantToUpdate.IsDeleted = IsDeleted;
            return applicantToUpdate;
        }

    }
}

