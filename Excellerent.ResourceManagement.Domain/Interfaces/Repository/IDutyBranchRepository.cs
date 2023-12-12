using Excellerent.ResourceManagement.Domain.Models;
using Excellerent.SharedModules.Seed;
using System;
using System.Threading.Tasks;

namespace Excellerent.ResourceManagement.Domain.Interfaces.Repository
{
    public interface IDutyBranchRepository : IAsyncRepository<DutyBranch>
    {
        public Task<DutyBranch> GetDutyBranchByCountry(Guid countryId);

        public Task<bool> CheckDutyBranchExistance(Guid countryId, string branchName);
    }
}
