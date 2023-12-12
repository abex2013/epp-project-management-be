using AutoMapper;
using Excellerent.ApplicantTracking.Domain.Entities;
using Excellerent.ApplicantTracking.Domain.Interfaces.Service;
using Excellerent.ApplicantTracking.Presentation.AccoutService;
using Excellerent.ApplicantTracking.Presentation.Models.PostModels;
using Excellerent.ApplicantTracking.Presentation.ModelValidation;
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
    public class LUProficiencyLevelController : Controller
    {
        private readonly ILUProficiencyLevelService _luProficiencyLevel;
        private readonly IAuthService _authService;
        private readonly string _feature = "Proficiency";
        private IMapper _mapper;
        private ProficiencyLevelValidation proficiencyLevelValidation;

        public LUProficiencyLevelController(IAuthService authService, ILUProficiencyLevelService luProficiencyLevel)
        {
            _luProficiencyLevel = luProficiencyLevel;
            var config = new MapperConfiguration(configuratuion => configuratuion.CreateMap<ProficiencyLevelModelDto, LUProficiencyLevelEntity>().ReverseMap());
            _mapper = new Mapper(config);
            _authService = authService;
        }

        [AllowAnonymous]
        [HttpPost("FieldOfStudy")]
        public async Task<ActionResult<ResponseDTO>> AddFieldOfStudy(ProficiencyLevelModelDto model)
        {
            var mappedEntity = _mapper.Map<LUProficiencyLevelEntity>(model);
            var res = await _luProficiencyLevel.AddProficiency(mappedEntity);
            return Ok(new ResponseDTO
            {
                Data = res,
                Message = "Field Of Study added succesfully",
                ResponseStatus = ResponseStatus.Success,
                Ex = null
            });
        }



        

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetProficiencyByName(string ProficiencyName)
        {
            try
            {
                var result = _mapper.Map<PositionToApplyModelDto>(await _luProficiencyLevel.GetByProficiencyName(ProficiencyName));
                return Ok(new ResponseDTO { Data = result, Message = "Successfully retrieved user data.", ResponseStatus = ResponseStatus.Success });
            }
            catch (Exception e)
            {
                return Ok(e);
            }
        }
    }
}