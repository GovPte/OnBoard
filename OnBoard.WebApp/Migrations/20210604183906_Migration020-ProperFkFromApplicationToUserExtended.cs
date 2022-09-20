using Microsoft.EntityFrameworkCore.Migrations;

namespace OnBoard.WebApp.Migrations
{
    public partial class Migration020ProperFkFromApplicationToUserExtended : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserExtendedID",
                table: "Applications",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Applications_UserExtendedID",
                table: "Applications",
                column: "UserExtendedID");

            migrationBuilder.AddForeignKey(
                name: "FK_Applications_UserExtended_UserExtendedID",
                table: "Applications",
                column: "UserExtendedID",
                principalTable: "UserExtended",
                principalColumn: "UserExtendedID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Applications_UserExtended_UserExtendedID",
                table: "Applications");

            migrationBuilder.DropIndex(
                name: "IX_Applications_UserExtendedID",
                table: "Applications");

            migrationBuilder.DropColumn(
                name: "UserExtendedID",
                table: "Applications");
        }
    }
}
