using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ambev.DeveloperEvaluation.ORM.Migrations
{
    /// <inheritdoc />
    public partial class ModifyColumnName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DataSale",
                table: "Sales",
                newName: "SaleDate");

            migrationBuilder.AddColumn<bool>(
                name: "IsCanceled",
                table: "SaleItem",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsCanceled",
                table: "SaleItem");

            migrationBuilder.RenameColumn(
                name: "SaleDate",
                table: "Sales",
                newName: "DataSale");
        }
    }
}
