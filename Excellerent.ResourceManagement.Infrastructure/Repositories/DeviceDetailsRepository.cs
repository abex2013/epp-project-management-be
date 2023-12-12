using Excellerent.ResourceManagement.Domain.Interfaces.Repository;
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
    public class DeviceDetailsRepository : AsyncRepository<DeviceDetails>, IDeviceDetailsRepository
    {
        private readonly EPPContext _context;
        public DeviceDetailsRepository(EPPContext context) : base(context)
        {
            _context = context;
        }
    }
}
