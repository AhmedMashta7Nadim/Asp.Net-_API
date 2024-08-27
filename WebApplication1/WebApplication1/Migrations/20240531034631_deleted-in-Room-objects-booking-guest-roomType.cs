using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class deletedinRoomobjectsbookingguestroomType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_rooms_bookings_BookingId",
                table: "rooms");

            migrationBuilder.DropForeignKey(
                name: "FK_rooms_guests_GuestId",
                table: "rooms");

            migrationBuilder.DropForeignKey(
                name: "FK_rooms_roomTypes_RoomTypeId",
                table: "rooms");

            migrationBuilder.DropIndex(
                name: "IX_rooms_BookingId",
                table: "rooms");

            migrationBuilder.DropIndex(
                name: "IX_rooms_GuestId",
                table: "rooms");

            migrationBuilder.DropIndex(
                name: "IX_rooms_RoomTypeId",
                table: "rooms");

            migrationBuilder.AlterColumn<int>(
                name: "GuestId",
                table: "rooms",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BookingId",
                table: "rooms",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_rooms_BookingId",
                table: "rooms",
                column: "BookingId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_rooms_GuestId",
                table: "rooms",
                column: "GuestId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_rooms_bookings_BookingId",
                table: "rooms",
                column: "BookingId",
                principalTable: "bookings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_rooms_guests_GuestId",
                table: "rooms",
                column: "GuestId",
                principalTable: "guests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_rooms_bookings_BookingId",
                table: "rooms");

            migrationBuilder.DropForeignKey(
                name: "FK_rooms_guests_GuestId",
                table: "rooms");

            migrationBuilder.DropIndex(
                name: "IX_rooms_BookingId",
                table: "rooms");

            migrationBuilder.DropIndex(
                name: "IX_rooms_GuestId",
                table: "rooms");

            migrationBuilder.AlterColumn<int>(
                name: "GuestId",
                table: "rooms",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "BookingId",
                table: "rooms",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_rooms_BookingId",
                table: "rooms",
                column: "BookingId",
                unique: true,
                filter: "[BookingId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_rooms_GuestId",
                table: "rooms",
                column: "GuestId",
                unique: true,
                filter: "[GuestId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_rooms_RoomTypeId",
                table: "rooms",
                column: "RoomTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_rooms_bookings_BookingId",
                table: "rooms",
                column: "BookingId",
                principalTable: "bookings",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_rooms_guests_GuestId",
                table: "rooms",
                column: "GuestId",
                principalTable: "guests",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_rooms_roomTypes_RoomTypeId",
                table: "rooms",
                column: "RoomTypeId",
                principalTable: "roomTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
