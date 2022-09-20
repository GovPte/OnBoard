using Microsoft.EntityFrameworkCore.Migrations;

namespace OnBoard.WebApp.Migrations
{
    public partial class Migration023UpdatedUserServiceAndNames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CommissionMembers_UserExtended_UserExtendedID",
                table: "CommissionMembers");

            migrationBuilder.DropIndex(
                name: "IX_CommissionMembers_UserExtendedID",
                table: "CommissionMembers");

            migrationBuilder.DropColumn(
                name: "UserExtendedID",
                table: "CommissionMembers");

            migrationBuilder.AddColumn<string>(
                name: "AspNetUserId",
                table: "CommissionMembers",
                type: "nvarchar(450)",
                maxLength: 450,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AspNetUserId",
                table: "CommissionMembers");

            migrationBuilder.AddColumn<int>(
                name: "UserExtendedID",
                table: "CommissionMembers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_CommissionMembers_UserExtendedID",
                table: "CommissionMembers",
                column: "UserExtendedID");

            migrationBuilder.AddForeignKey(
                name: "FK_CommissionMembers_UserExtended_UserExtendedID",
                table: "CommissionMembers",
                column: "UserExtendedID",
                principalTable: "UserExtended",
                principalColumn: "UserExtendedID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
