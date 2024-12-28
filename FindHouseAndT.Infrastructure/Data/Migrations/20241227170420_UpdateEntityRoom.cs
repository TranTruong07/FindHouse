using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FindHouseAndT.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateEntityRoom : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Rooms_IdRoom",
                table: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Rooms",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "IdRoom",
                table: "Rooms");

            migrationBuilder.AddColumn<string>(
                name: "RoomCode",
                table: "Rooms",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "IdRoom",
                table: "Orders",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Rooms",
                table: "Rooms",
                column: "RoomCode");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Rooms_IdRoom",
                table: "Orders",
                column: "IdRoom",
                principalTable: "Rooms",
                principalColumn: "RoomCode",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Rooms_IdRoom",
                table: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Rooms",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "RoomCode",
                table: "Rooms");

            migrationBuilder.AddColumn<Guid>(
                name: "IdRoom",
                table: "Rooms",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<Guid>(
                name: "IdRoom",
                table: "Orders",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Rooms",
                table: "Rooms",
                column: "IdRoom");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Rooms_IdRoom",
                table: "Orders",
                column: "IdRoom",
                principalTable: "Rooms",
                principalColumn: "IdRoom",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
