using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FindHouseAndT.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddEntityBookRequest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_HouseOwners_IdHouseOwner",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Motels_IdMotel",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_IdHouseOwner",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_IdMotel",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "IdHouseOwner",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "IdMotel",
                table: "Orders");

            migrationBuilder.CreateTable(
                name: "BookRequests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCustomer = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoomCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KeyUrlFrontCCCD = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KeyUrlBackCCCD = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(250)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BookRequests_Customers_IdCustomer",
                        column: x => x.IdCustomer,
                        principalTable: "Customers",
                        principalColumn: "IdUser",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BookRequests_Rooms_RoomCode",
                        column: x => x.RoomCode,
                        principalTable: "Rooms",
                        principalColumn: "RoomCode",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookRequests_IdCustomer",
                table: "BookRequests",
                column: "IdCustomer");

            migrationBuilder.CreateIndex(
                name: "IX_BookRequests_RoomCode",
                table: "BookRequests",
                column: "RoomCode");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookRequests");

            migrationBuilder.AddColumn<Guid>(
                name: "IdHouseOwner",
                table: "Orders",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "IdMotel",
                table: "Orders",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Orders_IdHouseOwner",
                table: "Orders",
                column: "IdHouseOwner");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_IdMotel",
                table: "Orders",
                column: "IdMotel");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_HouseOwners_IdHouseOwner",
                table: "Orders",
                column: "IdHouseOwner",
                principalTable: "HouseOwners",
                principalColumn: "IdHouseOwner",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Motels_IdMotel",
                table: "Orders",
                column: "IdMotel",
                principalTable: "Motels",
                principalColumn: "IdMotel",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
