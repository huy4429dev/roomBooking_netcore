using Microsoft.EntityFrameworkCore.Migrations;

namespace RoomBooking.Migrations
{
    public partial class add_table_contact : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Message",
                table: "Contacts");

            migrationBuilder.AddColumn<string>(
                name: "Content",
                table: "Contacts",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Content",
                table: "Contacts");

            migrationBuilder.AddColumn<string>(
                name: "Message",
                table: "Contacts",
                type: "text",
                nullable: true);
        }
    }
}
