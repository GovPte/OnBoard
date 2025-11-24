using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OnBoard.WebApp.Migrations
{
    public partial class Migration026AddingDocuments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DocumentTypes",
                columns: table => new
                {
                    DocumentTypeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DocumentTypeName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentTypes", x => x.DocumentTypeID);
                });

            migrationBuilder.CreateTable(
                name: "Documents",
                columns: table => new
                {
                    DocumentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DocumentTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DocumentDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DocumentURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DocumentUpload = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DocumentStart = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DocumentEnd = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DocumentTypeID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Documents", x => x.DocumentID);
                    table.ForeignKey(
                        name: "FK_Documents_DocumentTypes_DocumentTypeID",
                        column: x => x.DocumentTypeID,
                        principalTable: "DocumentTypes",
                        principalColumn: "DocumentTypeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MunicipalityDocuments",
                columns: table => new
                {
                    MunicipalityDocumentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MunicipalityID = table.Column<int>(type: "int", nullable: false),
                    DocumentID = table.Column<int>(type: "int", nullable: false)
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

            migrationBuilder.UpdateData(
                table: "Municipalities",
                keyColumn: "MunicipalityID",
                keyValue: 8,
                column: "MunicipalityName",
                value: "Center Line");

            migrationBuilder.UpdateData(
                table: "Organizations",
                keyColumn: "OrganizationID",
                keyValue: 1,
                column: "OrganizationWebsite",
                value: "https://www.EastpointeMI.gov");

            migrationBuilder.CreateIndex(
                name: "IX_Documents_DocumentTypeID",
                table: "Documents",
                column: "DocumentTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_MunicipalityDocuments_DocumentID",
                table: "MunicipalityDocuments",
                column: "DocumentID");

            migrationBuilder.CreateIndex(
                name: "IX_MunicipalityDocuments_MunicipalityID",
                table: "MunicipalityDocuments",
                column: "MunicipalityID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MunicipalityDocuments");

            migrationBuilder.DropTable(
                name: "Documents");

            migrationBuilder.DropTable(
                name: "DocumentTypes");

            migrationBuilder.UpdateData(
                table: "Municipalities",
                keyColumn: "MunicipalityID",
                keyValue: 8,
                column: "MunicipalityName",
                value: "Centerline");

            migrationBuilder.UpdateData(
                table: "Organizations",
                keyColumn: "OrganizationID",
                keyValue: 1,
                column: "OrganizationWebsite",
                value: "http://www.CityOfEastpointe.net");
        }
    }
}
