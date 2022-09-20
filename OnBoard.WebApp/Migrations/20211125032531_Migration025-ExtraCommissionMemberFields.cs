using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OnBoard.WebApp.Migrations
{
    public partial class Migration025ExtraCommissionMemberFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CommissionMemberAppointmentNotes",
                table: "CommissionMembers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CommissionMemberResignationRemovalNotes",
                table: "CommissionMembers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "TermEndDate",
                table: "CommissionMembers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "TermStartDate",
                table: "CommissionMembers",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CommissionMemberAppointmentNotes",
                table: "CommissionMembers");

            migrationBuilder.DropColumn(
                name: "CommissionMemberResignationRemovalNotes",
                table: "CommissionMembers");

            migrationBuilder.DropColumn(
                name: "TermEndDate",
                table: "CommissionMembers");

            migrationBuilder.DropColumn(
                name: "TermStartDate",
                table: "CommissionMembers");
        }
    }
}
