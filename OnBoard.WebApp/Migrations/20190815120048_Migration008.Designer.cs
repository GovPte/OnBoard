﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OnBoard.WebApp.Data;

namespace OnBoard.WebApp.Migrations
{
    [DbContext(typeof(DataModelDbContext))]
    [Migration("20190815120048_Migration008")]
    partial class Migration008
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("OnBoard.WebApp.Data.Tables.Application", b =>
                {
                    b.Property<int>("ApplicationID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("ApplicationRenewed");

                    b.Property<DateTime>("ApplicationSubmitted");

                    b.Property<string>("ApplicationUserID")
                        .HasMaxLength(450);

                    b.HasKey("ApplicationID");

                    b.ToTable("Applications");
                });

            modelBuilder.Entity("OnBoard.WebApp.Data.Tables.ApplicationQuestion", b =>
                {
                    b.Property<int>("ApplicationQuestionID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ApplicationQuestionNotes");

                    b.Property<string>("ApplicationQuestionText")
                        .IsRequired();

                    b.HasKey("ApplicationQuestionID");

                    b.ToTable("ApplicationQuestions");

                    b.HasData(
                        new
                        {
                            ApplicationQuestionID = 2,
                            ApplicationQuestionText = "Are you a registered voter of the City?"
                        },
                        new
                        {
                            ApplicationQuestionID = 3,
                            ApplicationQuestionText = "Have you previously served on a Board or Commission?"
                        },
                        new
                        {
                            ApplicationQuestionID = 4,
                            ApplicationQuestionText = "What Boards or Commissions have you previously served on?"
                        },
                        new
                        {
                            ApplicationQuestionID = 5,
                            ApplicationQuestionText = "Have you ever been convicted of a crime?"
                        },
                        new
                        {
                            ApplicationQuestionID = 6,
                            ApplicationQuestionText = "If yes, please explain the nature of the offense:"
                        },
                        new
                        {
                            ApplicationQuestionID = 7,
                            ApplicationQuestionText = "Please list any community involvement, employment, education or other expertise that pertains to the Board or Commission that you are applying for:"
                        });
                });

            modelBuilder.Entity("OnBoard.WebApp.Data.Tables.Commission", b =>
                {
                    b.Property<int>("CommissionID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CommissionDescription");

                    b.Property<int>("CommissionMembers");

                    b.Property<string>("CommissionName")
                        .IsRequired();

                    b.HasKey("CommissionID");

                    b.ToTable("Commissions");

                    b.HasData(
                        new
                        {
                            CommissionID = 1,
                            CommissionMembers = 0,
                            CommissionName = "Arts and Cultural Diversity Commission"
                        },
                        new
                        {
                            CommissionID = 2,
                            CommissionDescription = "aesthetic improvements, beautify the City",
                            CommissionMembers = 0,
                            CommissionName = "Beautification Commission"
                        },
                        new
                        {
                            CommissionID = 3,
                            CommissionDescription = "guides conduct of City officials",
                            CommissionMembers = 0,
                            CommissionName = "Board of Ethics"
                        },
                        new
                        {
                            CommissionID = 4,
                            CommissionDescription = "assessment appeals",
                            CommissionMembers = 0,
                            CommissionName = "Board of Review"
                        },
                        new
                        {
                            CommissionID = 5,
                            CommissionDescription = "system of personnel administration",
                            CommissionMembers = 0,
                            CommissionName = "Civil Service Commission"
                        },
                        new
                        {
                            CommissionID = 6,
                            CommissionDescription = "hear appeals on refusal to grant an application for a permit or a modification to the provisions of this Code covering the manner of construction ormaterials to be used in the erection, alteration or repair of a building or structure or otherwise makes a decision pursuant or related to the Code",
                            CommissionMembers = 0,
                            CommissionName = "Construction Board of Appeals"
                        },
                        new
                        {
                            CommissionID = 7,
                            CommissionDescription = "manages right-of-way improvements in DDA corridor",
                            CommissionMembers = 0,
                            CommissionName = "Downtown Development Authority"
                        },
                        new
                        {
                            CommissionID = 8,
                            CommissionDescription = "oversees senior citizen housing",
                            CommissionMembers = 0,
                            CommissionName = "Housing Commission"
                        },
                        new
                        {
                            CommissionID = 9,
                            CommissionDescription = "library services",
                            CommissionMembers = 0,
                            CommissionName = "Library Commission"
                        },
                        new
                        {
                            CommissionID = 10,
                            CommissionDescription = "recommends/sets salaries for elected officials",
                            CommissionMembers = 0,
                            CommissionName = "Local Officers Compensation Commission"
                        },
                        new
                        {
                            CommissionID = 11,
                            CommissionDescription = "makes recommendations to council relative to park programs, projects or facilities",
                            CommissionMembers = 0,
                            CommissionName = "Parks Commission"
                        },
                        new
                        {
                            CommissionID = 12,
                            CommissionDescription = "City planning, land use and zoning",
                            CommissionMembers = 0,
                            CommissionName = "Planning Commission"
                        },
                        new
                        {
                            CommissionID = 13,
                            CommissionDescription = "recreation services",
                            CommissionMembers = 0,
                            CommissionName = "Recreational Authority of Roseville and Eastpointe"
                        },
                        new
                        {
                            CommissionID = 14,
                            CommissionDescription = "grants variances to City Codes",
                            CommissionMembers = 0,
                            CommissionName = "Zoning Board of Appeals"
                        });
                });

            modelBuilder.Entity("OnBoard.WebApp.Data.Tables.CommissionApplication", b =>
                {
                    b.Property<int>("CommissionID");

                    b.Property<int>("ApplicationID");

                    b.HasKey("CommissionID", "ApplicationID");

                    b.HasIndex("ApplicationID");

                    b.ToTable("CommissionApplications");
                });

            modelBuilder.Entity("OnBoard.WebApp.Data.Tables.CommissionMember", b =>
                {
                    b.Property<int>("CommissionID");

                    b.Property<int>("UserExtendedID");

                    b.HasKey("CommissionID", "UserExtendedID");

                    b.HasIndex("UserExtendedID");

                    b.ToTable("CommissionMembers");
                });

            modelBuilder.Entity("OnBoard.WebApp.Data.Tables.QuestionAnswer", b =>
                {
                    b.Property<int>("QuestionAnswerID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ApplicationID");

                    b.Property<int>("ApplicationQuestionID");

                    b.Property<string>("QuestionAnswerNotes");

                    b.Property<string>("QuestionAnswerText")
                        .IsRequired();

                    b.HasKey("QuestionAnswerID");

                    b.HasIndex("ApplicationID");

                    b.HasIndex("ApplicationQuestionID");

                    b.ToTable("QuestionAnswers");
                });

            modelBuilder.Entity("OnBoard.WebApp.Data.Tables.UserExtended", b =>
                {
                    b.Property<int>("UserExtendedID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("UserExtendedAddressExtended");

                    b.Property<string>("UserExtendedAddressStreet")
                        .IsRequired();

                    b.Property<string>("UserExtendedNameFirst")
                        .IsRequired();

                    b.Property<string>("UserExtendedNameLast")
                        .IsRequired();

                    b.Property<string>("UserExtendedNameMiddle");

                    b.Property<string>("UserExtendedPhoneCell");

                    b.Property<string>("UserExtendedPhoneHome");

                    b.Property<string>("UserExtendedUserId")
                        .HasMaxLength(450);

                    b.HasKey("UserExtendedID");

                    b.ToTable("UserExtended");
                });

            modelBuilder.Entity("OnBoard.WebApp.Data.Tables.CommissionApplication", b =>
                {
                    b.HasOne("OnBoard.WebApp.Data.Tables.Application", "Application")
                        .WithMany()
                        .HasForeignKey("ApplicationID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("OnBoard.WebApp.Data.Tables.Commission", "Commission")
                        .WithMany()
                        .HasForeignKey("CommissionID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("OnBoard.WebApp.Data.Tables.CommissionMember", b =>
                {
                    b.HasOne("OnBoard.WebApp.Data.Tables.Commission", "Commission")
                        .WithMany()
                        .HasForeignKey("CommissionID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("OnBoard.WebApp.Data.Tables.UserExtended", "UserExtended")
                        .WithMany()
                        .HasForeignKey("UserExtendedID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("OnBoard.WebApp.Data.Tables.QuestionAnswer", b =>
                {
                    b.HasOne("OnBoard.WebApp.Data.Tables.Application", "Application")
                        .WithMany()
                        .HasForeignKey("ApplicationID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("OnBoard.WebApp.Data.Tables.ApplicationQuestion", "ApplicationQuestion")
                        .WithMany()
                        .HasForeignKey("ApplicationQuestionID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
