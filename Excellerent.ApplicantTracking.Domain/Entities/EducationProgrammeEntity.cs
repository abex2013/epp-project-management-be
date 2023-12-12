using Excellerent.ApplicantTracking.Domain.Models;
using Excellerent.SharedModules.Seed;
using System;

namespace Excellerent.ApplicantTracking.Domain.Entities
{
    public class EducationProgrammeEntity : BaseEntity<EducationProgramme>
    {
        public string Name { get; set; }

        public EducationProgrammeEntity(EducationProgramme programme): base(programme)
        {
            this.Name = programme.Name;
        }
        public EducationProgrammeEntity()
        {
        }
        public override EducationProgramme MapToModel()
        {
            EducationProgramme programme = new EducationProgramme();
            programme.Guid = Guid.NewGuid();
            programme.Name = this.Name;
            return programme;
        }

        public override EducationProgramme MapToModel(EducationProgramme programme)
        {
            programme.Guid = this.Guid;
            programme.Name = this.Name;
            return programme;
        }
    }
}
