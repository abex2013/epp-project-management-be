using Excellerent.Timesheet.Domain.Models;
using System.Collections.Generic;

namespace Excellerent.Timesheet.Domain.Interfaces.Service
{
    public interface IClientMockService
    {
        List<ClientMock> GetClient(int? id);

    }
}
