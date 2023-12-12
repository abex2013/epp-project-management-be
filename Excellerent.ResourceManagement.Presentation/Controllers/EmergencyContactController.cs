using Excellerent.ResourceManagement.Domain.Entities;
using Excellerent.ResourceManagement.Domain.Interfaces.Services;
using Excellerent.ResourceManagement.Domain.Models;
using Excellerent.ResourceManagement.Infrastructure.Dtos;
using Excellerent.ResourceManagement.Infrastructure.Mapping;
using Excellerent.SharedModules.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Excellerent.ResourceManagement.Presentation.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [Authorize]

    //[Route("api/[controller]")]
    //[ApiController]
    public class EmergencyContactController : Controller
    {
        private readonly IEmergencyContactService _emservice;

        public EmergencyContactController(IEmergencyContactService emservice)
        {
            _emservice = emservice;
        }



        [AllowAnonymous]
        [HttpPost("Add Employee EmergencyContact")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ResponseDTO> AddEmergencyContact(EmergencyContact entity)
        {
            var data = await _emservice.AddEmergencyContactAsync(entity);
            return (new ResponseDTO
            {
                Data = data,
                Message = "Emergency Contact added Sussessfully!",
                ResponseStatus = ResponseStatus.Success,
                Ex = null
            });
        }

        [AllowAnonymous]
        [HttpGet("Get Employee EmergencyContacts")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public Task<IEnumerable<EmergencyContact>> GetAll()
        {
            return _emservice.GetAll();



        }




    }
}
