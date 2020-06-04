using Microsoft.EntityFrameworkCore.Migrations;

namespace RoomBooking.Migrations
{
    public partial class add_bookRoomStatus_bookRooms : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BookRoomStatus",
                table: "BookRooms",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BookRoomStatus",
                table: "BookRooms");
        }
    }
}
