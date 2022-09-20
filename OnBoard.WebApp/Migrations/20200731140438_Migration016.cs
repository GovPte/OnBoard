using Microsoft.EntityFrameworkCore.Migrations;

namespace OnBoard.WebApp.Migrations
{
    public partial class Migration016 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OrganizationID",
                table: "Commissions",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "States",
                columns: table => new
                {
                    StateID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StateName = table.Column<string>(nullable: true),
                    StateNamePostal = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_States", x => x.StateID);
                });

            migrationBuilder.CreateTable(
                name: "Municipalities",
                columns: table => new
                {
                    MunicipalityID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MunicipalityName = table.Column<string>(nullable: true),
                    StateID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Municipalities", x => x.MunicipalityID);
                    table.ForeignKey(
                        name: "FK_Municipalities_States_StateID",
                        column: x => x.StateID,
                        principalTable: "States",
                        principalColumn: "StateID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    AddressID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AddressStreet = table.Column<string>(nullable: true),
                    AddressExtended = table.Column<string>(nullable: true),
                    MunicipalityID = table.Column<int>(nullable: false),
                    AddressZipCode = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.AddressID);
                    table.ForeignKey(
                        name: "FK_Addresses_Municipalities_MunicipalityID",
                        column: x => x.MunicipalityID,
                        principalTable: "Municipalities",
                        principalColumn: "MunicipalityID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Organizations",
                columns: table => new
                {
                    OrganizationID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrganizationName = table.Column<string>(nullable: true),
                    OrganizationDescription = table.Column<string>(nullable: true),
                    OrganizationWebsite = table.Column<string>(nullable: true),
                    AddressID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organizations", x => x.OrganizationID);
                    table.ForeignKey(
                        name: "FK_Organizations_Addresses_AddressID",
                        column: x => x.AddressID,
                        principalTable: "Addresses",
                        principalColumn: "AddressID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Organizations",
                columns: new[] { "OrganizationID", "AddressID", "OrganizationDescription", "OrganizationName", "OrganizationWebsite" },
                values: new object[] { 1, null, null, "City of Eastpointe", "http://www.CityOfEastpointe.net" });

            migrationBuilder.InsertData(
                table: "States",
                columns: new[] { "StateID", "StateName", "StateNamePostal" },
                values: new object[] { 1, "Michigan", "MI" });

            migrationBuilder.UpdateData(
                table: "Commissions",
                keyColumn: "CommissionID",
                keyValue: 1,
                column: "OrganizationID",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Commissions",
                keyColumn: "CommissionID",
                keyValue: 2,
                column: "OrganizationID",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Commissions",
                keyColumn: "CommissionID",
                keyValue: 3,
                column: "OrganizationID",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Commissions",
                keyColumn: "CommissionID",
                keyValue: 4,
                column: "OrganizationID",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Commissions",
                keyColumn: "CommissionID",
                keyValue: 5,
                column: "OrganizationID",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Commissions",
                keyColumn: "CommissionID",
                keyValue: 6,
                column: "OrganizationID",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Commissions",
                keyColumn: "CommissionID",
                keyValue: 7,
                column: "OrganizationID",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Commissions",
                keyColumn: "CommissionID",
                keyValue: 8,
                column: "OrganizationID",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Commissions",
                keyColumn: "CommissionID",
                keyValue: 9,
                column: "OrganizationID",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Commissions",
                keyColumn: "CommissionID",
                keyValue: 10,
                column: "OrganizationID",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Commissions",
                keyColumn: "CommissionID",
                keyValue: 11,
                column: "OrganizationID",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Commissions",
                keyColumn: "CommissionID",
                keyValue: 12,
                column: "OrganizationID",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Commissions",
                keyColumn: "CommissionID",
                keyValue: 13,
                column: "OrganizationID",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Commissions",
                keyColumn: "CommissionID",
                keyValue: 14,
                column: "OrganizationID",
                value: 1);

            migrationBuilder.InsertData(
                table: "Municipalities",
                columns: new[] { "MunicipalityID", "MunicipalityName", "StateID" },
                values: new object[,]
                {
                    { 1, "Eastpointe", 1 },
                    { 2, "Roseville", 1 },
                    { 3, "Detroit", 1 },
                    { 4, "Clinton Township", 1 },
                    { 5, "St. Clair Shores", 1 },
                    { 6, "Fraser", 1 },
                    { 7, "Warren", 1 },
                    { 8, "Centerline", 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Commissions_OrganizationID",
                table: "Commissions",
                column: "OrganizationID");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_MunicipalityID",
                table: "Addresses",
                column: "MunicipalityID");

            migrationBuilder.CreateIndex(
                name: "IX_Municipalities_StateID",
                table: "Municipalities",
                column: "StateID");

            migrationBuilder.CreateIndex(
                name: "IX_Organizations_AddressID",
                table: "Organizations",
                column: "AddressID");

            migrationBuilder.AddForeignKey(
                name: "FK_Commissions_Organizations_OrganizationID",
                table: "Commissions",
                column: "OrganizationID",
                principalTable: "Organizations",
                principalColumn: "OrganizationID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Commissions_Organizations_OrganizationID",
                table: "Commissions");

            migrationBuilder.DropTable(
                name: "Organizations");

            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "Municipalities");

            migrationBuilder.DropTable(
                name: "States");

            migrationBuilder.DropIndex(
                name: "IX_Commissions_OrganizationID",
                table: "Commissions");

            migrationBuilder.DropColumn(
                name: "OrganizationID",
                table: "Commissions");
        }
    }
}
