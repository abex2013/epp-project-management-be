using Excellerent.ResourceManagement.Domain.Entities;
using Excellerent.ResourceManagement.Domain.Interfaces.Repository;
using Excellerent.ResourceManagement.Domain.Models;
using Excellerent.ResourceManagement.Infrastructure.Dtos;
using Excellerent.ResourceManagement.Infrastructure.Mapping;
using Excellerent.SharedInfrastructure.Context;
using Excellerent.SharedInfrastructure.Repository;
using Excellerent.SharedModules.DTO;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Excellerent.ResourceManagement.Infrastructure.Repositories
{
    public class EmergencyContactRepository : AsyncRepository<EmergencyContact>, IEmergencyContactRepository
    {
        private readonly EPPContext _dbcontext;
        public EmergencyContactRepository(EPPContext context) : base(context)
        {
            _dbcontext = context;
        }



        public async Task<EmergencyContact> AddAsync(EmergencyContact _data)
        {
            var data = await _dbcontext.emergencycontacts.AddAsync(_data);
            _dbcontext.SaveChanges();
            return data.Entity;
        }


        public async Task<IEnumerable<EmergencyContactEntity>> GetAllAsync()
        {
            //return (IEnumerable<EmergencyContactDto>)await _dbcontext.emergencycontacts.ToListAsync();


            return (IEnumerable<EmergencyContactEntity>)_dbcontext.emergencycontacts
            .Select(_ => new EmergencyContactDto
            {
                FirstName = _.FirstName,
                FatherName = _.FatherName,
                Relationship = _.Relationship,
                EmployeeId = _.EmployeeId,
                Address = _.Address.Select(x => new EmergencyAddress()).ToList(),

            }).ToList();
        }


    }
}
