using Microsoft.EntityFrameworkCore.Migrations;

namespace OnBoard.WebApp.Migrations
{
    public partial class Migration013 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_CommissionMembers",
                table: "CommissionMembers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CommissionApplications",
                table: "CommissionApplications");

            migrationBuilder.AddColumn<int>(
                name: "CommissionMemberID",
                table: "CommissionMembers",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "CommissionApplicationID",
                table: "CommissionApplications",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CommissionMembers",
                table: "CommissionMembers",
                column: "CommissionMemberID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CommissionApplications",
                table: "CommissionApplications",
                column: "CommissionApplicationID");

            migrationBuilder.CreateIndex(
                name: "IX_CommissionMembers_CommissionID",
                table: "CommissionMembers",
                column: "CommissionID");

            migrationBuilder.CreateIndex(
                name: "IX_CommissionApplications_CommissionID",
                table: "CommissionApplications",
                column: "CommissionID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_CommissionMembers",
                table: "CommissionMembers");

            migrationBuilder.DropIndex(
                name: "IX_CommissionMembers_CommissionID",
                table: "CommissionMembers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CommissionApplications",
                table: "CommissionApplications");

            migrationBuilder.DropIndex(
                name: "IX_CommissionApplications_CommissionID",
                table: "CommissionApplications");

            migrationBuilder.DropColumn(
                name: "CommissionMemberID",
                table: "CommissionMembers");

            migrationBuilder.DropColumn(
                name: "CommissionApplicationID",
                table: "CommissionApplications");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CommissionMembers",
                table: "CommissionMembers",
                columns: new[] { "CommissionID", "UserExtendedID" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_CommissionApplications",
                table: "CommissionApplications",
                columns: new[] { "CommissionID", "ApplicationID" });
        }
    }
}
