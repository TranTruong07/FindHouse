using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FindHouseAndT.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateEntityRoom2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookRequests_Rooms_RoomCode",
                table: "BookRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Rooms_IdRoom",
                table: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Rooms",
                table: "Rooms");

            migrationBuilder.DropIndex(
                name: "IX_BookRequests_RoomCode",
                table: "BookRequests");

            migrationBuilder.DropColumn(
                name: "RoomCode",
                table: "BookRequests");

            migrationBuilder.AddColumn<int>(
                name: "ID",
                table: "Rooms",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "IdRoom",
                table: "Orders",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "RoomId",
                table: "BookRequests",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Rooms",
                table: "Rooms",
                column: "ID");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_RoomCode",
                table: "Rooms",
                column: "RoomCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BookRequests_RoomId",
                table: "BookRequests",
                column: "RoomId");

            migrationBuilder.AddForeignKey(
                name: "FK_BookRequests_Rooms_RoomId",
                table: "BookRequests",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Rooms_IdRoom",
                table: "Orders",
                column: "IdRoom",
                principalTable: "Rooms",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookRequests_Rooms_RoomId",
                table: "BookRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Rooms_IdRoom",
                table: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Rooms",
                table: "Rooms");

            migrationBuilder.DropIndex(
                name: "IX_Rooms_RoomCode",
                table: "Rooms");

            migrationBuilder.DropIndex(
                name: "IX_BookRequests_RoomId",
                table: "BookRequests");

            migrationBuilder.DropColumn(
                name: "ID",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "RoomId",
                table: "BookRequests");

            migrationBuilder.AlterColumn<string>(
                name: "IdRoom",
                table: "Orders",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "RoomCode",
                table: "BookRequests",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Rooms",
                table: "Rooms",
                column: "RoomCode");

            migrationBuilder.CreateIndex(
                name: "IX_BookRequests_RoomCode",
                table: "BookRequests",
                column: "RoomCode");

            migrationBuilder.AddForeignKey(
                name: "FK_BookRequests_Rooms_RoomCode",
                table: "BookRequests",
                column: "RoomCode",
                principalTable: "Rooms",
                principalColumn: "RoomCode",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Rooms_IdRoom",
                table: "Orders",
                column: "IdRoom",
                principalTable: "Rooms",
                principalColumn: "RoomCode",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
