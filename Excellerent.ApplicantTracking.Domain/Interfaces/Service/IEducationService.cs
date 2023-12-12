using Excellerent.ApplicantTracking.Domain.Entities;
using Excellerent.ApplicantTracking.Domain.Models;
using Excellerent.SharedModules.DTO;
using Excellerent.SharedModules.Interface.Service;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Excellerent.ApplicantTracking.Domain.Interfaces.Service
{
    public  interface IEducationService:  ICRUD<EducationEntity, Education>
    {
        public Task<IEnumerable<EducationEntity>> GetByApplicantIdAsync(Guid applicantId);
        public Task<EducationEntity> GetByIdAsync(Guid educationId);
        public Task<IEnumerable<EducationEntity>> GetWithPredicateAsync(Guid? id, Guid? applicantId);
        public new Task<ResponseDTO> Add(EducationEntity entity);
        public Task<EducationEntity> FindOneAsyncForDelete(Guid guid);
        public new Task<ResponseDTO> Update(EducationEntity entity);



    }
}
