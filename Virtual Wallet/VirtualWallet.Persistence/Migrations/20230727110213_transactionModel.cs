using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VirtualWallet.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class transactionModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TransactionType",
                table: "Transactions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 1,
                column: "ExpirationDate",
                value: new DateTime(2025, 10, 27, 14, 2, 13, 233, DateTimeKind.Local).AddTicks(312));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 2,
                column: "ExpirationDate",
                value: new DateTime(2024, 9, 27, 14, 2, 13, 233, DateTimeKind.Local).AddTicks(325));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 3,
                column: "ExpirationDate",
                value: new DateTime(2027, 4, 27, 14, 2, 13, 233, DateTimeKind.Local).AddTicks(328));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 4,
                column: "ExpirationDate",
                value: new DateTime(2028, 1, 27, 14, 2, 13, 233, DateTimeKind.Local).AddTicks(331));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 5,
                column: "ExpirationDate",
                value: new DateTime(2026, 11, 27, 14, 2, 13, 233, DateTimeKind.Local).AddTicks(334));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 6,
                column: "ExpirationDate",
                value: new DateTime(2025, 6, 27, 14, 2, 13, 233, DateTimeKind.Local).AddTicks(337));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 7,
                column: "ExpirationDate",
                value: new DateTime(2025, 9, 27, 14, 2, 13, 233, DateTimeKind.Local).AddTicks(339));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 8,
                column: "ExpirationDate",
                value: new DateTime(2024, 12, 27, 14, 2, 13, 233, DateTimeKind.Local).AddTicks(341));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 9,
                column: "ExpirationDate",
                value: new DateTime(2027, 8, 27, 14, 2, 13, 233, DateTimeKind.Local).AddTicks(344));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 10,
                column: "ExpirationDate",
                value: new DateTime(2026, 5, 27, 14, 2, 13, 233, DateTimeKind.Local).AddTicks(347));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 11,
                column: "ExpirationDate",
                value: new DateTime(2026, 10, 27, 14, 2, 13, 233, DateTimeKind.Local).AddTicks(349));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 12,
                column: "ExpirationDate",
                value: new DateTime(2026, 2, 27, 14, 2, 13, 233, DateTimeKind.Local).AddTicks(352));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 13,
                column: "ExpirationDate",
                value: new DateTime(2027, 1, 27, 14, 2, 13, 233, DateTimeKind.Local).AddTicks(354));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 14,
                column: "ExpirationDate",
                value: new DateTime(2027, 12, 27, 14, 2, 13, 233, DateTimeKind.Local).AddTicks(356));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 15,
                column: "ExpirationDate",
                value: new DateTime(2025, 4, 27, 14, 2, 13, 233, DateTimeKind.Local).AddTicks(358));

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Date", "TransactionType" },
                values: new object[] { new DateTime(2023, 7, 17, 14, 2, 13, 233, DateTimeKind.Local).AddTicks(440), 0 });

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Date", "TransactionType" },
                values: new object[] { new DateTime(2023, 7, 18, 14, 2, 13, 233, DateTimeKind.Local).AddTicks(445), 0 });

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Date", "TransactionType" },
                values: new object[] { new DateTime(2023, 7, 19, 14, 2, 13, 233, DateTimeKind.Local).AddTicks(447), 0 });

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Date", "TransactionType" },
                values: new object[] { new DateTime(2023, 7, 20, 14, 2, 13, 233, DateTimeKind.Local).AddTicks(450), 0 });

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Date", "TransactionType" },
                values: new object[] { new DateTime(2023, 7, 21, 14, 2, 13, 233, DateTimeKind.Local).AddTicks(452), 0 });

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Date", "TransactionType" },
                values: new object[] { new DateTime(2023, 7, 22, 14, 2, 13, 233, DateTimeKind.Local).AddTicks(454), 0 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "VerifiedAt",
                value: new DateTime(2023, 7, 21, 14, 2, 13, 159, DateTimeKind.Local).AddTicks(3704));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "VerifiedAt",
                value: new DateTime(2023, 7, 21, 14, 2, 13, 165, DateTimeKind.Local).AddTicks(8586));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "VerifiedAt",
                value: new DateTime(2023, 7, 22, 14, 2, 13, 172, DateTimeKind.Local).AddTicks(6032));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                column: "VerifiedAt",
                value: new DateTime(2023, 7, 22, 14, 2, 13, 179, DateTimeKind.Local).AddTicks(7596));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                column: "VerifiedAt",
                value: new DateTime(2023, 7, 24, 14, 2, 13, 186, DateTimeKind.Local).AddTicks(5614));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6,
                column: "VerifiedAt",
                value: new DateTime(2023, 7, 25, 14, 2, 13, 193, DateTimeKind.Local).AddTicks(997));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 7,
                column: "VerifiedAt",
                value: new DateTime(2023, 7, 25, 14, 2, 13, 199, DateTimeKind.Local).AddTicks(5103));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 8,
                column: "VerifiedAt",
                value: new DateTime(2023, 7, 25, 14, 2, 13, 206, DateTimeKind.Local).AddTicks(317));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 9,
                column: "VerifiedAt",
                value: new DateTime(2023, 7, 26, 14, 2, 13, 212, DateTimeKind.Local).AddTicks(4272));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 10,
                column: "VerifiedAt",
                value: new DateTime(2023, 7, 26, 14, 2, 13, 218, DateTimeKind.Local).AddTicks(8205));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 11,
                column: "VerifiedAt",
                value: new DateTime(2023, 7, 26, 14, 2, 13, 226, DateTimeKind.Local).AddTicks(5340));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TransactionType",
                table: "Transactions");

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 1,
                column: "ExpirationDate",
                value: new DateTime(2025, 10, 27, 10, 29, 19, 759, DateTimeKind.Local).AddTicks(2830));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 2,
                column: "ExpirationDate",
                value: new DateTime(2024, 9, 27, 10, 29, 19, 759, DateTimeKind.Local).AddTicks(2838));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 3,
                column: "ExpirationDate",
                value: new DateTime(2027, 4, 27, 10, 29, 19, 759, DateTimeKind.Local).AddTicks(2841));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 4,
                column: "ExpirationDate",
                value: new DateTime(2028, 1, 27, 10, 29, 19, 759, DateTimeKind.Local).AddTicks(2843));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 5,
                column: "ExpirationDate",
                value: new DateTime(2026, 11, 27, 10, 29, 19, 759, DateTimeKind.Local).AddTicks(2846));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 6,
                column: "ExpirationDate",
                value: new DateTime(2025, 6, 27, 10, 29, 19, 759, DateTimeKind.Local).AddTicks(2851));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 7,
                column: "ExpirationDate",
                value: new DateTime(2025, 9, 27, 10, 29, 19, 759, DateTimeKind.Local).AddTicks(2853));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 8,
                column: "ExpirationDate",
                value: new DateTime(2024, 12, 27, 10, 29, 19, 759, DateTimeKind.Local).AddTicks(2855));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 9,
                column: "ExpirationDate",
                value: new DateTime(2027, 8, 27, 10, 29, 19, 759, DateTimeKind.Local).AddTicks(2858));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 10,
                column: "ExpirationDate",
                value: new DateTime(2026, 5, 27, 10, 29, 19, 759, DateTimeKind.Local).AddTicks(2860));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 11,
                column: "ExpirationDate",
                value: new DateTime(2026, 10, 27, 10, 29, 19, 759, DateTimeKind.Local).AddTicks(2862));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 12,
                column: "ExpirationDate",
                value: new DateTime(2026, 2, 27, 10, 29, 19, 759, DateTimeKind.Local).AddTicks(2865));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 13,
                column: "ExpirationDate",
                value: new DateTime(2027, 1, 27, 10, 29, 19, 759, DateTimeKind.Local).AddTicks(2867));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 14,
                column: "ExpirationDate",
                value: new DateTime(2027, 12, 27, 10, 29, 19, 759, DateTimeKind.Local).AddTicks(2869));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 15,
                column: "ExpirationDate",
                value: new DateTime(2025, 4, 27, 10, 29, 19, 759, DateTimeKind.Local).AddTicks(2871));

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2023, 7, 17, 10, 29, 19, 759, DateTimeKind.Local).AddTicks(2944));

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2023, 7, 18, 10, 29, 19, 759, DateTimeKind.Local).AddTicks(2954));

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2023, 7, 19, 10, 29, 19, 759, DateTimeKind.Local).AddTicks(2956));

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 4,
                column: "Date",
                value: new DateTime(2023, 7, 20, 10, 29, 19, 759, DateTimeKind.Local).AddTicks(2958));

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 5,
                column: "Date",
                value: new DateTime(2023, 7, 21, 10, 29, 19, 759, DateTimeKind.Local).AddTicks(2961));

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 6,
                column: "Date",
                value: new DateTime(2023, 7, 22, 10, 29, 19, 759, DateTimeKind.Local).AddTicks(2963));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "VerifiedAt",
                value: new DateTime(2023, 7, 21, 10, 29, 19, 687, DateTimeKind.Local).AddTicks(9561));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "VerifiedAt",
                value: new DateTime(2023, 7, 21, 10, 29, 19, 694, DateTimeKind.Local).AddTicks(3417));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "VerifiedAt",
                value: new DateTime(2023, 7, 22, 10, 29, 19, 700, DateTimeKind.Local).AddTicks(8308));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                column: "VerifiedAt",
                value: new DateTime(2023, 7, 22, 10, 29, 19, 707, DateTimeKind.Local).AddTicks(1533));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                column: "VerifiedAt",
                value: new DateTime(2023, 7, 24, 10, 29, 19, 713, DateTimeKind.Local).AddTicks(7791));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6,
                column: "VerifiedAt",
                value: new DateTime(2023, 7, 25, 10, 29, 19, 720, DateTimeKind.Local).AddTicks(5258));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 7,
                column: "VerifiedAt",
                value: new DateTime(2023, 7, 25, 10, 29, 19, 726, DateTimeKind.Local).AddTicks(8523));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 8,
                column: "VerifiedAt",
                value: new DateTime(2023, 7, 25, 10, 29, 19, 733, DateTimeKind.Local).AddTicks(3528));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 9,
                column: "VerifiedAt",
                value: new DateTime(2023, 7, 26, 10, 29, 19, 739, DateTimeKind.Local).AddTicks(6767));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 10,
                column: "VerifiedAt",
                value: new DateTime(2023, 7, 26, 10, 29, 19, 746, DateTimeKind.Local).AddTicks(3190));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 11,
                column: "VerifiedAt",
                value: new DateTime(2023, 7, 26, 10, 29, 19, 752, DateTimeKind.Local).AddTicks(8985));
        }
    }
}
