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
    [Migration("20200731175654_Migration017")]
    partial class Migration017
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("OnBoard.WebApp.Data.Tables.Address", b =>
                {
                    b.Property<int>("AddressID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AddressExtended")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AddressStreet")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("AddressZipCode")
                        .HasColumnType("int");

                    b.Property<int>("MunicipalityID")
                        .HasColumnType("int");

                    b.HasKey("AddressID");

                    b.HasIndex("MunicipalityID");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("OnBoard.WebApp.Data.Tables.Application", b =>
                {
                    b.Property<int>("ApplicationID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("ApplicationArchived")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("ApplicationRenewed")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ApplicationSubmitted")
                        .HasColumnType("datetime2");

                    b.Property<string>("ApplicationUserID")
                        .HasColumnType("nvarchar(450)")
                        .HasMaxLength(450);

                    b.HasKey("ApplicationID");

                    b.ToTable("Applications");
                });

            modelBuilder.Entity("OnBoard.WebApp.Data.Tables.ApplicationQuestion", b =>
                {
                    b.Property<int>("ApplicationQuestionID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ApplicationQuestionNotes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ApplicationQuestionText")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

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
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("CommissionActive")
                        .HasColumnType("bit");

                    b.Property<string>("CommissionDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CommissionMembersTotal")
                        .HasColumnType("int");

                    b.Property<string>("CommissionName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OrganizationID")
                        .HasColumnType("int");

                    b.HasKey("CommissionID");

                    b.HasIndex("OrganizationID");

                    b.ToTable("Commissions");

                    b.HasData(
                        new
                        {
                            CommissionID = 1,
                            CommissionActive = false,
                            CommissionMembersTotal = 9,
                            CommissionName = "Arts and Cultural Diversity Commission",
                            OrganizationID = 1
                        },
                        new
                        {
                            CommissionID = 2,
                            CommissionActive = false,
                            CommissionDescription = "aesthetic improvements, beautify the City",
                            CommissionMembersTotal = 11,
                            CommissionName = "Beautification Commission",
                            OrganizationID = 1
                        },
                        new
                        {
                            CommissionID = 3,
                            CommissionActive = false,
                            CommissionDescription = "guides conduct of City officials",
                            CommissionMembersTotal = 0,
                            CommissionName = "Board of Ethics",
                            OrganizationID = 1
                        },
                        new
                        {
                            CommissionID = 4,
                            CommissionActive = false,
                            CommissionDescription = "assessment appeals",
                            CommissionMembersTotal = 5,
                            CommissionName = "Board of Review",
                            OrganizationID = 1
                        },
                        new
                        {
                            CommissionID = 5,
                            CommissionActive = false,
                            CommissionDescription = "system of personnel administration",
                            CommissionMembersTotal = 3,
                            CommissionName = "Civil Service Commission",
                            OrganizationID = 1
                        },
                        new
                        {
                            CommissionID = 6,
                            CommissionActive = false,
                            CommissionDescription = "hear appeals on refusal to grant an application for a permit or a modification to the provisions of this Code covering the manner of construction ormaterials to be used in the erection, alteration or repair of a building or structure or otherwise makes a decision pursuant or related to the Code",
                            CommissionMembersTotal = 0,
                            CommissionName = "Construction Board of Appeals",
                            OrganizationID = 1
                        },
                        new
                        {
                            CommissionID = 7,
                            CommissionActive = false,
                            CommissionDescription = "manages right-of-way improvements in DDA corridor",
                            CommissionMembersTotal = 9,
                            CommissionName = "Downtown Development Authority",
                            OrganizationID = 1
                        },
                        new
                        {
                            CommissionID = 8,
                            CommissionActive = false,
                            CommissionDescription = "oversees senior citizen housing",
                            CommissionMembersTotal = 5,
                            CommissionName = "Housing Commission",
                            OrganizationID = 1
                        },
                        new
                        {
                            CommissionID = 9,
                            CommissionActive = false,
                            CommissionDescription = "library services",
                            CommissionMembersTotal = 5,
                            CommissionName = "Library Commission",
                            OrganizationID = 1
                        },
                        new
                        {
                            CommissionID = 10,
                            CommissionActive = false,
                            CommissionDescription = "recommends/sets salaries for elected officials",
                            CommissionMembersTotal = 7,
                            CommissionName = "Local Officers Compensation Commission",
                            OrganizationID = 1
                        },
                        new
                        {
                            CommissionID = 11,
                            CommissionActive = false,
                            CommissionDescription = "makes recommendations to council relative to park programs, projects or facilities",
                            CommissionMembersTotal = 7,
                            CommissionName = "Parks Commission",
                            OrganizationID = 1
                        },
                        new
                        {
                            CommissionID = 12,
                            CommissionActive = false,
                            CommissionDescription = "City planning, land use and zoning",
                            CommissionMembersTotal = 7,
                            CommissionName = "Planning Commission",
                            OrganizationID = 1
                        },
                        new
                        {
                            CommissionID = 13,
                            CommissionActive = false,
                            CommissionDescription = "recreation services",
                            CommissionMembersTotal = 5,
                            CommissionName = "Recreational Authority of Roseville and Eastpointe",
                            OrganizationID = 1
                        },
                        new
                        {
                            CommissionID = 14,
                            CommissionActive = false,
                            CommissionDescription = "grants variances to City Codes",
                            CommissionMembersTotal = 9,
                            CommissionName = "Zoning Board of Appeals",
                            OrganizationID = 1
                        });
                });

            modelBuilder.Entity("OnBoard.WebApp.Data.Tables.CommissionApplication", b =>
                {
                    b.Property<int>("CommissionApplicationID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ApplicationID")
                        .HasColumnType("int");

                    b.Property<int>("CommissionID")
                        .HasColumnType("int");

                    b.HasKey("CommissionApplicationID");

                    b.HasIndex("ApplicationID");

                    b.HasIndex("CommissionID");

                    b.ToTable("CommissionApplications");
                });

            modelBuilder.Entity("OnBoard.WebApp.Data.Tables.CommissionMember", b =>
                {
                    b.Property<int>("CommissionMemberID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CommissionID")
                        .HasColumnType("int");

                    b.Property<string>("CommissionTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserExtendedID")
                        .HasColumnType("int");

                    b.HasKey("CommissionMemberID");

                    b.HasIndex("CommissionID");

                    b.HasIndex("UserExtendedID");

                    b.ToTable("CommissionMembers");
                });

            modelBuilder.Entity("OnBoard.WebApp.Data.Tables.Municipality", b =>
                {
                    b.Property<int>("MunicipalityID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("MunicipalityName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StateID")
                        .HasColumnType("int");

                    b.HasKey("MunicipalityID");

                    b.HasIndex("StateID");

                    b.ToTable("Municipalities");

                    b.HasData(
                        new
                        {
                            MunicipalityID = 1,
                            MunicipalityName = "Eastpointe",
                            StateID = 1
                        },
                        new
                        {
                            MunicipalityID = 2,
                            MunicipalityName = "Roseville",
                            StateID = 1
                        },
                        new
                        {
                            MunicipalityID = 3,
                            MunicipalityName = "Detroit",
                            StateID = 1
                        },
                        new
                        {
                            MunicipalityID = 4,
                            MunicipalityName = "Clinton Township",
                            StateID = 1
                        },
                        new
                        {
                            MunicipalityID = 5,
                            MunicipalityName = "St. Clair Shores",
                            StateID = 1
                        },
                        new
                        {
                            MunicipalityID = 6,
                            MunicipalityName = "Fraser",
                            StateID = 1
                        },
                        new
                        {
                            MunicipalityID = 7,
                            MunicipalityName = "Warren",
                            StateID = 1
                        },
                        new
                        {
                            MunicipalityID = 8,
                            MunicipalityName = "Centerline",
                            StateID = 1
                        });
                });

            modelBuilder.Entity("OnBoard.WebApp.Data.Tables.Organization", b =>
                {
                    b.Property<int>("OrganizationID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AddressID")
                        .HasColumnType("int");

                    b.Property<string>("OrganizationDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OrganizationName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OrganizationWebsite")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("OrganizationID");

                    b.HasIndex("AddressID");

                    b.ToTable("Organizations");

                    b.HasData(
                        new
                        {
                            OrganizationID = 1,
                            OrganizationName = "City of Eastpointe",
                            OrganizationWebsite = "http://www.CityOfEastpointe.net"
                        });
                });

            modelBuilder.Entity("OnBoard.WebApp.Data.Tables.QuestionAnswer", b =>
                {
                    b.Property<int>("QuestionAnswerID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ApplicationID")
                        .HasColumnType("int");

                    b.Property<int>("ApplicationQuestionID")
                        .HasColumnType("int");

                    b.Property<string>("QuestionAnswerNotes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("QuestionAnswerText")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("QuestionAnswerID");

                    b.HasIndex("ApplicationID");

                    b.HasIndex("ApplicationQuestionID");

                    b.ToTable("QuestionAnswers");
                });

            modelBuilder.Entity("OnBoard.WebApp.Data.Tables.Setting", b =>
                {
                    b.Property<int>("SettingID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("SettingName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SettingValue")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SettingID");

                    b.ToTable("Settings");

                    b.HasData(
                        new
                        {
                            SettingID = 1,
                            SettingName = "ArchiveInMonths",
                            SettingValue = "24"
                        });
                });

            modelBuilder.Entity("OnBoard.WebApp.Data.Tables.State", b =>
                {
                    b.Property<int>("StateID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("StateName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StateNamePostal")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StateID");

                    b.ToTable("States");

                    b.HasData(
                        new
                        {
                            StateID = 1,
                            StateName = "Michigan",
                            StateNamePostal = "MI"
                        });
                });

            modelBuilder.Entity("OnBoard.WebApp.Data.Tables.UserExtended", b =>
                {
                    b.Property<int>("UserExtendedID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("UserExtendedAddressExtended")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserExtendedAddressStreet")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserExtendedNameFirst")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserExtendedNameLast")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserExtendedNameMiddle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserExtendedPhoneCell")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserExtendedPhoneHome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserExtendedUserId")
                        .HasColumnType("nvarchar(450)")
                        .HasMaxLength(450);

                    b.HasKey("UserExtendedID");

                    b.ToTable("UserExtended");
                });

            modelBuilder.Entity("OnBoard.WebApp.Data.Tables.Address", b =>
                {
                    b.HasOne("OnBoard.WebApp.Data.Tables.Municipality", "Municipality")
                        .WithMany()
                        .HasForeignKey("MunicipalityID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("OnBoard.WebApp.Data.Tables.Commission", b =>
                {
                    b.HasOne("OnBoard.WebApp.Data.Tables.Organization", "Organization")
                        .WithMany()
                        .HasForeignKey("OrganizationID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("OnBoard.WebApp.Data.Tables.CommissionApplication", b =>
                {
                    b.HasOne("OnBoard.WebApp.Data.Tables.Application", "Application")
                        .WithMany()
                        .HasForeignKey("ApplicationID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OnBoard.WebApp.Data.Tables.Commission", "Commission")
                        .WithMany()
                        .HasForeignKey("CommissionID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("OnBoard.WebApp.Data.Tables.CommissionMember", b =>
                {
                    b.HasOne("OnBoard.WebApp.Data.Tables.Commission", "Commission")
                        .WithMany()
                        .HasForeignKey("CommissionID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OnBoard.WebApp.Data.Tables.UserExtended", "UserExtended")
                        .WithMany()
                        .HasForeignKey("UserExtendedID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("OnBoard.WebApp.Data.Tables.Municipality", b =>
                {
                    b.HasOne("OnBoard.WebApp.Data.Tables.State", "State")
                        .WithMany()
                        .HasForeignKey("StateID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("OnBoard.WebApp.Data.Tables.Organization", b =>
                {
                    b.HasOne("OnBoard.WebApp.Data.Tables.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressID");
                });

            modelBuilder.Entity("OnBoard.WebApp.Data.Tables.QuestionAnswer", b =>
                {
                    b.HasOne("OnBoard.WebApp.Data.Tables.Application", "Application")
                        .WithMany()
                        .HasForeignKey("ApplicationID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OnBoard.WebApp.Data.Tables.ApplicationQuestion", "ApplicationQuestion")
                        .WithMany()
                        .HasForeignKey("ApplicationQuestionID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
