using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OnBoard.WebApp.Migrations
{
    public partial class Migration004 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ApplicationID",
                table: "QuestionAnswers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "ApplicationRenewed",
                table: "Applications",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_QuestionAnswers_ApplicationID",
                table: "QuestionAnswers",
                column: "ApplicationID");

            migrationBuilder.AddForeignKey(
                name: "FK_QuestionAnswers_Applications_ApplicationID",
                table: "QuestionAnswers",
                column: "ApplicationID",
                principalTable: "Applications",
                principalColumn: "ApplicationID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QuestionAnswers_Applications_ApplicationID",
                table: "QuestionAnswers");

            migrationBuilder.DropIndex(
                name: "IX_QuestionAnswers_ApplicationID",
                table: "QuestionAnswers");

            migrationBuilder.DropColumn(
                name: "ApplicationID",
                table: "QuestionAnswers");

            migrationBuilder.DropColumn(
                name: "ApplicationRenewed",
                table: "Applications");
        }
    }
}
