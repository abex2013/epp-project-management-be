using Excellerent.ApplicantTracking.Domain.Interfaces.Service;
using Excellerent.ApplicantTracking.Presentation.Models.PostModels;
using FluentValidation;
using System;
using System.Threading.Tasks;

namespace Excellerent.ApplicantTracking.Presentation.ModelValidation
{
    public  class EducationPostModelValidator: AbstractValidator<EducationPostModelDto>
    {
        private readonly ILUFieldOfStudyService _fieldOfStudyervice;
        private readonly IEducationProgrammeService _programmeService;
        public EducationPostModelValidator(ILUFieldOfStudyService applicantService, 
            IEducationProgrammeService programmeService)
        {
            this._fieldOfStudyervice = applicantService;
            this._programmeService = programmeService;
            
            RuleFor(model => model.EducationProgrammeId)
                .NotNull();
            RuleFor(model => model.Institution)
                .NotNull()
                .MaximumLength(50);
            RuleFor(model => model.Country)
                .NotNull();
            RuleFor(model => model.FieldOfStudyId)
                .NotNull();
               
            RuleFor(model => model.EducationProgrammeId)
                .NotNull();
            RuleFor(model => model.DateFrom)
                .NotNull()
                .LessThan(DateTime.Now);
            RuleFor(model => model.DateTo)
               .NotNull()
               .LessThanOrEqualTo(DateTime.Now);
            RuleFor(model => model.OtherFieldOfStudy)
               .NotNull().WhenAsync(async (model, cancellation) =>
               {
                   return await CheckIfHighSchoolDeplopmaSelectedAsync(model);
               });
            RuleFor(model => model.CreatedbyUserGuid).NotNull();
        }

        private async Task<bool> CheckIfOtherFieldOfStudySelectedAsync(EducationPostModelDto model)
        {
            var fieldOfStudyEntity = await this._fieldOfStudyervice.GetByIdAsync(model.EducationProgrammeId);
            return fieldOfStudyEntity == null? false: fieldOfStudyEntity.Name.ToLower() == "other";
        }
        private async Task<bool> CheckIfHighSchoolDeplopmaSelectedAsync(EducationPostModelDto model)
        {
            var name = await this._programmeService.GetName(model.FieldOfStudyId);
            if (name == null)
                return false;
            return name.ToLower() == "high school diploma";
        }
    }
}
