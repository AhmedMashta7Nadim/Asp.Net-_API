using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class updateinediting2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_bookings_rooms_roomId",
                table: "bookings");

            migrationBuilder.DropIndex(
                name: "IX_bookings_roomId",
                table: "bookings");

            migrationBuilder.DropColumn(
                name: "roomId",
                table: "bookings");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "roomId",
                table: "bookings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_bookings_roomId",
                table: "bookings",
                column: "roomId");

            migrationBuilder.AddForeignKey(
                name: "FK_bookings_rooms_roomId",
                table: "bookings",
                column: "roomId",
                principalTable: "rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
