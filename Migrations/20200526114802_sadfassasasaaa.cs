using Microsoft.EntityFrameworkCore.Migrations;

namespace DropShip.Migrations
{
    public partial class sadfassasasaaa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CustomerName",
                table: "Orders");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CustomerName",
                table: "Orders",
                nullable: true);
        }
    }
}
