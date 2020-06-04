using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RoomBooking.Migrations
{
    public partial class addbookrooms : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Thumbnail",
                table: "TypeRooms",
                type: "VARCHAR",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR",
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "TypeRooms",
                type: "VARCHAR",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR",
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "TypeRooms",
                type: "VARCHAR",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "BookRooms",
                columns: table => new
                {
                    TypeRoomId = table.Column<int>(nullable: false),
                    CustomerId = table.Column<int>(nullable: false),
                    Id = table.Column<int>(nullable: false),
                    Status = table.Column<bool>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookRooms", x => new { x.TypeRoomId, x.CustomerId });
                    table.ForeignKey(
                        name: "FK_BookRooms_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookRooms_TypeRooms_TypeRoomId",
                        column: x => x.TypeRoomId,
                        principalTable: "TypeRooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookRooms_CustomerId",
                table: "BookRooms",
                column: "CustomerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookRooms");

            migrationBuilder.AlterColumn<string>(
                name: "Thumbnail",
                table: "TypeRooms",
                type: "VARCHAR",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR",
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "TypeRooms",
                type: "VARCHAR",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR",
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "TypeRooms",
                type: "VARCHAR",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR",
                oldMaxLength: 500);
        }
    }
}
