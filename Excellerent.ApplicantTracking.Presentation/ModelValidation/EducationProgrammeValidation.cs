using Excellerent.ApplicantTracking.Presentation.Models.PostModels;
using FluentValidation;

namespace Excellerent.ApplicantTracking.Presentation.ModelValidation
{
    public class EducationProgrammeValidator : AbstractValidator<EducationProgrammePostModel>
    {
        public EducationProgrammeValidator()
        {
            RuleFor(_ => _.Name)
                .NotNull()
                .MinimumLength(2).WithMessage("Please use longer name.")
                .MaximumLength(100).WithMessage("Plaease use shorter name.");
        }
    }
}
