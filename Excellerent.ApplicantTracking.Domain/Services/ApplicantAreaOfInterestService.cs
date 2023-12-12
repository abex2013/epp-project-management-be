using Excellerent.ApplicantTracking.Domain.Entities;
using Excellerent.ApplicantTracking.Domain.Interfaces.Repository;
using Excellerent.ApplicantTracking.Domain.Interfaces.Service;
using Excellerent.ApplicantTracking.Domain.Models;
using Excellerent.SharedModules.Services;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Excellerent.ApplicantTracking.Domain.Services
{
    public  class ApplicantAreaOfInterestService : CRUD<ApplicantAreaOfInterestEntities, ApplicantAreaOfInterest>, IApplicantAreaOfInterestService
    {
        private readonly IApplicantAreaOfInterestRepository _applicantAreaOfInterestRepository;
        public ApplicantAreaOfInterestService(IApplicantAreaOfInterestRepository applicantAreaOfInterestRepository) : base(applicantAreaOfInterestRepository)
        {
            _applicantAreaOfInterestRepository = applicantAreaOfInterestRepository;
        }
        public async Task<Guid> AddApplicantAreaOfInterst(ApplicantAreaOfInterestEntities applicantAreaOfInterestToApply)
        {
            var model = applicantAreaOfInterestToApply.MapToModel();
            var data = await _applicantAreaOfInterestRepository.AddAsync(model);
            return data.Guid;
        } 

        public async Task<Guid> DeleteApplicantAreaOfInterst(Guid guid)
        {
            var data = await _applicantAreaOfInterestRepository.FindOneAsync(x => x.Guid == guid);
            await _applicantAreaOfInterestRepository.DeleteAsync(data);
            return data.Guid;

        }
        public async Task<ApplicantAreaOfInterestEntities> GetApplicantAreaOfInterest()
        {
            return (ApplicantAreaOfInterestEntities)await _applicantAreaOfInterestRepository.GetAllAsync();
        }
        public async Task<ApplicantAreaOfInterestEntities> GetApplicantAreaOfInterestByGuid(Guid guid) 
        {
            var data = await _applicantAreaOfInterestRepository.FindOneAsync(x => x.Guid == guid);
            //For Multi Select skill sets 
            var entityData = data != null ? new ApplicantAreaOfInterestEntities(data) : null;
            if (entityData != null)
            {
                entityData.SelectedIDArray = data.PrimarySkillSetID.Split(',').ToArray();
                entityData.SelectedIDSecondArray = data.PrimarySkillSetID.Split(',').ToArray();
                entityData.SelectedIDOtherArray = data.PrimarySkillSetID.Split(',').ToArray();

            }
            
            return entityData;
        }

        public async Task<ApplicantAreaOfInterestEntities> GetApplicantAreaOfInterestByApplicantID(Guid ApplicantGuid)
        {
            var data = await _applicantAreaOfInterestRepository.FindOneAsync(x => x.Guid == ApplicantGuid);
            return data != null ? new ApplicantAreaOfInterestEntities(data) : null;
        }

        public async Task<ApplicantAreaOfInterestEntities> GetApplicantAreaOfInterestByPosition(Guid LUPositionToApplyGuid)
        {
            var data = await _applicantAreaOfInterestRepository.FindOneAsync(x => x.Guid == LUPositionToApplyGuid);
            return data != null ? new ApplicantAreaOfInterestEntities(data) : null;
        }

        public async Task<ApplicantAreaOfInterestEntities> GetApplicantAreaOfInterestByProficiencyLevel(Guid LUProficiencyLevelGuid)
        {
            var data = await _applicantAreaOfInterestRepository.FindOneAsync(x => x.Guid == LUProficiencyLevelGuid);
            return data != null ? new ApplicantAreaOfInterestEntities(data) : null;
        }

        public async Task<ApplicantAreaOfInterestEntities> GetApplicantAreaOfInterestByYearsOfExpierence(int YearsOfExpierence)
        {
            var data = await _applicantAreaOfInterestRepository.FindOneAsync(x => x.YearsOfExpierence == YearsOfExpierence);
            return data != null ? new ApplicantAreaOfInterestEntities(data) : null;
        }

        public async Task<Guid> UpdateApplicantAreaOfInterest(ApplicantAreaOfInterestEntities areaOfInterestEntity)
        {
            var data = await _applicantAreaOfInterestRepository.FindOneAsync(x => x.Guid == areaOfInterestEntity.Guid);
            var model = areaOfInterestEntity.MapToModel(data);
            await _applicantAreaOfInterestRepository.UpdateAsync(model);
            return data.Guid;
        }
    }
}
