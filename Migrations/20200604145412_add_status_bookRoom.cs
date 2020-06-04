using Microsoft.EntityFrameworkCore.Migrations;

namespace RoomBooking.Migrations
{
    public partial class add_status_bookRoom : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RoomId",
                table: "BookRooms",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_BookRooms_RoomId",
                table: "BookRooms",
                column: "RoomId");

            migrationBuilder.AddForeignKey(
                name: "FK_BookRooms_Rooms_RoomId",
                table: "BookRooms",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookRooms_Rooms_RoomId",
                table: "BookRooms");

            migrationBuilder.DropIndex(
                name: "IX_BookRooms_RoomId",
                table: "BookRooms");

            migrationBuilder.DropColumn(
                name: "RoomId",
                table: "BookRooms");
        }
    }
}
