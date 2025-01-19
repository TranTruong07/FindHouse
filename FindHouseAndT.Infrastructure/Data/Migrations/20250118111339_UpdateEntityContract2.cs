using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FindHouseAndT.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateEntityContract2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Contracts",
                newName: "StatusHouseOwner");

            migrationBuilder.AddColumn<int>(
                name: "BookRequestId",
                table: "Contracts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "StatusCustomer",
                table: "Contracts",
                type: "varchar(200)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BookRequestId",
                table: "Contracts");

            migrationBuilder.DropColumn(
                name: "StatusCustomer",
                table: "Contracts");

            migrationBuilder.RenameColumn(
                name: "StatusHouseOwner",
                table: "Contracts",
                newName: "Status");
        }
    }
}
