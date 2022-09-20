using Microsoft.EntityFrameworkCore.Migrations;

namespace OnBoard.WebApp.Migrations
{
    public partial class Migration014 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CommissionMembers",
                table: "Commissions");

            migrationBuilder.AddColumn<int>(
                name: "CommissionMembersTotal",
                table: "Commissions",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Commissions",
                keyColumn: "CommissionID",
                keyValue: 1,
                column: "CommissionMembersTotal",
                value: 9);

            migrationBuilder.UpdateData(
                table: "Commissions",
                keyColumn: "CommissionID",
                keyValue: 2,
                column: "CommissionMembersTotal",
                value: 11);

            migrationBuilder.UpdateData(
                table: "Commissions",
                keyColumn: "CommissionID",
                keyValue: 4,
                column: "CommissionMembersTotal",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Commissions",
                keyColumn: "CommissionID",
                keyValue: 5,
                column: "CommissionMembersTotal",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Commissions",
                keyColumn: "CommissionID",
                keyValue: 7,
                column: "CommissionMembersTotal",
                value: 9);

            migrationBuilder.UpdateData(
                table: "Commissions",
                keyColumn: "CommissionID",
                keyValue: 8,
                column: "CommissionMembersTotal",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Commissions",
                keyColumn: "CommissionID",
                keyValue: 9,
                column: "CommissionMembersTotal",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Commissions",
                keyColumn: "CommissionID",
                keyValue: 10,
                column: "CommissionMembersTotal",
                value: 7);

            migrationBuilder.UpdateData(
                table: "Commissions",
                keyColumn: "CommissionID",
                keyValue: 11,
                column: "CommissionMembersTotal",
                value: 7);

            migrationBuilder.UpdateData(
                table: "Commissions",
                keyColumn: "CommissionID",
                keyValue: 12,
                column: "CommissionMembersTotal",
                value: 7);

            migrationBuilder.UpdateData(
                table: "Commissions",
                keyColumn: "CommissionID",
                keyValue: 13,
                column: "CommissionMembersTotal",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Commissions",
                keyColumn: "CommissionID",
                keyValue: 14,
                column: "CommissionMembersTotal",
                value: 9);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CommissionMembersTotal",
                table: "Commissions");

            migrationBuilder.AddColumn<int>(
                name: "CommissionMembers",
                table: "Commissions",
                type: "int",
                nullable: false,
                defaultValue: 0);

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
    }
}
