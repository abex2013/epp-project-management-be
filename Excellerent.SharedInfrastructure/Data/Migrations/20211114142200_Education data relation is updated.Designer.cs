﻿// <auto-generated />
using System;
using Excellerent.SharedInfrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Excellerent.SharedInfrastructure.Data.Migrations
{
    [DbContext(typeof(EPPContext))]
<<<<<<< HEAD:Excellerent.SharedInfrastructure/Data/Migrations/20211116224935_intialMigration.Designer.cs
    [Migration("20211116224935_intialMigration")]
    partial class intialMigration
=======
    [Migration("20211114142200_Education data relation is updated")]
    partial class Educationdatarelationisupdated
>>>>>>> 847cc349c24d9e9f3e1890b8465a599b7e2bc14e:Excellerent.SharedInfrastructure/Data/Migrations/20211114142200_Education data relation is updated.Designer.cs
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("Excellerent.ApplicantTracking.Domain.Models.Applicant", b =>
                {
                    b.Property<Guid>("Guid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("ContactNumber")
                        .HasColumnType("text");

                    b.Property<string>("Country")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<Guid>("CreatedbyUserGuid")
                        .HasColumnType("uuid");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .HasColumnType("text");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<string>("LastName")
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .HasColumnType("text");

                    b.Property<string>("ProfilePictureUpload")
                        .HasColumnType("text");

                    b.Property<string>("ResumeUpload")
                        .HasColumnType("text");

                    b.Property<string>("Status")
                        .HasColumnType("text");

                    b.HasKey("Guid");

                    b.ToTable("Applicants");
                });

            modelBuilder.Entity("Excellerent.ApplicantTracking.Domain.Models.ApplicantAreaOfInterest", b =>
                {
                    b.Property<Guid>("Guid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("ApplicantId")
                        .HasColumnType("integer");

                    b.Property<Guid>("ApplicantInfoGuid")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<Guid>("CreatedbyUserGuid")
                        .HasColumnType("uuid");

                    b.Property<int>("Id")
                        .HasColumnType("integer");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<Guid?>("LuPositionToApplyGuid")
                        .HasColumnType("uuid");

                    b.Property<int>("MonthOfExpierence")
                        .HasColumnType("integer");

                    b.Property<string>("OtherSkillSet")
                        .HasColumnType("text");

                    b.Property<int>("PositionToApplyID")
                        .HasColumnType("integer");

                    b.Property<string>("PrimarySkillSetID")
                        .HasColumnType("text");

                    b.Property<Guid>("ProficiencyLevelGuid")
                        .HasColumnType("uuid");

                    b.Property<int>("ProficiencyLevelID")
                        .HasColumnType("integer");

                    b.Property<string>("SecondarySkillSetID")
                        .HasColumnType("text");

                    b.Property<int>("YearsOfExpierence")
                        .HasColumnType("integer");

                    b.HasKey("Guid");

                    b.HasIndex("ApplicantInfoGuid");

                    b.HasIndex("LuPositionToApplyGuid");

                    b.HasIndex("ProficiencyLevelGuid");

                    b.ToTable("ApplicantAreaOfInterest");
                });

            modelBuilder.Entity("Excellerent.ApplicantTracking.Domain.Models.Education", b =>
                {
                    b.Property<Guid>("Guid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("ApplicantId")
                        .HasColumnType("uuid");

                    b.Property<string>("Country")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<Guid>("CreatedbyUserGuid")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("DateFrom")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("DateTo")
                        .HasColumnType("timestamp without time zone");

                    b.Property<Guid>("EducationProgrammeId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("FieldOfStudyId")
                        .HasColumnType("uuid");

                    b.Property<string>("Institution")
                        .HasColumnType("text");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsCompleted")
                        .HasColumnType("boolean");

                    b.Property<string>("OtherFieldOfStudy")
                        .HasColumnType("text");

                    b.HasKey("Guid");

                    b.HasIndex("ApplicantId");

                    b.HasIndex("EducationProgrammeId");

                    b.HasIndex("FieldOfStudyId");

                    b.ToTable("Educations");
                });

            modelBuilder.Entity("Excellerent.ApplicantTracking.Domain.Models.EducationProgramme", b =>
                {
                    b.Property<Guid>("Guid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<Guid>("CreatedbyUserGuid")
                        .HasColumnType("uuid");

<<<<<<< HEAD:Excellerent.SharedInfrastructure/Data/Migrations/20211116224935_intialMigration.Designer.cs
                    b.Property<Guid>("EmployeeGuid")
                        .HasColumnType("uuid");

=======
>>>>>>> 847cc349c24d9e9f3e1890b8465a599b7e2bc14e:Excellerent.SharedInfrastructure/Data/Migrations/20211114142200_Education data relation is updated.Designer.cs
                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Guid");

<<<<<<< HEAD:Excellerent.SharedInfrastructure/Data/Migrations/20211116224935_intialMigration.Designer.cs
                    b.HasIndex("ProjectGuid");

                    b.ToTable("AssignResources");
=======
                    b.ToTable("EducationProgrammes");
>>>>>>> 847cc349c24d9e9f3e1890b8465a599b7e2bc14e:Excellerent.SharedInfrastructure/Data/Migrations/20211114142200_Education data relation is updated.Designer.cs
                });

            modelBuilder.Entity("Excellerent.ApplicantTracking.Domain.Models.LUFieldOfStudy", b =>
                {
                    b.Property<Guid>("Guid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<Guid>("CreatedbyUserGuid")
                        .HasColumnType("uuid");

                    b.Property<string>("EducationName")
                        .HasColumnType("text");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.HasKey("Guid");

                    b.ToTable("FieldOfStudie");
                });

<<<<<<< HEAD:Excellerent.SharedInfrastructure/Data/Migrations/20211116224935_intialMigration.Designer.cs
            modelBuilder.Entity("Excellerent.ProjectManagement.Domain.Models.Project", b =>
=======
            modelBuilder.Entity("Excellerent.ApplicantTracking.Domain.Models.LUPositionToApply", b =>
                {
                    b.Property<Guid>("Guid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<Guid>("CreatedbyUserGuid")
                        .HasColumnType("uuid");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Guid");

                    b.ToTable("PositionToApply");
                });

            modelBuilder.Entity("Excellerent.ApplicantTracking.Domain.Models.LUProficiencyLevel", b =>
>>>>>>> 847cc349c24d9e9f3e1890b8465a599b7e2bc14e:Excellerent.SharedInfrastructure/Data/Migrations/20211114142200_Education data relation is updated.Designer.cs
                {
                    b.Property<Guid>("Guid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<Guid>("CreatedbyUserGuid")
                        .HasColumnType("uuid");

<<<<<<< HEAD:Excellerent.SharedInfrastructure/Data/Migrations/20211116224935_intialMigration.Designer.cs
                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("timestamp without time zone");

=======
>>>>>>> 847cc349c24d9e9f3e1890b8465a599b7e2bc14e:Excellerent.SharedInfrastructure/Data/Migrations/20211114142200_Education data relation is updated.Designer.cs
                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Guid");

                    b.ToTable("ProficiencyLevel");
                });

            modelBuilder.Entity("Excellerent.ApplicantTracking.Domain.Models.LUSkillSet", b =>
                {
                    b.Property<Guid>("Guid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<bool>("AllowResource")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<Guid>("CreatedbyUserGuid")
                        .HasColumnType("uuid");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<string>("SkillName")
                        .HasColumnType("text");

                    b.HasKey("Guid");

                    b.ToTable("SkillSet");
                });

            modelBuilder.Entity("Excellerent.ResourceManagement.Domain.Models.EmergencyContact", b =>
                {
                    b.Property<Guid>("Guid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<Guid>("CreatedbyUserGuid")
                        .HasColumnType("uuid");

                    b.Property<string>("FatherName")
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .HasColumnType("text");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<string>("Relationship")
                        .HasColumnType("text");

                    b.HasKey("Guid");

                    b.ToTable("EmeregencyContacts");
                });

            modelBuilder.Entity("Excellerent.Timesheet.Domain.Models.TimeEntry", b =>
                {
                    b.Property<Guid>("Guid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<Guid>("CreatedbyUserGuid")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("integer");

                    b.Property<int>("Hour")
                        .HasColumnType("integer");

                    b.Property<int>("Index")
                        .HasColumnType("integer");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<string>("Note")
                        .HasColumnType("text");

                    b.Property<Guid>("ProjectId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("TimeSheetGuid")
                        .HasColumnType("uuid");

                    b.HasKey("Guid");

                    b.HasIndex("TimeSheetGuid");

                    b.ToTable("TimeEntry");
                });

            modelBuilder.Entity("Excellerent.Timesheet.Domain.Models.TimeSheet", b =>
                {
                    b.Property<Guid>("Guid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<Guid>("CreatedbyUserGuid")
                        .HasColumnType("uuid");

                    b.Property<Guid>("EmployeeId")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("FromDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("ToDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int?>("TotalHours")
                        .HasColumnType("integer");

                    b.HasKey("Guid");

                    b.ToTable("TimeSheets");
                });

            modelBuilder.Entity("Excellerent.ApplicantTracking.Domain.Models.ApplicantAreaOfInterest", b =>
                {
                    b.HasOne("Excellerent.ApplicantTracking.Domain.Models.Applicant", "ApplicantInfo")
                        .WithMany()
                        .HasForeignKey("ApplicantInfoGuid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Excellerent.ApplicantTracking.Domain.Models.LUPositionToApply", "LuPositionToApply")
                        .WithMany()
                        .HasForeignKey("LuPositionToApplyGuid");

                    b.HasOne("Excellerent.ApplicantTracking.Domain.Models.LUProficiencyLevel", "ProficiencyLevel")
                        .WithMany()
                        .HasForeignKey("ProficiencyLevelGuid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ApplicantInfo");

                    b.Navigation("LuPositionToApply");

                    b.Navigation("ProficiencyLevel");
                });

            modelBuilder.Entity("Excellerent.ApplicantTracking.Domain.Models.Education", b =>
                {
<<<<<<< HEAD:Excellerent.SharedInfrastructure/Data/Migrations/20211116224935_intialMigration.Designer.cs
                    b.HasOne("Excellerent.ProjectManagement.Domain.Models.Project", "Project")
                        .WithMany()
                        .HasForeignKey("ProjectGuid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Project");
                });

            modelBuilder.Entity("Excellerent.ProjectManagement.Domain.Models.Project", b =>
                {
                    b.HasOne("Excellerent.ProjectManagement.Domain.Models.Client", "Client")
=======
                    b.HasOne("Excellerent.ApplicantTracking.Domain.Models.Applicant", "Applicant")
                        .WithMany()
                        .HasForeignKey("ApplicantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Excellerent.ApplicantTracking.Domain.Models.EducationProgramme", "EducationProgramme")
>>>>>>> 847cc349c24d9e9f3e1890b8465a599b7e2bc14e:Excellerent.SharedInfrastructure/Data/Migrations/20211114142200_Education data relation is updated.Designer.cs
                        .WithMany()
                        .HasForeignKey("EducationProgrammeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Excellerent.ApplicantTracking.Domain.Models.LUFieldOfStudy", "FieldOfStudy")
                        .WithMany()
                        .HasForeignKey("FieldOfStudyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Applicant");

                    b.Navigation("EducationProgramme");

                    b.Navigation("FieldOfStudy");
                });

            modelBuilder.Entity("Excellerent.Timesheet.Domain.Models.TimeEntry", b =>
                {
                    b.HasOne("Excellerent.Timesheet.Domain.Models.TimeSheet", null)
                        .WithMany("TimeEntry")
                        .HasForeignKey("TimeSheetGuid");
                });

            modelBuilder.Entity("Excellerent.Timesheet.Domain.Models.TimeSheet", b =>
                {
                    b.Navigation("TimeEntry");
                });
#pragma warning restore 612, 618
        }
    }
}
