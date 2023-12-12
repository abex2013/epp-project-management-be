using Excellerent.ApplicantTracking.Domain.Entities;
using Excellerent.ApplicantTracking.Domain.Models;
using Excellerent.SharedModules.Interface.Service;
using System;
using System.Threading.Tasks;

namespace Excellerent.ApplicantTracking.Domain.Interfaces.Service
{
    public interface IApplicantAreaOfInterestService : ICRUD<ApplicantAreaOfInterestEntities, ApplicantAreaOfInterest>
    {
        Task<Guid> AddApplicantAreaOfInterst(ApplicantAreaOfInterestEntities model);  
        Task<ApplicantAreaOfInterestEntities> GetApplicantAreaOfInterestByGuid(Guid guid);
        Task<ApplicantAreaOfInterestEntities> GetApplicantAreaOfInterest();
        Task<ApplicantAreaOfInterestEntities> GetApplicantAreaOfInterestByPosition(Guid LUPositionToApplyGuid); 
        Task<ApplicantAreaOfInterestEntities> GetApplicantAreaOfInterestByProficiencyLevel(Guid LUProficiencyLevelGuid);
        Task<ApplicantAreaOfInterestEntities> GetApplicantAreaOfInterestByYearsOfExpierence(int YearsOfExpierence);
        public Task<Guid> UpdateApplicantAreaOfInterest(ApplicantAreaOfInterestEntities model);
        public Task<Guid> DeleteApplicantAreaOfInterst(Guid guid);
        Task<ApplicantAreaOfInterestEntities> GetApplicantAreaOfInterestByApplicantID(Guid ApplicantGuid);  
    }
}
