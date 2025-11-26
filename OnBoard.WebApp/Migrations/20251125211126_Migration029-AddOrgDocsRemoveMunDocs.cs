using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnBoard.WebApp.Migrations
{
    /// <inheritdoc />
    public partial class Migration029AddOrgDocsRemoveMunDocs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MunicipalityDocuments");

            migrationBuilder.CreateTable(
                name: "OrganizationDocuments",
                columns: table => new
                {
                    OrganizationDocumentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrganizationID = table.Column<int>(type: "int", nullable: false),
                    DocumentID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrganizationDocuments", x => x.OrganizationDocumentID);
                    table.ForeignKey(
                        name: "FK_OrganizationDocuments_Documents_DocumentID",
                        column: x => x.DocumentID,
                        principalTable: "Documents",
                        principalColumn: "DocumentID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrganizationDocuments_Organizations_OrganizationID",
                        column: x => x.OrganizationID,
                        principalTable: "Organizations",
                        principalColumn: "OrganizationID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationDocuments_DocumentID",
                table: "OrganizationDocuments",
                column: "DocumentID");

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationDocuments_OrganizationID",
                table: "OrganizationDocuments",
                column: "OrganizationID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrganizationDocuments");

            migrationBuilder.CreateTable(
                name: "MunicipalityDocuments",
                columns: table => new
                {
                    MunicipalityDocumentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DocumentID = table.Column<int>(type: "int", nullable: false),
                    MunicipalityID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MunicipalityDocuments", x => x.MunicipalityDocumentID);
                    table.ForeignKey(
                        name: "FK_MunicipalityDocuments_Documents_DocumentID",
                        column: x => x.DocumentID,
                        principalTable: "Documents",
                        principalColumn: "DocumentID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MunicipalityDocuments_Municipalities_MunicipalityID",
                        column: x => x.MunicipalityID,
                        principalTable: "Municipalities",
                        principalColumn: "MunicipalityID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MunicipalityDocuments_DocumentID",
                table: "MunicipalityDocuments",
                column: "DocumentID");

            migrationBuilder.CreateIndex(
                name: "IX_MunicipalityDocuments_MunicipalityID",
                table: "MunicipalityDocuments",
                column: "MunicipalityID");
        }
    }
}
