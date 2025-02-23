using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FindHouseAndT.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateEntityRoom3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Rooms_RoomCode",
                table: "Rooms");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_RoomCode_IdMotel",
                table: "Rooms",
                columns: new[] { "RoomCode", "IdMotel" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Rooms_RoomCode_IdMotel",
                table: "Rooms");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_RoomCode",
                table: "Rooms",
                column: "RoomCode",
                unique: true);
        }
    }
}
