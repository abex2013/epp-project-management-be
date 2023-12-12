using Excellerent.ResourceManagement.Domain.Entities;
using Excellerent.ResourceManagement.Domain.Interfaces.Repository;
using Excellerent.ResourceManagement.Domain.Interfaces.Services;
using Excellerent.ResourceManagement.Domain.Models;
using Excellerent.SharedModules.DTO;
using Excellerent.SharedModules.Interface.Service;
using Excellerent.SharedModules.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excellerent.ResourceManagement.Domain.Services
{
  public class FamilyMemberService : CRUD<RelationshipEntity, Relationship>, IFamilyMemberService
    {
        private readonly IFamilyMemberRepository _familyMemberRepository;

        public FamilyMemberService(IFamilyMemberRepository familyMemberRepository) : base(familyMemberRepository)
        {
            _familyMemberRepository = familyMemberRepository;
        }

        public async Task<IEnumerable<Relationship>> GetAll()
        {
            return await _familyMemberRepository.GetAllAsync();
        }
    }
}
