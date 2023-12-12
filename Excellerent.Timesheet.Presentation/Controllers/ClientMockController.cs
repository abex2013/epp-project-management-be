using Excellerent.Timesheet.Domain.Interfaces.Service;
using Excellerent.Timesheet.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Excellerent.Timesheet.Presentation.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiExplorerSettings(IgnoreApi = true)]

    public class ClientMockController : ControllerBase
    {
        private readonly IClientMockService _clientMockService;

        public ClientMockController(IClientMockService clientMockService)
        {
            _clientMockService = clientMockService;
        }
        [HttpGet]
        public List<ClientMock> Get(int? id)
        {
            return _clientMockService.GetClient(id);
        }
    }
}
