using Excellerent.ApplicantTracking.Domain.Interfaces.Repository;
using Excellerent.ApplicantTracking.Domain.Models;
using Excellerent.SharedInfrastructure.Context;
using Excellerent.SharedInfrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Excellerent.ApplicantTracking.Infrastructure.Repositories
{
   public class ApplicantAreaOfInterestRepository : AsyncRepository<ApplicantAreaOfInterest>, IApplicantAreaOfInterestRepository
    {
        private readonly EPPContext _context;
        public ApplicantAreaOfInterestRepository(EPPContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ApplicantAreaOfInterest>> GetApplicantAreaOfInterestByGuid(Guid guid) 
        {
           return await _context.ApplicantAreaOfInterest.Where(x => x.Guid == guid).ToListAsync();
            
        }
        public async Task<IEnumerable<ApplicantAreaOfInterest>> GetApplicantAreaOfInterest()
        {
            return await _context.ApplicantAreaOfInterest.ToListAsync();  

        }

        public async Task<IEnumerable<ApplicantAreaOfInterest>> GetApplicantAreaOfInterestByPosition(Guid PositionToApplyID)
        {
            return await _context.ApplicantAreaOfInterest.Where(x => x.Guid == PositionToApplyID).ToListAsync();
        }

        public async Task<IEnumerable<ApplicantAreaOfInterest>> GetApplicantAreaOfInterestByProficiencyLevel(Guid ProficiencyLevelID)
        {
            return await _context.ApplicantAreaOfInterest.Where(x => x.Guid == ProficiencyLevelID).ToListAsync();
        }

        public async Task<IEnumerable<ApplicantAreaOfInterest>> GetApplicantAreaOfInterestByYearsOfExpierence(int YearsOfExpierence)
        {
            return await _context.ApplicantAreaOfInterest.Where(x => x.YearsOfExpierence == YearsOfExpierence).ToListAsync();
        }

        public async Task<IEnumerable<ApplicantAreaOfInterest>> GetApplicantAreaOfInterestByApplicantID(Guid ApplicantGuid)
        {
            return await _context.ApplicantAreaOfInterest.Where(x => x.Guid == ApplicantGuid).ToListAsync();
        }
    }
}
