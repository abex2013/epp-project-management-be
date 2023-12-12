using Excellerent.ResourceManagement.Domain.Entities;
using Excellerent.ResourceManagement.Domain.Interfaces.Repository;
using Excellerent.ResourceManagement.Domain.Interfaces.Services;
using Excellerent.ResourceManagement.Domain.Models;
using Excellerent.SharedModules.Services;
using System;
using System.Threading.Tasks;

namespace Excellerent.ResourceManagement.Domain.Services
{
    public class DutyBranchService : CRUD<DutyBranchEntity, DutyBranch>, IDutyBranchService
    {
        private readonly IDutyBranchRepository _repository;
        public DutyBranchService(IDutyBranchRepository repository) : base(repository)
        {
            _repository = repository;
        }

        public async Task<bool> CheckDutyBranchExistance(Guid countryId, string branchName)
        {
            return await _repository.CheckDutyBranchExistance(countryId, branchName);
        }

        public async Task<DutyBranch> GetDutyBranchByCountry(Guid countryId)
        {
            return await _repository.GetDutyBranchByCountry(countryId);
        }
    }
}
