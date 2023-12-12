using Excellerent.ApplicantTracking.Domain.Entities;
using Excellerent.ApplicantTracking.Domain.Models;
using Excellerent.SharedModules.DTO;
using Excellerent.SharedModules.Interface.Service;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Excellerent.ApplicantTracking.Domain.Interfaces.Service
{
    public interface IEducationProgrammeService : ICRUD<EducationProgrammeEntity, EducationProgramme>
    {
       public  Task<string> GetName(Guid educationProgrammId);
       public new Task<IEnumerable<EducationProgrammeEntity>> GetAll();
        public Task<ResponseDTO> AddAsync(EducationProgrammeEntity entity);

    }
}
