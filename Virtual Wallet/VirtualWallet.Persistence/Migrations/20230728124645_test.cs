using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VirtualWallet.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class test : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "CurrencyExchangeRate",
                table: "Transactions",
                type: "float",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 1,
                column: "ExpirationDate",
                value: new DateTime(2025, 10, 28, 15, 46, 45, 634, DateTimeKind.Local).AddTicks(8569));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 2,
                column: "ExpirationDate",
                value: new DateTime(2024, 9, 28, 15, 46, 45, 634, DateTimeKind.Local).AddTicks(8605));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 3,
                column: "ExpirationDate",
                value: new DateTime(2027, 4, 28, 15, 46, 45, 634, DateTimeKind.Local).AddTicks(8610));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 4,
                column: "ExpirationDate",
                value: new DateTime(2028, 1, 28, 15, 46, 45, 634, DateTimeKind.Local).AddTicks(8614));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 5,
                column: "ExpirationDate",
                value: new DateTime(2026, 11, 28, 15, 46, 45, 634, DateTimeKind.Local).AddTicks(8619));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 6,
                column: "ExpirationDate",
                value: new DateTime(2025, 6, 28, 15, 46, 45, 634, DateTimeKind.Local).AddTicks(8623));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 7,
                column: "ExpirationDate",
                value: new DateTime(2025, 9, 28, 15, 46, 45, 634, DateTimeKind.Local).AddTicks(8628));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 8,
                column: "ExpirationDate",
                value: new DateTime(2024, 12, 28, 15, 46, 45, 634, DateTimeKind.Local).AddTicks(8631));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 9,
                column: "ExpirationDate",
                value: new DateTime(2027, 8, 28, 15, 46, 45, 634, DateTimeKind.Local).AddTicks(8637));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 10,
                column: "ExpirationDate",
                value: new DateTime(2026, 5, 28, 15, 46, 45, 634, DateTimeKind.Local).AddTicks(8642));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 11,
                column: "ExpirationDate",
                value: new DateTime(2026, 10, 28, 15, 46, 45, 634, DateTimeKind.Local).AddTicks(8645));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 12,
                column: "ExpirationDate",
                value: new DateTime(2026, 2, 28, 15, 46, 45, 634, DateTimeKind.Local).AddTicks(8648));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 13,
                column: "ExpirationDate",
                value: new DateTime(2027, 1, 28, 15, 46, 45, 634, DateTimeKind.Local).AddTicks(8651));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 14,
                column: "ExpirationDate",
                value: new DateTime(2027, 12, 28, 15, 46, 45, 634, DateTimeKind.Local).AddTicks(8655));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 15,
                column: "ExpirationDate",
                value: new DateTime(2025, 4, 28, 15, 46, 45, 634, DateTimeKind.Local).AddTicks(8657));

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CurrencyExchangeRate", "Date" },
                values: new object[] { null, new DateTime(2023, 7, 18, 15, 46, 45, 634, DateTimeKind.Local).AddTicks(8777) });

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CurrencyExchangeRate", "Date" },
                values: new object[] { null, new DateTime(2023, 7, 19, 15, 46, 45, 634, DateTimeKind.Local).AddTicks(8789) });

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CurrencyExchangeRate", "Date" },
                values: new object[] { null, new DateTime(2023, 7, 20, 15, 46, 45, 634, DateTimeKind.Local).AddTicks(8792) });

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CurrencyExchangeRate", "Date" },
                values: new object[] { null, new DateTime(2023, 7, 21, 15, 46, 45, 634, DateTimeKind.Local).AddTicks(8794) });

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CurrencyExchangeRate", "Date" },
                values: new object[] { null, new DateTime(2023, 7, 22, 15, 46, 45, 634, DateTimeKind.Local).AddTicks(8797) });

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CurrencyExchangeRate", "Date" },
                values: new object[] { null, new DateTime(2023, 7, 23, 15, 46, 45, 634, DateTimeKind.Local).AddTicks(8801) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "VerifiedAt",
                value: new DateTime(2023, 7, 22, 15, 46, 45, 554, DateTimeKind.Local).AddTicks(4066));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "VerifiedAt",
                value: new DateTime(2023, 7, 22, 15, 46, 45, 560, DateTimeKind.Local).AddTicks(9470));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "VerifiedAt",
                value: new DateTime(2023, 7, 23, 15, 46, 45, 567, DateTimeKind.Local).AddTicks(9363));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                column: "VerifiedAt",
                value: new DateTime(2023, 7, 23, 15, 46, 45, 574, DateTimeKind.Local).AddTicks(4983));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                column: "VerifiedAt",
                value: new DateTime(2023, 7, 25, 15, 46, 45, 581, DateTimeKind.Local).AddTicks(4197));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6,
                column: "VerifiedAt",
                value: new DateTime(2023, 7, 26, 15, 46, 45, 587, DateTimeKind.Local).AddTicks(8966));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 7,
                column: "VerifiedAt",
                value: new DateTime(2023, 7, 26, 15, 46, 45, 594, DateTimeKind.Local).AddTicks(5525));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 8,
                column: "VerifiedAt",
                value: new DateTime(2023, 7, 26, 15, 46, 45, 601, DateTimeKind.Local).AddTicks(4065));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 9,
                column: "VerifiedAt",
                value: new DateTime(2023, 7, 27, 15, 46, 45, 608, DateTimeKind.Local).AddTicks(4020));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 10,
                column: "VerifiedAt",
                value: new DateTime(2023, 7, 27, 15, 46, 45, 615, DateTimeKind.Local).AddTicks(2746));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 11,
                column: "VerifiedAt",
                value: new DateTime(2023, 7, 27, 15, 46, 45, 621, DateTimeKind.Local).AddTicks(7238));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 12,
                column: "VerifiedAt",
                value: new DateTime(2023, 7, 27, 15, 46, 45, 628, DateTimeKind.Local).AddTicks(2315));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "CurrencyExchangeRate",
                table: "Transactions",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 1,
                column: "ExpirationDate",
                value: new DateTime(2025, 10, 28, 15, 40, 3, 952, DateTimeKind.Local).AddTicks(8761));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 2,
                column: "ExpirationDate",
                value: new DateTime(2024, 9, 28, 15, 40, 3, 952, DateTimeKind.Local).AddTicks(8776));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 3,
                column: "ExpirationDate",
                value: new DateTime(2027, 4, 28, 15, 40, 3, 952, DateTimeKind.Local).AddTicks(8783));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 4,
                column: "ExpirationDate",
                value: new DateTime(2028, 1, 28, 15, 40, 3, 952, DateTimeKind.Local).AddTicks(8786));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 5,
                column: "ExpirationDate",
                value: new DateTime(2026, 11, 28, 15, 40, 3, 952, DateTimeKind.Local).AddTicks(8788));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 6,
                column: "ExpirationDate",
                value: new DateTime(2025, 6, 28, 15, 40, 3, 952, DateTimeKind.Local).AddTicks(8791));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 7,
                column: "ExpirationDate",
                value: new DateTime(2025, 9, 28, 15, 40, 3, 952, DateTimeKind.Local).AddTicks(8793));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 8,
                column: "ExpirationDate",
                value: new DateTime(2024, 12, 28, 15, 40, 3, 952, DateTimeKind.Local).AddTicks(8795));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 9,
                column: "ExpirationDate",
                value: new DateTime(2027, 8, 28, 15, 40, 3, 952, DateTimeKind.Local).AddTicks(8798));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 10,
                column: "ExpirationDate",
                value: new DateTime(2026, 5, 28, 15, 40, 3, 952, DateTimeKind.Local).AddTicks(8801));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 11,
                column: "ExpirationDate",
                value: new DateTime(2026, 10, 28, 15, 40, 3, 952, DateTimeKind.Local).AddTicks(8803));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 12,
                column: "ExpirationDate",
                value: new DateTime(2026, 2, 28, 15, 40, 3, 952, DateTimeKind.Local).AddTicks(8805));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 13,
                column: "ExpirationDate",
                value: new DateTime(2027, 1, 28, 15, 40, 3, 952, DateTimeKind.Local).AddTicks(8807));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 14,
                column: "ExpirationDate",
                value: new DateTime(2027, 12, 28, 15, 40, 3, 952, DateTimeKind.Local).AddTicks(8809));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 15,
                column: "ExpirationDate",
                value: new DateTime(2025, 4, 28, 15, 40, 3, 952, DateTimeKind.Local).AddTicks(8812));

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CurrencyExchangeRate", "Date" },
                values: new object[] { null, new DateTime(2023, 7, 18, 15, 40, 3, 952, DateTimeKind.Local).AddTicks(9047) });

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CurrencyExchangeRate", "Date" },
                values: new object[] { null, new DateTime(2023, 7, 19, 15, 40, 3, 952, DateTimeKind.Local).AddTicks(9054) });

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CurrencyExchangeRate", "Date" },
                values: new object[] { null, new DateTime(2023, 7, 20, 15, 40, 3, 952, DateTimeKind.Local).AddTicks(9056) });

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CurrencyExchangeRate", "Date" },
                values: new object[] { null, new DateTime(2023, 7, 21, 15, 40, 3, 952, DateTimeKind.Local).AddTicks(9058) });

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CurrencyExchangeRate", "Date" },
                values: new object[] { null, new DateTime(2023, 7, 22, 15, 40, 3, 952, DateTimeKind.Local).AddTicks(9059) });

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CurrencyExchangeRate", "Date" },
                values: new object[] { null, new DateTime(2023, 7, 23, 15, 40, 3, 952, DateTimeKind.Local).AddTicks(9062) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "VerifiedAt",
                value: new DateTime(2023, 7, 22, 15, 40, 3, 870, DateTimeKind.Local).AddTicks(6505));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "VerifiedAt",
                value: new DateTime(2023, 7, 22, 15, 40, 3, 877, DateTimeKind.Local).AddTicks(8700));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "VerifiedAt",
                value: new DateTime(2023, 7, 23, 15, 40, 3, 884, DateTimeKind.Local).AddTicks(9325));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                column: "VerifiedAt",
                value: new DateTime(2023, 7, 23, 15, 40, 3, 891, DateTimeKind.Local).AddTicks(8500));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                column: "VerifiedAt",
                value: new DateTime(2023, 7, 25, 15, 40, 3, 898, DateTimeKind.Local).AddTicks(3813));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6,
                column: "VerifiedAt",
                value: new DateTime(2023, 7, 26, 15, 40, 3, 905, DateTimeKind.Local).AddTicks(1097));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 7,
                column: "VerifiedAt",
                value: new DateTime(2023, 7, 26, 15, 40, 3, 912, DateTimeKind.Local).AddTicks(1253));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 8,
                column: "VerifiedAt",
                value: new DateTime(2023, 7, 26, 15, 40, 3, 919, DateTimeKind.Local).AddTicks(312));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 9,
                column: "VerifiedAt",
                value: new DateTime(2023, 7, 27, 15, 40, 3, 925, DateTimeKind.Local).AddTicks(5339));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 10,
                column: "VerifiedAt",
                value: new DateTime(2023, 7, 27, 15, 40, 3, 931, DateTimeKind.Local).AddTicks(9552));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 11,
                column: "VerifiedAt",
                value: new DateTime(2023, 7, 27, 15, 40, 3, 939, DateTimeKind.Local).AddTicks(254));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 12,
                column: "VerifiedAt",
                value: new DateTime(2023, 7, 27, 15, 40, 3, 946, DateTimeKind.Local).AddTicks(372));
        }
    }
}
