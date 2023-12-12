using Excellerent.ResourceManagement.Domain.Entities;
using Excellerent.ResourceManagement.Domain.Interfaces.Services;
using Excellerent.ResourceManagement.Domain.Models;
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
    [Authorize]
    public  class FamilyDetailController:ControllerBase
    {
        private readonly IFamilyDetailService _familyDetailService;
        private readonly IFamilyMemberService _familyMemberService;
        public FamilyDetailController(IFamilyDetailService familyDetailService, IFamilyMemberService familyMemberService)
    {
        _familyDetailService=familyDetailService;
        _familyMemberService = familyMemberService;
    }

        [HttpPost("familydetails")]
        public async Task<ResponseDTO> AddFamilyDetails([FromBody] FamilyDetailsEntity familyDetail)
        {
             try
            { 
                var result = await _familyDetailService.Add(familyDetail);
                return new ResponseDTO(ResponseStatus.Success, "family detail added successfully", familyDetail);
            }
            catch
            {
                return new ResponseDTO(ResponseStatus.Error, "family detailed failed to add successfully", familyDetail);
            }
        }

        [HttpGet("GetFamilyDetailsByEmployeeId/{employeeId}")]
        public async Task<ActionResult<IEnumerable<FamilyDetailsEntity>>> GetFamilyDetailByEmployeeId(Guid employeeId)
        {
            var result = await _familyDetailService.GetFamilyDetailByEmployeeId(employeeId);
            return Ok(result);
        }

        [HttpGet("GetAllFamilyMembers")]
        public async Task<ActionResult<RelationshipEntity>> GetAllFamilyMembers()
        {
            var result = await _familyMemberService.GetAll();
            return Ok(result);
        }
    }
}
