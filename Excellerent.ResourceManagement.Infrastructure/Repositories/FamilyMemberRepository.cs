﻿using Excellerent.ResourceManagement.Domain.Interfaces.Repository;
using Excellerent.ResourceManagement.Domain.Models;
using Excellerent.SharedInfrastructure.Context;
using Excellerent.SharedInfrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excellerent.ResourceManagement.Infrastructure.Repositories
{
    public class FamilyMemberRepository : AsyncRepository<Relationship>, IFamilyMemberRepository
    {
        private readonly EPPContext _context;

        public FamilyMemberRepository(EPPContext context) : base(context)
        {
            this._context = context;
        }
    }
}
