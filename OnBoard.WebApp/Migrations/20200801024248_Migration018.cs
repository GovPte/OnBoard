using Microsoft.EntityFrameworkCore.Migrations;

namespace OnBoard.WebApp.Migrations
{
    public partial class Migration018 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ApplicationQuestionTypeID",
                table: "ApplicationQuestions",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ApplicationQuestionType",
                columns: table => new
                {
                    ApplicationQuestionTypeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicationQuestionTypeName = table.Column<string>(nullable: false),
                    ApplicationQuestionTypeDescription = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationQuestionType", x => x.ApplicationQuestionTypeID);
                });

            migrationBuilder.InsertData(
                table: "ApplicationQuestionType",
                columns: new[] { "ApplicationQuestionTypeID", "ApplicationQuestionTypeDescription", "ApplicationQuestionTypeName" },
                values: new object[,]
                {
                    { 1, null, "Yes and No" },
                    { 2, null, "Text" },
                    { 3, null, "Text (extended)" },
                    { 4, null, "Drop-down List of Commissions" }
                });

            migrationBuilder.UpdateData(
                table: "ApplicationQuestions",
                keyColumn: "ApplicationQuestionID",
                keyValue: 2,
                column: "ApplicationQuestionTypeID",
                value: 1);

            migrationBuilder.UpdateData(
                table: "ApplicationQuestions",
                keyColumn: "ApplicationQuestionID",
                keyValue: 3,
                column: "ApplicationQuestionTypeID",
                value: 1);

            migrationBuilder.UpdateData(
                table: "ApplicationQuestions",
                keyColumn: "ApplicationQuestionID",
                keyValue: 4,
                column: "ApplicationQuestionTypeID",
                value: 4);

            migrationBuilder.UpdateData(
                table: "ApplicationQuestions",
                keyColumn: "ApplicationQuestionID",
                keyValue: 5,
                column: "ApplicationQuestionTypeID",
                value: 1);

            migrationBuilder.UpdateData(
                table: "ApplicationQuestions",
                keyColumn: "ApplicationQuestionID",
                keyValue: 6,
                column: "ApplicationQuestionTypeID",
                value: 2);

            migrationBuilder.UpdateData(
                table: "ApplicationQuestions",
                keyColumn: "ApplicationQuestionID",
                keyValue: 7,
                column: "ApplicationQuestionTypeID",
                value: 3);

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationQuestions_ApplicationQuestionTypeID",
                table: "ApplicationQuestions",
                column: "ApplicationQuestionTypeID");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationQuestions_ApplicationQuestionType_ApplicationQuestionTypeID",
                table: "ApplicationQuestions",
                column: "ApplicationQuestionTypeID",
                principalTable: "ApplicationQuestionType",
                principalColumn: "ApplicationQuestionTypeID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationQuestions_ApplicationQuestionType_ApplicationQuestionTypeID",
                table: "ApplicationQuestions");

            migrationBuilder.DropTable(
                name: "ApplicationQuestionType");

            migrationBuilder.DropIndex(
                name: "IX_ApplicationQuestions_ApplicationQuestionTypeID",
                table: "ApplicationQuestions");

            migrationBuilder.DropColumn(
                name: "ApplicationQuestionTypeID",
                table: "ApplicationQuestions");
        }
    }
}
