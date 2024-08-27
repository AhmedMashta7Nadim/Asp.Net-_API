using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class sempledatainroomType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "roomTypes",
                columns: new[] { "Id", "NumOfBands", "TypeName" },
                values: new object[] { 1, 77, "Top Lefil" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "roomTypes",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
