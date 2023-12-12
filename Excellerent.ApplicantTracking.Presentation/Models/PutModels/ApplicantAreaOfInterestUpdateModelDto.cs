using System;

namespace Excellerent.ApplicantTracking.Presentation.Models.PutModels
{
    public class ApplicantAreaOfInterestUpdateModelDto
    {
        public Guid Guid { get; set; }
        public Guid LUPositionToApplyGuid { get; set; }

        public Guid LUProficiencyLevelGuid { get; set; }

        public int YearsOfExpierence { get; set; }

        public int MonthOfExpierence { get; set; }
        public Guid ApplicantGuid { get; set; }
        public string[] PrimarySkillSetID { get; set; }
        public string[] SelectedIDSecondArray { get; set; }
        public string[] SelectedIDOtherArray { get; set; }
    }
}
