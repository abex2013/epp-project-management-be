using System;

namespace Excellerent.ApplicantTracking.Presentation.Models.PostModels
{
    public class ApplicantAreaOfInterestPostModelDto
    {
        public Guid LUPositionToApplyGuid { get; set; } 

        public Guid LUProficiencyLevelGuid { get; set; } 

        public int YearsOfExpierence { get; set; }

        public int MonthOfExpierence { get; set; }
        public Guid ApplicantGuid { get; set; } 
        public string[] SelectedIDArray { get; set; }
        public string[] SelectedIDSecondArray { get; set; }
        public string[] SelectedIDOtherArray { get; set; }

    }
}
