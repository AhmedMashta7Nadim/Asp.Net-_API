using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class editinguest3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_guests_BookingId",
                table: "guests",
                column: "BookingId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_guests_bookings_BookingId",
                table: "guests",
                column: "BookingId",
                principalTable: "bookings",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_guests_bookings_BookingId",
                table: "guests");

            migrationBuilder.DropIndex(
                name: "IX_guests_BookingId",
                table: "guests");
        }
    }
}
