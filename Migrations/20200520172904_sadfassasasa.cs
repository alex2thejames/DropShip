using Microsoft.EntityFrameworkCore.Migrations;

namespace DropShip.Migrations
{
    public partial class sadfassasasa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Total",
                table: "Orders");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Total",
                table: "Orders",
                nullable: false,
                defaultValue: 0);
        }
    }
}
