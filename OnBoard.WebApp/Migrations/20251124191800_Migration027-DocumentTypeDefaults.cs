using Microsoft.EntityFrameworkCore.Migrations;

namespace OnBoard.WebApp.Migrations
{
    public partial class Migration027DocumentTypeDefaults : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "DocumentTypes",
                columns: new[] { "DocumentTypeID", "DocumentTypeName" },
                values: new object[] { 1, "budget" });

            migrationBuilder.InsertData(
                table: "DocumentTypes",
                columns: new[] { "DocumentTypeID", "DocumentTypeName" },
                values: new object[] { 2, "audit" });

            migrationBuilder.InsertData(
                table: "DocumentTypes",
                columns: new[] { "DocumentTypeID", "DocumentTypeName" },
                values: new object[] { 3, "Master Plan" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DocumentTypes",
                keyColumn: "DocumentTypeID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "DocumentTypes",
                keyColumn: "DocumentTypeID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "DocumentTypes",
                keyColumn: "DocumentTypeID",
                keyValue: 3);
        }
    }
}
