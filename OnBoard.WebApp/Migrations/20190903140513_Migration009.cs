using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OnBoard.WebApp.Migrations
{
    public partial class Migration009 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CommissionTitle",
                table: "CommissionMembers",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                table: "CommissionMembers",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                table: "CommissionMembers",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Commissions",
                keyColumn: "CommissionID",
                keyValue: 1,
                column: "CommissionMembers",
                value: 9);

            migrationBuilder.UpdateData(
                table: "Commissions",
                keyColumn: "CommissionID",
                keyValue: 2,
                column: "CommissionMembers",
                value: 11);

            migrationBuilder.UpdateData(
                table: "Commissions",
                keyColumn: "CommissionID",
                keyValue: 4,
                column: "CommissionMembers",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Commissions",
                keyColumn: "CommissionID",
                keyValue: 5,
                column: "CommissionMembers",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Commissions",
                keyColumn: "CommissionID",
                keyValue: 7,
                column: "CommissionMembers",
                value: 9);

            migrationBuilder.UpdateData(
                table: "Commissions",
                keyColumn: "CommissionID",
                keyValue: 8,
                column: "CommissionMembers",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Commissions",
                keyColumn: "CommissionID",
                keyValue: 9,
                column: "CommissionMembers",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Commissions",
                keyColumn: "CommissionID",
                keyValue: 10,
                column: "CommissionMembers",
                value: 7);

            migrationBuilder.UpdateData(
                table: "Commissions",
                keyColumn: "CommissionID",
                keyValue: 11,
                column: "CommissionMembers",
                value: 7);

            migrationBuilder.UpdateData(
                table: "Commissions",
                keyColumn: "CommissionID",
                keyValue: 12,
                column: "CommissionMembers",
                value: 7);

            migrationBuilder.UpdateData(
                table: "Commissions",
                keyColumn: "CommissionID",
                keyValue: 13,
                column: "CommissionMembers",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Commissions",
                keyColumn: "CommissionID",
                keyValue: 14,
                column: "CommissionMembers",
                value: 9);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CommissionTitle",
                table: "CommissionMembers");

            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "CommissionMembers");

            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "CommissionMembers");

            migrationBuilder.UpdateData(
                table: "Commissions",
                keyColumn: "CommissionID",
                keyValue: 1,
                column: "CommissionMembers",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Commissions",
                keyColumn: "CommissionID",
                keyValue: 2,
                column: "CommissionMembers",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Commissions",
                keyColumn: "CommissionID",
                keyValue: 4,
                column: "CommissionMembers",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Commissions",
                keyColumn: "CommissionID",
                keyValue: 5,
                column: "CommissionMembers",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Commissions",
                keyColumn: "CommissionID",
                keyValue: 7,
                column: "CommissionMembers",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Commissions",
                keyColumn: "CommissionID",
                keyValue: 8,
                column: "CommissionMembers",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Commissions",
                keyColumn: "CommissionID",
                keyValue: 9,
                column: "CommissionMembers",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Commissions",
                keyColumn: "CommissionID",
                keyValue: 10,
                column: "CommissionMembers",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Commissions",
                keyColumn: "CommissionID",
                keyValue: 11,
                column: "CommissionMembers",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Commissions",
                keyColumn: "CommissionID",
                keyValue: 12,
                column: "CommissionMembers",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Commissions",
                keyColumn: "CommissionID",
                keyValue: 13,
                column: "CommissionMembers",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Commissions",
                keyColumn: "CommissionID",
                keyValue: 14,
                column: "CommissionMembers",
                value: 0);
        }
    }
}
