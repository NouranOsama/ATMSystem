using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ATMSystem.Migrations
{
    /// <inheritdoc />
    public partial class RenameCvvToPinHash : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CVV",
                table: "Cards",
                newName: "PinHash");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PinHash",
                table: "Cards",
                newName: "CVV");
        }
    }
}
