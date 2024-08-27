using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class updateinediting : Migration
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

            migrationBuilder.DropIndex(
                name: "IX_rooms_BookingId",
                table: "rooms");

            migrationBuilder.DropIndex(
                name: "IX_rooms_GuestId",
                table: "rooms");

            migrationBuilder.DropColumn(
                name: "BookingId",
                table: "rooms");

            migrationBuilder.DropColumn(
                name: "GuestId",
                table: "rooms");

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "roomTypes",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "rooms",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "payments",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "hottels",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "guests",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: true);

            migrationBuilder.AddColumn<int>(
                name: "RoomId",
                table: "guests",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "employees",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "bookings",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: true);

            migrationBuilder.AddColumn<int>(
                name: "roomId",
                table: "bookings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "roomTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "IsActive",
                value: false);

            migrationBuilder.CreateIndex(
                name: "IX_guests_RoomId",
                table: "guests",
                column: "RoomId",
                unique: true);

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

            migrationBuilder.AddForeignKey(
                name: "FK_guests_rooms_RoomId",
                table: "guests",
                column: "RoomId",
                principalTable: "rooms",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_bookings_rooms_roomId",
                table: "bookings");

            migrationBuilder.DropForeignKey(
                name: "FK_guests_rooms_RoomId",
                table: "guests");

            migrationBuilder.DropIndex(
                name: "IX_guests_RoomId",
                table: "guests");

            migrationBuilder.DropIndex(
                name: "IX_bookings_roomId",
                table: "bookings");

            migrationBuilder.DropColumn(
                name: "RoomId",
                table: "guests");

            migrationBuilder.DropColumn(
                name: "roomId",
                table: "bookings");

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "roomTypes",
                type: "bit",
                nullable: false,
                defaultValue: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "rooms",
                type: "bit",
                nullable: false,
                defaultValue: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AddColumn<int>(
                name: "BookingId",
                table: "rooms",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "GuestId",
                table: "rooms",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "payments",
                type: "bit",
                nullable: false,
                defaultValue: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "hottels",
                type: "bit",
                nullable: false,
                defaultValue: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "guests",
                type: "bit",
                nullable: false,
                defaultValue: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "employees",
                type: "bit",
                nullable: false,
                defaultValue: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "bookings",
                type: "bit",
                nullable: false,
                defaultValue: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.UpdateData(
                table: "roomTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "IsActive",
                value: true);

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
    }
}
