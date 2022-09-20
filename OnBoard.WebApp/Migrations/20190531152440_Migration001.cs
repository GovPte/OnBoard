using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OnBoard.WebApp.Migrations
{
    public partial class Migration001 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Applications",
                columns: table => new
                {
                    ApplicationID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ApplicationSubmitted = table.Column<DateTime>(nullable: false),
                    ApplicationUserID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Applications", x => x.ApplicationID);
                });

            migrationBuilder.CreateTable(
                name: "Commissions",
                columns: table => new
                {
                    CommissionID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CommissionName = table.Column<string>(nullable: false),
                    CommissionDescription = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Commissions", x => x.CommissionID);
                });

            migrationBuilder.CreateTable(
                name: "UserExtended",
                columns: table => new
                {
                    UserExtendedID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserExtendedAddressStreet = table.Column<string>(nullable: true),
                    UserExtendedAddressExtended = table.Column<string>(nullable: true),
                    UserExtendedPhoneHome = table.Column<string>(nullable: true),
                    UserExtendedPhoneCell = table.Column<string>(nullable: true),
                    UserExtendedEmail = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserExtended", x => x.UserExtendedID);
                });

            migrationBuilder.CreateTable(
                name: "ApplicationQuestions",
                columns: table => new
                {
                    ApplicationQuestionID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ApplicationQuestionText = table.Column<string>(nullable: true),
                    ApplicationQuestionNotes = table.Column<string>(nullable: true),
                    ApplicationID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationQuestions", x => x.ApplicationQuestionID);
                    table.ForeignKey(
                        name: "FK_ApplicationQuestions_Applications_ApplicationID",
                        column: x => x.ApplicationID,
                        principalTable: "Applications",
                        principalColumn: "ApplicationID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CommissionApplications",
                columns: table => new
                {
                    ApplicationID = table.Column<int>(nullable: false),
                    CommissionID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommissionApplications", x => new { x.CommissionID, x.ApplicationID });
                    table.ForeignKey(
                        name: "FK_CommissionApplications_Applications_ApplicationID",
                        column: x => x.ApplicationID,
                        principalTable: "Applications",
                        principalColumn: "ApplicationID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CommissionApplications_Commissions_CommissionID",
                        column: x => x.CommissionID,
                        principalTable: "Commissions",
                        principalColumn: "CommissionID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "QuestionAnswers",
                columns: table => new
                {
                    QuestionAnswerID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    QuestionAnswerText = table.Column<string>(nullable: false),
                    QuestionAnswerNotes = table.Column<string>(nullable: true),
                    ApplicationQuestionID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionAnswers", x => x.QuestionAnswerID);
                    table.ForeignKey(
                        name: "FK_QuestionAnswers_ApplicationQuestions_ApplicationQuestionID",
                        column: x => x.ApplicationQuestionID,
                        principalTable: "ApplicationQuestions",
                        principalColumn: "ApplicationQuestionID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Commissions",
                columns: new[] { "CommissionID", "CommissionDescription", "CommissionName" },
                values: new object[,]
                {
                    { 1, null, "Arts and Cultural Diversity Commission" },
                    { 2, "aesthetic improvements, beautify the City", "Beautification Commission" },
                    { 3, "guides conduct of City officials", "Board of Ethics" },
                    { 4, "assessment appeals", "Board of Review" },
                    { 5, "system of personnel administration", "Civil Service Commission" },
                    { 6, "hear appeals on refusal to grant an application for a permit or a modification to the provisions of this Code covering the manner of construction ormaterials to be used in the erection, alteration or repair of a building or structure or otherwise makes a decision pursuant or related to the Code", "Construction Board of Appeals" },
                    { 7, "manages right-of-way improvements in DDA corridor", "Downtown Development Authority" },
                    { 8, "oversees senior citizen housing", "Housing Commission" },
                    { 9, "library services", "Library Commission" },
                    { 10, "recommends/sets salaries for elected officials", "Local Officers Compensation Commission" },
                    { 11, "makes recommendations to council relative to park programs, projects or facilities", "Parks Commission" },
                    { 12, "City planning, land use and zoning", "Planning Commission" },
                    { 13, "recreation services", "Recreational Authority of Roseville and Eastpointe" },
                    { 14, "grants variances to City Codes", "Zoning Board of Appeals" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationQuestions_ApplicationID",
                table: "ApplicationQuestions",
                column: "ApplicationID");

            migrationBuilder.CreateIndex(
                name: "IX_CommissionApplications_ApplicationID",
                table: "CommissionApplications",
                column: "ApplicationID");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionAnswers_ApplicationQuestionID",
                table: "QuestionAnswers",
                column: "ApplicationQuestionID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CommissionApplications");

            migrationBuilder.DropTable(
                name: "QuestionAnswers");

            migrationBuilder.DropTable(
                name: "UserExtended");

            migrationBuilder.DropTable(
                name: "Commissions");

            migrationBuilder.DropTable(
                name: "ApplicationQuestions");

            migrationBuilder.DropTable(
                name: "Applications");
        }
    }
}
