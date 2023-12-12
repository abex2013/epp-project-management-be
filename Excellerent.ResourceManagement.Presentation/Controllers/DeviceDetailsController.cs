using Excellerent.ResourceManagement.Domain.Entities;
using Excellerent.ResourceManagement.Domain.Interfaces.Services;
using Excellerent.SharedModules.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excellerent.ResourceManagement.Presentation.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class DeviceDetailsController : Controller
    {
        private readonly IDeviceDetailsService _assetDetailsService;
        public DeviceDetailsController(IDeviceDetailsService assetDetailsService)
        {
            _assetDetailsService = assetDetailsService;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ResponseDTO> Add(DeviceDetailsEntity assetDetailsEntity)
        {
            return await _assetDetailsService.Add(assetDetailsEntity);
        }
    }
}
