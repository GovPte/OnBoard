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
    [Migration("20190621192133_Migration006")]
    partial class Migration006
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
                });

            modelBuilder.Entity("OnBoard.WebApp.Data.Tables.Commission", b =>
                {
                    b.Property<int>("CommissionID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CommissionDescription");

                    b.Property<string>("CommissionName")
                        .IsRequired();

                    b.HasKey("CommissionID");

                    b.ToTable("Commissions");

                    b.HasData(
                        new
                        {
                            CommissionID = 1,
                            CommissionName = "Arts and Cultural Diversity Commission"
                        },
                        new
                        {
                            CommissionID = 2,
                            CommissionDescription = "aesthetic improvements, beautify the City",
                            CommissionName = "Beautification Commission"
                        },
                        new
                        {
                            CommissionID = 3,
                            CommissionDescription = "guides conduct of City officials",
                            CommissionName = "Board of Ethics"
                        },
                        new
                        {
                            CommissionID = 4,
                            CommissionDescription = "assessment appeals",
                            CommissionName = "Board of Review"
                        },
                        new
                        {
                            CommissionID = 5,
                            CommissionDescription = "system of personnel administration",
                            CommissionName = "Civil Service Commission"
                        },
                        new
                        {
                            CommissionID = 6,
                            CommissionDescription = "hear appeals on refusal to grant an application for a permit or a modification to the provisions of this Code covering the manner of construction ormaterials to be used in the erection, alteration or repair of a building or structure or otherwise makes a decision pursuant or related to the Code",
                            CommissionName = "Construction Board of Appeals"
                        },
                        new
                        {
                            CommissionID = 7,
                            CommissionDescription = "manages right-of-way improvements in DDA corridor",
                            CommissionName = "Downtown Development Authority"
                        },
                        new
                        {
                            CommissionID = 8,
                            CommissionDescription = "oversees senior citizen housing",
                            CommissionName = "Housing Commission"
                        },
                        new
                        {
                            CommissionID = 9,
                            CommissionDescription = "library services",
                            CommissionName = "Library Commission"
                        },
                        new
                        {
                            CommissionID = 10,
                            CommissionDescription = "recommends/sets salaries for elected officials",
                            CommissionName = "Local Officers Compensation Commission"
                        },
                        new
                        {
                            CommissionID = 11,
                            CommissionDescription = "makes recommendations to council relative to park programs, projects or facilities",
                            CommissionName = "Parks Commission"
                        },
                        new
                        {
                            CommissionID = 12,
                            CommissionDescription = "City planning, land use and zoning",
                            CommissionName = "Planning Commission"
                        },
                        new
                        {
                            CommissionID = 13,
                            CommissionDescription = "recreation services",
                            CommissionName = "Recreational Authority of Roseville and Eastpointe"
                        },
                        new
                        {
                            CommissionID = 14,
                            CommissionDescription = "grants variances to City Codes",
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
