using Microsoft.EntityFrameworkCore.Migrations;

namespace OnBoard.WebApp.Migrations
{
    public partial class Migration007 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserExtendedUserId",
                table: "UserExtended",
                maxLength: 450,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserExtendedUserId",
                table: "UserExtended");
        }
    }
}
