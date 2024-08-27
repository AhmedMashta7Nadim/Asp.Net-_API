using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class editinguest2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_guests_hottels_HottelId",
                table: "guests");

            migrationBuilder.AddForeignKey(
                name: "FK_guests_hottels_HottelId",
                table: "guests",
                column: "HottelId",
                principalTable: "hottels",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_guests_hottels_HottelId",
                table: "guests");

            migrationBuilder.AddForeignKey(
                name: "FK_guests_hottels_HottelId",
                table: "guests",
                column: "HottelId",
                principalTable: "hottels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
