using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VirtualWallet.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class walletcurrency : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RecipientWalletCurrency",
                table: "Transactions",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SenderWalletCurrency",
                table: "Transactions",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 1,
                column: "ExpirationDate",
                value: new DateTime(2025, 11, 2, 16, 22, 51, 995, DateTimeKind.Local).AddTicks(9805));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 2,
                column: "ExpirationDate",
                value: new DateTime(2024, 10, 2, 16, 22, 51, 995, DateTimeKind.Local).AddTicks(9826));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 3,
                column: "ExpirationDate",
                value: new DateTime(2027, 5, 2, 16, 22, 51, 995, DateTimeKind.Local).AddTicks(9830));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 4,
                column: "ExpirationDate",
                value: new DateTime(2028, 2, 2, 16, 22, 51, 995, DateTimeKind.Local).AddTicks(9832));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 5,
                column: "ExpirationDate",
                value: new DateTime(2026, 12, 2, 16, 22, 51, 995, DateTimeKind.Local).AddTicks(9835));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 6,
                column: "ExpirationDate",
                value: new DateTime(2025, 7, 2, 16, 22, 51, 995, DateTimeKind.Local).AddTicks(9839));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 7,
                column: "ExpirationDate",
                value: new DateTime(2025, 10, 2, 16, 22, 51, 995, DateTimeKind.Local).AddTicks(9842));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 8,
                column: "ExpirationDate",
                value: new DateTime(2025, 1, 2, 16, 22, 51, 995, DateTimeKind.Local).AddTicks(9844));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 9,
                column: "ExpirationDate",
                value: new DateTime(2027, 9, 2, 16, 22, 51, 995, DateTimeKind.Local).AddTicks(9847));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 10,
                column: "ExpirationDate",
                value: new DateTime(2026, 6, 2, 16, 22, 51, 995, DateTimeKind.Local).AddTicks(9850));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 11,
                column: "ExpirationDate",
                value: new DateTime(2026, 11, 2, 16, 22, 51, 995, DateTimeKind.Local).AddTicks(9852));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 12,
                column: "ExpirationDate",
                value: new DateTime(2026, 3, 2, 16, 22, 51, 995, DateTimeKind.Local).AddTicks(9855));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 13,
                column: "ExpirationDate",
                value: new DateTime(2027, 2, 2, 16, 22, 51, 995, DateTimeKind.Local).AddTicks(9859));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 14,
                column: "ExpirationDate",
                value: new DateTime(2028, 1, 2, 16, 22, 51, 995, DateTimeKind.Local).AddTicks(9861));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 15,
                column: "ExpirationDate",
                value: new DateTime(2025, 5, 2, 16, 22, 51, 995, DateTimeKind.Local).AddTicks(9864));

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Date", "RecipientWalletCurrency", "SenderWalletCurrency" },
                values: new object[] { new DateTime(2023, 7, 23, 16, 22, 51, 996, DateTimeKind.Local).AddTicks(28), 2, 3 });

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Date", "RecipientWalletCurrency", "SenderWalletCurrency" },
                values: new object[] { new DateTime(2023, 7, 24, 16, 22, 51, 996, DateTimeKind.Local).AddTicks(41), 2, 3 });

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Date", "RecipientWalletCurrency", "SenderWalletCurrency" },
                values: new object[] { new DateTime(2023, 7, 25, 16, 22, 51, 996, DateTimeKind.Local).AddTicks(45), 2, 3 });

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Date", "RecipientWalletCurrency", "SenderWalletCurrency" },
                values: new object[] { new DateTime(2023, 7, 26, 16, 22, 51, 996, DateTimeKind.Local).AddTicks(48), 1, 3 });

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Date", "RecipientWalletCurrency", "SenderWalletCurrency" },
                values: new object[] { new DateTime(2023, 7, 27, 16, 22, 51, 996, DateTimeKind.Local).AddTicks(53), 1, 1 });

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Date", "RecipientWalletCurrency", "SenderWalletCurrency" },
                values: new object[] { new DateTime(2023, 7, 28, 16, 22, 51, 996, DateTimeKind.Local).AddTicks(57), 1, 3 });

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Date", "RecipientWalletCurrency", "SenderWalletCurrency" },
                values: new object[] { new DateTime(2023, 7, 29, 16, 22, 51, 996, DateTimeKind.Local).AddTicks(61), null, 3 });

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Date", "RecipientWalletCurrency", "SenderWalletCurrency" },
                values: new object[] { new DateTime(2023, 7, 29, 16, 22, 51, 996, DateTimeKind.Local).AddTicks(63), null, 3 });

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Date", "RecipientWalletCurrency", "SenderWalletCurrency" },
                values: new object[] { new DateTime(2023, 7, 29, 16, 22, 51, 996, DateTimeKind.Local).AddTicks(66), null, 1 });

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Date", "RecipientWalletCurrency", "SenderWalletCurrency" },
                values: new object[] { new DateTime(2023, 7, 29, 16, 22, 51, 996, DateTimeKind.Local).AddTicks(69), 1, 3 });

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "Date", "RecipientWalletCurrency", "SenderWalletCurrency" },
                values: new object[] { new DateTime(2023, 7, 29, 16, 22, 51, 996, DateTimeKind.Local).AddTicks(72), 3, 1 });

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "Date", "RecipientWalletCurrency", "SenderWalletCurrency" },
                values: new object[] { new DateTime(2023, 7, 30, 16, 22, 51, 996, DateTimeKind.Local).AddTicks(75), 3, 1 });

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "Date", "RecipientWalletCurrency", "SenderWalletCurrency" },
                values: new object[] { new DateTime(2023, 7, 30, 16, 22, 51, 996, DateTimeKind.Local).AddTicks(78), null, 3 });

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "Date", "RecipientWalletCurrency", "SenderWalletCurrency" },
                values: new object[] { new DateTime(2023, 7, 30, 16, 22, 51, 996, DateTimeKind.Local).AddTicks(81), null, 3 });

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "Date", "RecipientWalletCurrency", "SenderWalletCurrency" },
                values: new object[] { new DateTime(2023, 7, 30, 16, 22, 51, 996, DateTimeKind.Local).AddTicks(83), null, 3 });

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "Date", "RecipientWalletCurrency", "SenderWalletCurrency" },
                values: new object[] { new DateTime(2023, 7, 31, 16, 22, 51, 996, DateTimeKind.Local).AddTicks(85), 3, 3 });

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "Date", "RecipientWalletCurrency", "SenderWalletCurrency" },
                values: new object[] { new DateTime(2023, 7, 31, 16, 22, 51, 996, DateTimeKind.Local).AddTicks(88), 3, 3 });

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "Date", "RecipientWalletCurrency", "SenderWalletCurrency" },
                values: new object[] { new DateTime(2023, 7, 31, 16, 22, 51, 996, DateTimeKind.Local).AddTicks(92), 3, 3 });

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "Date", "RecipientWalletCurrency", "SenderWalletCurrency" },
                values: new object[] { new DateTime(2023, 7, 31, 16, 22, 51, 996, DateTimeKind.Local).AddTicks(94), null, 3 });

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "Date", "RecipientWalletCurrency", "SenderWalletCurrency" },
                values: new object[] { new DateTime(2023, 7, 31, 16, 22, 51, 996, DateTimeKind.Local).AddTicks(97), null, 3 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "VerifiedAt",
                value: new DateTime(2023, 7, 27, 16, 22, 51, 904, DateTimeKind.Local).AddTicks(5024));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "VerifiedAt",
                value: new DateTime(2023, 7, 27, 16, 22, 51, 910, DateTimeKind.Local).AddTicks(8987));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "VerifiedAt",
                value: new DateTime(2023, 7, 28, 16, 22, 51, 917, DateTimeKind.Local).AddTicks(4819));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                column: "VerifiedAt",
                value: new DateTime(2023, 7, 28, 16, 22, 51, 923, DateTimeKind.Local).AddTicks(8012));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                column: "VerifiedAt",
                value: new DateTime(2023, 7, 30, 16, 22, 51, 930, DateTimeKind.Local).AddTicks(6101));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6,
                column: "VerifiedAt",
                value: new DateTime(2023, 7, 31, 16, 22, 51, 937, DateTimeKind.Local).AddTicks(3818));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 7,
                column: "VerifiedAt",
                value: new DateTime(2023, 7, 31, 16, 22, 51, 943, DateTimeKind.Local).AddTicks(7475));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 8,
                column: "VerifiedAt",
                value: new DateTime(2023, 7, 31, 16, 22, 51, 950, DateTimeKind.Local).AddTicks(591));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 9,
                column: "VerifiedAt",
                value: new DateTime(2023, 8, 1, 16, 22, 51, 956, DateTimeKind.Local).AddTicks(3572));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 10,
                column: "VerifiedAt",
                value: new DateTime(2023, 8, 1, 16, 22, 51, 963, DateTimeKind.Local).AddTicks(3594));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 11,
                column: "VerifiedAt",
                value: new DateTime(2023, 8, 1, 16, 22, 51, 969, DateTimeKind.Local).AddTicks(8955));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 12,
                column: "VerifiedAt",
                value: new DateTime(2023, 8, 1, 16, 22, 51, 976, DateTimeKind.Local).AddTicks(3867));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 13,
                column: "VerifiedAt",
                value: new DateTime(2023, 8, 1, 16, 22, 51, 982, DateTimeKind.Local).AddTicks(6993));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 14,
                column: "VerifiedAt",
                value: new DateTime(2023, 8, 1, 16, 22, 51, 989, DateTimeKind.Local).AddTicks(145));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RecipientWalletCurrency",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "SenderWalletCurrency",
                table: "Transactions");

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 1,
                column: "ExpirationDate",
                value: new DateTime(2025, 11, 2, 15, 11, 17, 865, DateTimeKind.Local).AddTicks(2026));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 2,
                column: "ExpirationDate",
                value: new DateTime(2024, 10, 2, 15, 11, 17, 865, DateTimeKind.Local).AddTicks(2039));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 3,
                column: "ExpirationDate",
                value: new DateTime(2027, 5, 2, 15, 11, 17, 865, DateTimeKind.Local).AddTicks(2043));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 4,
                column: "ExpirationDate",
                value: new DateTime(2028, 2, 2, 15, 11, 17, 865, DateTimeKind.Local).AddTicks(2046));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 5,
                column: "ExpirationDate",
                value: new DateTime(2026, 12, 2, 15, 11, 17, 865, DateTimeKind.Local).AddTicks(2049));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 6,
                column: "ExpirationDate",
                value: new DateTime(2025, 7, 2, 15, 11, 17, 865, DateTimeKind.Local).AddTicks(2052));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 7,
                column: "ExpirationDate",
                value: new DateTime(2025, 10, 2, 15, 11, 17, 865, DateTimeKind.Local).AddTicks(2054));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 8,
                column: "ExpirationDate",
                value: new DateTime(2025, 1, 2, 15, 11, 17, 865, DateTimeKind.Local).AddTicks(2057));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 9,
                column: "ExpirationDate",
                value: new DateTime(2027, 9, 2, 15, 11, 17, 865, DateTimeKind.Local).AddTicks(2059));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 10,
                column: "ExpirationDate",
                value: new DateTime(2026, 6, 2, 15, 11, 17, 865, DateTimeKind.Local).AddTicks(2062));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 11,
                column: "ExpirationDate",
                value: new DateTime(2026, 11, 2, 15, 11, 17, 865, DateTimeKind.Local).AddTicks(2063));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 12,
                column: "ExpirationDate",
                value: new DateTime(2026, 3, 2, 15, 11, 17, 865, DateTimeKind.Local).AddTicks(2066));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 13,
                column: "ExpirationDate",
                value: new DateTime(2027, 2, 2, 15, 11, 17, 865, DateTimeKind.Local).AddTicks(2068));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 14,
                column: "ExpirationDate",
                value: new DateTime(2028, 1, 2, 15, 11, 17, 865, DateTimeKind.Local).AddTicks(2070));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 15,
                column: "ExpirationDate",
                value: new DateTime(2025, 5, 2, 15, 11, 17, 865, DateTimeKind.Local).AddTicks(2073));

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2023, 7, 23, 15, 11, 17, 865, DateTimeKind.Local).AddTicks(2147));

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2023, 7, 24, 15, 11, 17, 865, DateTimeKind.Local).AddTicks(2157));

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2023, 7, 25, 15, 11, 17, 865, DateTimeKind.Local).AddTicks(2161));

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 4,
                column: "Date",
                value: new DateTime(2023, 7, 26, 15, 11, 17, 865, DateTimeKind.Local).AddTicks(2163));

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 5,
                column: "Date",
                value: new DateTime(2023, 7, 27, 15, 11, 17, 865, DateTimeKind.Local).AddTicks(2166));

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 6,
                column: "Date",
                value: new DateTime(2023, 7, 28, 15, 11, 17, 865, DateTimeKind.Local).AddTicks(2169));

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 7,
                column: "Date",
                value: new DateTime(2023, 7, 29, 15, 11, 17, 865, DateTimeKind.Local).AddTicks(2171));

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 8,
                column: "Date",
                value: new DateTime(2023, 7, 29, 15, 11, 17, 865, DateTimeKind.Local).AddTicks(2240));

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 9,
                column: "Date",
                value: new DateTime(2023, 7, 29, 15, 11, 17, 865, DateTimeKind.Local).AddTicks(2243));

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 10,
                column: "Date",
                value: new DateTime(2023, 7, 29, 15, 11, 17, 865, DateTimeKind.Local).AddTicks(2246));

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 11,
                column: "Date",
                value: new DateTime(2023, 7, 29, 15, 11, 17, 865, DateTimeKind.Local).AddTicks(2249));

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 12,
                column: "Date",
                value: new DateTime(2023, 7, 30, 15, 11, 17, 865, DateTimeKind.Local).AddTicks(2251));

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 13,
                column: "Date",
                value: new DateTime(2023, 7, 30, 15, 11, 17, 865, DateTimeKind.Local).AddTicks(2254));

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 14,
                column: "Date",
                value: new DateTime(2023, 7, 30, 15, 11, 17, 865, DateTimeKind.Local).AddTicks(2256));

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 15,
                column: "Date",
                value: new DateTime(2023, 7, 30, 15, 11, 17, 865, DateTimeKind.Local).AddTicks(2257));

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 16,
                column: "Date",
                value: new DateTime(2023, 7, 31, 15, 11, 17, 865, DateTimeKind.Local).AddTicks(2259));

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 17,
                column: "Date",
                value: new DateTime(2023, 7, 31, 15, 11, 17, 865, DateTimeKind.Local).AddTicks(2262));

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 18,
                column: "Date",
                value: new DateTime(2023, 7, 31, 15, 11, 17, 865, DateTimeKind.Local).AddTicks(2267));

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 19,
                column: "Date",
                value: new DateTime(2023, 7, 31, 15, 11, 17, 865, DateTimeKind.Local).AddTicks(2270));

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 20,
                column: "Date",
                value: new DateTime(2023, 7, 31, 15, 11, 17, 865, DateTimeKind.Local).AddTicks(2271));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "VerifiedAt",
                value: new DateTime(2023, 7, 27, 15, 11, 17, 774, DateTimeKind.Local).AddTicks(5973));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "VerifiedAt",
                value: new DateTime(2023, 7, 27, 15, 11, 17, 780, DateTimeKind.Local).AddTicks(8489));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "VerifiedAt",
                value: new DateTime(2023, 7, 28, 15, 11, 17, 787, DateTimeKind.Local).AddTicks(5303));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                column: "VerifiedAt",
                value: new DateTime(2023, 7, 28, 15, 11, 17, 794, DateTimeKind.Local).AddTicks(4311));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                column: "VerifiedAt",
                value: new DateTime(2023, 7, 30, 15, 11, 17, 800, DateTimeKind.Local).AddTicks(7377));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6,
                column: "VerifiedAt",
                value: new DateTime(2023, 7, 31, 15, 11, 17, 807, DateTimeKind.Local).AddTicks(279));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 7,
                column: "VerifiedAt",
                value: new DateTime(2023, 7, 31, 15, 11, 17, 813, DateTimeKind.Local).AddTicks(2394));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 8,
                column: "VerifiedAt",
                value: new DateTime(2023, 7, 31, 15, 11, 17, 819, DateTimeKind.Local).AddTicks(7472));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 9,
                column: "VerifiedAt",
                value: new DateTime(2023, 8, 1, 15, 11, 17, 826, DateTimeKind.Local).AddTicks(5452));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 10,
                column: "VerifiedAt",
                value: new DateTime(2023, 8, 1, 15, 11, 17, 832, DateTimeKind.Local).AddTicks(8778));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 11,
                column: "VerifiedAt",
                value: new DateTime(2023, 8, 1, 15, 11, 17, 839, DateTimeKind.Local).AddTicks(1772));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 12,
                column: "VerifiedAt",
                value: new DateTime(2023, 8, 1, 15, 11, 17, 845, DateTimeKind.Local).AddTicks(4331));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 13,
                column: "VerifiedAt",
                value: new DateTime(2023, 8, 1, 15, 11, 17, 852, DateTimeKind.Local).AddTicks(1053));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 14,
                column: "VerifiedAt",
                value: new DateTime(2023, 8, 1, 15, 11, 17, 858, DateTimeKind.Local).AddTicks(8089));
        }
    }
}
