using AutoMapper;
using Excellerent.ApplicantTracking.Domain.Interfaces.Service;
using Excellerent.ApplicantTracking.Domain.Services;
using Excellerent.ApplicantTracking.Presentation.Models.PostModels;
using Excellerent.ApplicantTracking.Presentation.Models.ViewModels;
using Excellerent.ApplicantTracking.Presentation.ModelValidation;
using Excellerent.SharedModules.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Excellerent.ApplicantTracking.Presentation.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class EducationProgrammeController: Controller
    {
        private readonly IEducationProgrammeService _programmeService;
        private readonly EducationProgrammeValidator _validator;
        private readonly IMapper _imapper;
        public EducationProgrammeController(IMapper mapper, IEducationProgrammeService programmeService)
        {
            _imapper = mapper;
            _programmeService = programmeService;
            _validator = new EducationProgrammeValidator();
        }
        [HttpGet]
        public async Task<IEnumerable<EducationProgrammeGetModelDto>> Get()
        {
            var fieldOfStudyEntity = await _programmeService.GetAll();
            return  fieldOfStudyEntity?.Select(e => this._imapper.Map<EducationProgrammeGetModelDto>(e));
        }
        [HttpPost]
        public async Task<ActionResult<ResponseDTO>> Post([FromBody] EducationProgrammePostModel request)
        {
            var vldResult = _validator.Validate(request);
            if (!vldResult.IsValid)
            {
                return BadRequest(new ResponseDTO(ResponseStatus.Error, vldResult.ToString(), null));
            }
            return Ok(await _programmeService.AddAsync(this._imapper.Map<Domain.Entities.EducationProgrammeEntity>(request)));
        }

    }
}
