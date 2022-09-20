using Microsoft.EntityFrameworkCore.Migrations;

namespace OnBoard.WebApp.Migrations
{
    public partial class Migration002 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserExtendedNameFirst",
                table: "UserExtended",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserExtendedNameLast",
                table: "UserExtended",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserExtendedNameMiddle",
                table: "UserExtended",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserExtendedNameFirst",
                table: "UserExtended");

            migrationBuilder.DropColumn(
                name: "UserExtendedNameLast",
                table: "UserExtended");

            migrationBuilder.DropColumn(
                name: "UserExtendedNameMiddle",
                table: "UserExtended");
        }
    }
}
