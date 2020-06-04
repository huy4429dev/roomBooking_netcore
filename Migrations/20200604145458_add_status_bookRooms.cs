using Microsoft.EntityFrameworkCore.Migrations;

namespace RoomBooking.Migrations
{
    public partial class add_status_bookRooms : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookRooms_Rooms_RoomId",
                table: "BookRooms");

            migrationBuilder.AlterColumn<int>(
                name: "RoomId",
                table: "BookRooms",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_BookRooms_Rooms_RoomId",
                table: "BookRooms",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookRooms_Rooms_RoomId",
                table: "BookRooms");

            migrationBuilder.AlterColumn<int>(
                name: "RoomId",
                table: "BookRooms",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_BookRooms_Rooms_RoomId",
                table: "BookRooms",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
