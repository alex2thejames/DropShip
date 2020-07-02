﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace DropShip.Migrations
{
    public partial class YourMigrationNamea : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "OrderNumber",
                table: "Orders",
                nullable: false,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "OrderNumber",
                table: "Orders",
                nullable: false,
                oldClrType: typeof(string));
        }
    }
}
