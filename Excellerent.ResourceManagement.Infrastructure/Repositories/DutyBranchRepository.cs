using Excellerent.ResourceManagement.Domain.Interfaces.Repository;
using Excellerent.ResourceManagement.Domain.Models;
using Excellerent.SharedInfrastructure.Context;
using Excellerent.SharedInfrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;


namespace Excellerent.ResourceManagement.Infrastructure.Repositories
{
    public class DutyBranchRepository : AsyncRepository<DutyBranch>, IDutyBranchRepository
    {
        private readonly EPPContext _context;
        public DutyBranchRepository(EPPContext context) : base(context)
        {
            _context = context;
        }

        public async Task<bool> CheckDutyBranchExistance(Guid countryId, string branchName)
        {
            var result = await _context.DutyBranches.Where(x => x.CountryId == countryId && x.Name == branchName).CountAsync() > 0 ? true : false;
            return result;
        }

        public async Task<DutyBranch> GetDutyBranchByCountry(Guid countryId)
        {
            var result = await _context.DutyBranches.Where(x => x.CountryId == countryId).FirstOrDefaultAsync();
            return result;
        }
    }
}
