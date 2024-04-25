using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StockViewer.Api.Data.Migrations
{
    /// <inheritdoc />
    public partial class StockUserRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Stocks",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Stocks_UserId",
                table: "Stocks",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Stocks_Users_UserId",
                table: "Stocks",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Stocks_Users_UserId",
                table: "Stocks");

            migrationBuilder.DropIndex(
                name: "IX_Stocks_UserId",
                table: "Stocks");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Stocks");
        }
    }
}
