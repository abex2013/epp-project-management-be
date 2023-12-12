using Excellerent.ApplicantTracking.Domain.Interfaces.Service;
using Excellerent.ApplicantTracking.Presentation.Models.PostModels;
using Excellerent.ApplicantTracking.Presentation.Models.PutModels;
using FluentValidation;
using System;
using System.Threading.Tasks;

namespace Excellerent.ApplicantTracking.Presentation.ModelValidation
{
    public class EducationPutModelValidator :AbstractValidator<EducationPutModel>
    {
        private readonly ILUFieldOfStudyService _fieldOfStudyervice;
        private readonly IEducationProgrammeService _programmeService;
        public EducationPutModelValidator(ILUFieldOfStudyService fieldOfStudyervice,
            IEducationProgrammeService programmeService) 
        {
            _fieldOfStudyervice = fieldOfStudyervice;
            _programmeService = programmeService;
            RuleFor(_ => _.Guid).NotNull();

            RuleFor(model => model.EducationProgrammeId)
                .NotNull();
            RuleFor(model => model.Institution)
                .NotNull();
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
        }

        private async Task<bool> CheckIfOtherFieldOfStudySelectedAsync(EducationPutModel model)
        {
            var fieldOfStudyEntity = await this._fieldOfStudyervice.GetByIdAsync(model.EducationProgrammeId);
            return fieldOfStudyEntity == null ? false : fieldOfStudyEntity.Name.ToLower() == "other";
        }
        private async Task<bool> CheckIfHighSchoolDeplopmaSelectedAsync(EducationPutModel model)
        {
            var name = await this._programmeService.GetName(model.FieldOfStudyId);
            if (name == null)
                return false;
            return name.ToLower() == "high school diploma";
        }
    }
}
