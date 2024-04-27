using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StockViewer.Api.Data.Migrations
{
    /// <inheritdoc />
    public partial class ChangeToStockSymbol : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StockName",
                table: "Stocks",
                newName: "StockSymbol");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StockSymbol",
                table: "Stocks",
                newName: "StockName");
        }
    }
}
