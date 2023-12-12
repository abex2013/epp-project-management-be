using Excellerent.ResourceManagement.Domain.Entities;
using Excellerent.ResourceManagement.Domain.Interfaces.Repository;
using Excellerent.ResourceManagement.Domain.Interfaces.Services;
using Excellerent.ResourceManagement.Domain.Models;
using Excellerent.SharedModules.Services;

namespace Excellerent.ResourceManagement.Domain.Services
{
    public class DeviceDetailsService : CRUD<DeviceDetailsEntity, DeviceDetails>, IDeviceDetailsService
    {
        public DeviceDetailsService(IDeviceDetailsRepository repo) : base(repo)
        {

        }
    }
}
