using Excellerent.ApplicantTracking.Domain.Models;
using Excellerent.SharedModules.Seed;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Excellerent.ApplicantTracking.Domain.Interfaces.Repository
{
    public interface IApplicantAreaOfInterestRepository : IAsyncRepository<ApplicantAreaOfInterest>
    {
        Task<IEnumerable<ApplicantAreaOfInterest>> GetApplicantAreaOfInterestByGuid(Guid guid);
        Task<IEnumerable<ApplicantAreaOfInterest>> GetApplicantAreaOfInterest();   
        Task<IEnumerable<ApplicantAreaOfInterest>> GetApplicantAreaOfInterestByPosition(Guid LUPositionToApplyGuid);
        Task<IEnumerable<ApplicantAreaOfInterest>> GetApplicantAreaOfInterestByProficiencyLevel(Guid LUProficiencyLevelGuid);
        Task<IEnumerable<ApplicantAreaOfInterest>> GetApplicantAreaOfInterestByYearsOfExpierence(int YearsOfExpierence);
        Task<IEnumerable<ApplicantAreaOfInterest>> GetApplicantAreaOfInterestByApplicantID (Guid ApplicantGuid); 
    }
}
