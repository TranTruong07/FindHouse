using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FindHouseAndT.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateEntityBookRequest2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateOnly>(
                name: "EndTimeBook",
                table: "BookRequests",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<DateOnly>(
                name: "StartTimeBook",
                table: "BookRequests",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndTimeBook",
                table: "BookRequests");

            migrationBuilder.DropColumn(
                name: "StartTimeBook",
                table: "BookRequests");
        }
    }
}
