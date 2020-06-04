using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace RoomBooking.Migrations
{
    public partial class updatebookroom : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_BookRooms",
                table: "BookRooms");

            migrationBuilder.AddColumn<int>(
                name: "BookCount",
                table: "Customers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "BookRooms",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_BookRooms",
                table: "BookRooms",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_BookRooms_TypeRoomId",
                table: "BookRooms",
                column: "TypeRoomId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_BookRooms",
                table: "BookRooms");

            migrationBuilder.DropIndex(
                name: "IX_BookRooms_TypeRoomId",
                table: "BookRooms");

            migrationBuilder.DropColumn(
                name: "BookCount",
                table: "Customers");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "BookRooms",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int))
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_BookRooms",
                table: "BookRooms",
                columns: new[] { "TypeRoomId", "CustomerId" });
        }
    }
}
