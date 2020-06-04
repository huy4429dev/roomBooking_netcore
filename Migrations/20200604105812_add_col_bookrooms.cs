using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RoomBooking.Migrations
{
    public partial class add_col_bookrooms : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TimeBook",
                table: "BookRooms",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "TimeCreated",
                table: "BookRooms",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TimeBook",
                table: "BookRooms");

            migrationBuilder.DropColumn(
                name: "TimeCreated",
                table: "BookRooms");
        }
    }
}
