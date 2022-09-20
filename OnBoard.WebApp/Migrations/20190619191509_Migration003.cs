using Microsoft.EntityFrameworkCore.Migrations;

namespace OnBoard.WebApp.Migrations
{
    public partial class Migration003 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationQuestions_Applications_ApplicationID",
                table: "ApplicationQuestions");

            migrationBuilder.DropIndex(
                name: "IX_ApplicationQuestions_ApplicationID",
                table: "ApplicationQuestions");

            migrationBuilder.DropColumn(
                name: "ApplicationID",
                table: "ApplicationQuestions");

            migrationBuilder.AlterColumn<string>(
                name: "UserExtendedNameLast",
                table: "UserExtended",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserExtendedNameFirst",
                table: "UserExtended",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserExtendedEmail",
                table: "UserExtended",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserExtendedAddressStreet",
                table: "UserExtended",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationQuestionText",
                table: "ApplicationQuestions",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserExtendedNameLast",
                table: "UserExtended",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "UserExtendedNameFirst",
                table: "UserExtended",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "UserExtendedEmail",
                table: "UserExtended",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "UserExtendedAddressStreet",
                table: "UserExtended",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationQuestionText",
                table: "ApplicationQuestions",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<int>(
                name: "ApplicationID",
                table: "ApplicationQuestions",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationQuestions_ApplicationID",
                table: "ApplicationQuestions",
                column: "ApplicationID");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationQuestions_Applications_ApplicationID",
                table: "ApplicationQuestions",
                column: "ApplicationID",
                principalTable: "Applications",
                principalColumn: "ApplicationID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
