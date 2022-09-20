using Microsoft.EntityFrameworkCore.Migrations;

namespace OnBoard.WebApp.Migrations
{
    public partial class Migration021AddedCommissionMemberSlotAndSort : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CommissionMemberSlot",
                table: "CommissionMembers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CommissionMemberSort",
                table: "CommissionMembers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CommissionMemberSlot",
                table: "CommissionMembers");

            migrationBuilder.DropColumn(
                name: "CommissionMemberSort",
                table: "CommissionMembers");
        }
    }
}
