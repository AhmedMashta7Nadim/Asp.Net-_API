using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class editinguest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_guests_hottels_HottelId",
                table: "guests");

            migrationBuilder.AlterColumn<int>(
                name: "HottelId",
                table: "guests",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BookingId",
                table: "guests",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_guests_hottels_HottelId",
                table: "guests",
                column: "HottelId",
                principalTable: "hottels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_guests_hottels_HottelId",
                table: "guests");

            migrationBuilder.DropColumn(
                name: "BookingId",
                table: "guests");

            migrationBuilder.AlterColumn<int>(
                name: "HottelId",
                table: "guests",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_guests_hottels_HottelId",
                table: "guests",
                column: "HottelId",
                principalTable: "hottels",
                principalColumn: "Id");
        }
    }
}
