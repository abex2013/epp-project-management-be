using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Excellerent.SharedInfrastructure.Data.Migrations
{
    public partial class Educationdatarelationisupdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Educations_EducationProgrammes_EducationProgrammeGuid",
                table: "Educations");

            migrationBuilder.DropForeignKey(
                name: "FK_Educations_FieldOfStudie_FieldOfStudyGuid",
                table: "Educations");

            migrationBuilder.DropIndex(
                name: "IX_Educations_EducationProgrammeGuid",
                table: "Educations");

            migrationBuilder.DropIndex(
                name: "IX_Educations_FieldOfStudyGuid",
                table: "Educations");

            migrationBuilder.DropColumn(
                name: "EducationProgrammeGuid",
                table: "Educations");

            migrationBuilder.DropColumn(
                name: "FieldOfStudyGuid",
                table: "Educations");

            migrationBuilder.AddColumn<Guid>(
                name: "ApplicantId",
                table: "Educations",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "Educations",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "EducationProgrammeId",
                table: "Educations",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "FieldOfStudyId",
                table: "Educations",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Educations_ApplicantId",
                table: "Educations",
                column: "ApplicantId");

            migrationBuilder.CreateIndex(
                name: "IX_Educations_EducationProgrammeId",
                table: "Educations",
                column: "EducationProgrammeId");

            migrationBuilder.CreateIndex(
                name: "IX_Educations_FieldOfStudyId",
                table: "Educations",
                column: "FieldOfStudyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Educations_Applicants_ApplicantId",
                table: "Educations",
                column: "ApplicantId",
                principalTable: "Applicants",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Educations_EducationProgrammes_EducationProgrammeId",
                table: "Educations",
                column: "EducationProgrammeId",
                principalTable: "EducationProgrammes",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Educations_FieldOfStudie_FieldOfStudyId",
                table: "Educations",
                column: "FieldOfStudyId",
                principalTable: "FieldOfStudie",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Educations_Applicants_ApplicantId",
                table: "Educations");

            migrationBuilder.DropForeignKey(
                name: "FK_Educations_EducationProgrammes_EducationProgrammeId",
                table: "Educations");

            migrationBuilder.DropForeignKey(
                name: "FK_Educations_FieldOfStudie_FieldOfStudyId",
                table: "Educations");

            migrationBuilder.DropIndex(
                name: "IX_Educations_ApplicantId",
                table: "Educations");

            migrationBuilder.DropIndex(
                name: "IX_Educations_EducationProgrammeId",
                table: "Educations");

            migrationBuilder.DropIndex(
                name: "IX_Educations_FieldOfStudyId",
                table: "Educations");

            migrationBuilder.DropColumn(
                name: "ApplicantId",
                table: "Educations");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "Educations");

            migrationBuilder.DropColumn(
                name: "EducationProgrammeId",
                table: "Educations");

            migrationBuilder.DropColumn(
                name: "FieldOfStudyId",
                table: "Educations");

            migrationBuilder.AddColumn<Guid>(
                name: "EducationProgrammeGuid",
                table: "Educations",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "FieldOfStudyGuid",
                table: "Educations",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Educations_EducationProgrammeGuid",
                table: "Educations",
                column: "EducationProgrammeGuid");

            migrationBuilder.CreateIndex(
                name: "IX_Educations_FieldOfStudyGuid",
                table: "Educations",
                column: "FieldOfStudyGuid");

            migrationBuilder.AddForeignKey(
                name: "FK_Educations_EducationProgrammes_EducationProgrammeGuid",
                table: "Educations",
                column: "EducationProgrammeGuid",
                principalTable: "EducationProgrammes",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Educations_FieldOfStudie_FieldOfStudyGuid",
                table: "Educations",
                column: "FieldOfStudyGuid",
                principalTable: "FieldOfStudie",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
