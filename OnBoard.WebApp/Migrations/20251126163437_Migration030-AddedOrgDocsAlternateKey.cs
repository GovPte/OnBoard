using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnBoard.WebApp.Migrations
{
    /// <inheritdoc />
    public partial class Migration030AddedOrgDocsAlternateKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_OrganizationDocuments_OrganizationID",
                table: "OrganizationDocuments");

            migrationBuilder.AddColumn<int>(
                name: "DocumentID",
                table: "Organizations",
                type: "int",
                nullable: true);

            migrationBuilder.AddUniqueConstraint(
                name: "AK_OrganizationDocuments_OrganizationID_DocumentID",
                table: "OrganizationDocuments",
                columns: new[] { "OrganizationID", "DocumentID" });

            migrationBuilder.UpdateData(
                table: "Organizations",
                keyColumn: "OrganizationID",
                keyValue: 1,
                column: "DocumentID",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_Organizations_DocumentID",
                table: "Organizations",
                column: "DocumentID");

            migrationBuilder.AddForeignKey(
                name: "FK_Organizations_Documents_DocumentID",
                table: "Organizations",
                column: "DocumentID",
                principalTable: "Documents",
                principalColumn: "DocumentID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Organizations_Documents_DocumentID",
                table: "Organizations");

            migrationBuilder.DropIndex(
                name: "IX_Organizations_DocumentID",
                table: "Organizations");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_OrganizationDocuments_OrganizationID_DocumentID",
                table: "OrganizationDocuments");

            migrationBuilder.DropColumn(
                name: "DocumentID",
                table: "Organizations");

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationDocuments_OrganizationID",
                table: "OrganizationDocuments",
                column: "OrganizationID");
        }
    }
}
