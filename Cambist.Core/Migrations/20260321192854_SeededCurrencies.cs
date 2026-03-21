using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Cambist.Core.Migrations
{
    /// <inheritdoc />
    public partial class SeededCurrencies : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CurrencyCode",
                table: "Currencies",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "Id", "CurrencyCode", "CurrencyName", "Symbol" },
                values: new object[,]
                {
                    { 1, "NGN", "Nigerian Naira", "₦" },
                    { 2, "USD", "US Dollar", "$" },
                    { 3, "EUR", "Euro", "€" },
                    { 4, "GBP", "British Pound Sterling", "£" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Currencies_CurrencyCode",
                table: "Currencies",
                column: "CurrencyCode",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Currencies_CurrencyCode",
                table: "Currencies");

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.AlterColumn<string>(
                name: "CurrencyCode",
                table: "Currencies",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }
    }
}
