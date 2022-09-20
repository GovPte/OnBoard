using Microsoft.EntityFrameworkCore.Migrations;

namespace OnBoard.WebApp.Migrations
{
    public partial class Migration008 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CommissionMembers",
                table: "Commissions",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "CommissionMembers",
                columns: table => new
                {
                    CommissionID = table.Column<int>(nullable: false),
                    UserExtendedID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommissionMembers", x => new { x.CommissionID, x.UserExtendedID });
                    table.ForeignKey(
                        name: "FK_CommissionMembers_Commissions_CommissionID",
                        column: x => x.CommissionID,
                        principalTable: "Commissions",
                        principalColumn: "CommissionID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CommissionMembers_UserExtended_UserExtendedID",
                        column: x => x.UserExtendedID,
                        principalTable: "UserExtended",
                        principalColumn: "UserExtendedID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ApplicationQuestions",
                columns: new[] { "ApplicationQuestionID", "ApplicationQuestionNotes", "ApplicationQuestionText" },
                values: new object[,]
                {
                    { 2, null, "Are you a registered voter of the City?" },
                    { 3, null, "Have you previously served on a Board or Commission?" },
                    { 4, null, "What Boards or Commissions have you previously served on?" },
                    { 5, null, "Have you ever been convicted of a crime?" },
                    { 6, null, "If yes, please explain the nature of the offense:" },
                    { 7, null, "Please list any community involvement, employment, education or other expertise that pertains to the Board or Commission that you are applying for:" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CommissionMembers_UserExtendedID",
                table: "CommissionMembers",
                column: "UserExtendedID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CommissionMembers");

            migrationBuilder.DeleteData(
                table: "ApplicationQuestions",
                keyColumn: "ApplicationQuestionID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ApplicationQuestions",
                keyColumn: "ApplicationQuestionID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ApplicationQuestions",
                keyColumn: "ApplicationQuestionID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ApplicationQuestions",
                keyColumn: "ApplicationQuestionID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "ApplicationQuestions",
                keyColumn: "ApplicationQuestionID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "ApplicationQuestions",
                keyColumn: "ApplicationQuestionID",
                keyValue: 7);

            migrationBuilder.DropColumn(
                name: "CommissionMembers",
                table: "Commissions");
        }
    }
}
