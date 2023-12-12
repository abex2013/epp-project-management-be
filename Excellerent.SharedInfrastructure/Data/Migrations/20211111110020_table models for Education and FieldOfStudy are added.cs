using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Excellerent.SharedInfrastructure.Data.Migrations
{
    public partial class tablemodelsforEducationandFieldOfStudyareadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicantAreaOfInterest_PositionToApply_luPositionToApplyGu~",
                table: "ApplicantAreaOfInterest");

            migrationBuilder.DropForeignKey(
                name: "FK_ApplicantAreaOfInterest_SkillSet_skillSetGuid",
                table: "ApplicantAreaOfInterest");

            migrationBuilder.DropIndex(
                name: "IX_ApplicantAreaOfInterest_skillSetGuid",
                table: "ApplicantAreaOfInterest");

            migrationBuilder.DropColumn(
                name: "skillSetGuid",
                table: "ApplicantAreaOfInterest");

            migrationBuilder.RenameColumn(
                name: "luPositionToApplyGuid",
                table: "ApplicantAreaOfInterest",
                newName: "LuPositionToApplyGuid");

            migrationBuilder.RenameIndex(
                name: "IX_ApplicantAreaOfInterest_luPositionToApplyGuid",
                table: "ApplicantAreaOfInterest",
                newName: "IX_ApplicantAreaOfInterest_LuPositionToApplyGuid");

            migrationBuilder.AlterColumn<string>(
                name: "SecondarySkillSetID",
                table: "ApplicantAreaOfInterest",
                type: "text",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<string>(
                name: "PrimarySkillSetID",
                table: "ApplicantAreaOfInterest",
                type: "text",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<string>(
                name: "OtherSkillSet",
                table: "ApplicantAreaOfInterest",
                type: "text",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.CreateTable(
                name: "EducationProgrammes",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatedbyUserGuid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EducationProgrammes", x => x.Guid);
                });

            migrationBuilder.CreateTable(
                name: "Educations",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    EducationProgrammeGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    Institution = table.Column<string>(type: "text", nullable: true),
                    FieldOfStudyGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    DateFrom = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DateTo = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IsCompleted = table.Column<bool>(type: "boolean", nullable: false),
                    OtherFieldOfStudy = table.Column<string>(type: "text", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatedbyUserGuid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Educations", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_Educations_EducationProgrammes_EducationProgrammeGuid",
                        column: x => x.EducationProgrammeGuid,
                        principalTable: "EducationProgrammes",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Educations_FieldOfStudie_FieldOfStudyGuid",
                        column: x => x.FieldOfStudyGuid,
                        principalTable: "FieldOfStudie",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Educations_EducationProgrammeGuid",
                table: "Educations",
                column: "EducationProgrammeGuid");

            migrationBuilder.CreateIndex(
                name: "IX_Educations_FieldOfStudyGuid",
                table: "Educations",
                column: "FieldOfStudyGuid");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicantAreaOfInterest_PositionToApply_LuPositionToApplyGu~",
                table: "ApplicantAreaOfInterest",
                column: "LuPositionToApplyGuid",
                principalTable: "PositionToApply",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicantAreaOfInterest_PositionToApply_LuPositionToApplyGu~",
                table: "ApplicantAreaOfInterest");

            migrationBuilder.DropTable(
                name: "Educations");

            migrationBuilder.DropTable(
                name: "EducationProgrammes");

            migrationBuilder.RenameColumn(
                name: "LuPositionToApplyGuid",
                table: "ApplicantAreaOfInterest",
                newName: "luPositionToApplyGuid");

            migrationBuilder.RenameIndex(
                name: "IX_ApplicantAreaOfInterest_LuPositionToApplyGuid",
                table: "ApplicantAreaOfInterest",
                newName: "IX_ApplicantAreaOfInterest_luPositionToApplyGuid");

            migrationBuilder.AlterColumn<int>(
                name: "SecondarySkillSetID",
                table: "ApplicantAreaOfInterest",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PrimarySkillSetID",
                table: "ApplicantAreaOfInterest",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "OtherSkillSet",
                table: "ApplicantAreaOfInterest",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "skillSetGuid",
                table: "ApplicantAreaOfInterest",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ApplicantAreaOfInterest_skillSetGuid",
                table: "ApplicantAreaOfInterest",
                column: "skillSetGuid");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicantAreaOfInterest_PositionToApply_luPositionToApplyGu~",
                table: "ApplicantAreaOfInterest",
                column: "luPositionToApplyGuid",
                principalTable: "PositionToApply",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicantAreaOfInterest_SkillSet_skillSetGuid",
                table: "ApplicantAreaOfInterest",
                column: "skillSetGuid",
                principalTable: "SkillSet",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
