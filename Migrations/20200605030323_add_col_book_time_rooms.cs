using Microsoft.EntityFrameworkCore.Migrations;

namespace RoomBooking.Migrations
{
    public partial class add_col_book_time_rooms : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Note",
                table: "Rooms",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TimeBook",
                table: "Rooms",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Note",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "TimeBook",
                table: "Rooms");
        }
    }
}
