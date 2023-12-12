using AutoMapper;
using Excellerent.ApplicantTracking.Domain.Entities;
using Excellerent.ApplicantTracking.Domain.Interfaces.Service;
using Excellerent.ApplicantTracking.Presentation.AccoutService;
using Excellerent.ApplicantTracking.Presentation.Models.PostModels;
using Excellerent.SharedModules.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Excellerent.ApplicantTracking.Presentation.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class LUPositionToApplyController : Controller
    {
        private readonly ILuPositionService _positionToApplyService;
        private readonly IAuthService _authService;
        private readonly string _feature = "Positions";
        private IMapper _mapper;

        public LUPositionToApplyController(IAuthService authService, ILuPositionService positionService)
        {
            _positionToApplyService = positionService;
            var config = new MapperConfiguration(configuratuion => configuratuion.CreateMap<PositionToApplyModelDto, LUPositionToApplyEntity>().ReverseMap());
            _mapper = new Mapper(config);
            _authService = authService;
        }


        [AllowAnonymous]
        [HttpPost("PositionToApply")]
        public async Task<ActionResult<ResponseDTO>> AddPositions(PositionToApplyModelDto model)
        {
            var mappedEntity = _mapper.Map<LUPositionToApplyEntity>(model);
            var res = await _positionToApplyService.AddPosition(mappedEntity);

            return Ok(new ResponseDTO
            {
                Data = res,
                Message = "Position added succesfully",
                ResponseStatus = ResponseStatus.Success,
                Ex = null
            });
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetPositionByName(string PositionName)
        {
            try
            {
                var result = _mapper.Map<PositionToApplyModelDto>(await _positionToApplyService.GetByPositionName(PositionName));
                return Ok(new ResponseDTO { Data = result, Message = "Successfully retrieved user data.", ResponseStatus = ResponseStatus.Success });
            }
            catch (Exception e)
            {
                return Ok(e);
            }

        }
    }
}
