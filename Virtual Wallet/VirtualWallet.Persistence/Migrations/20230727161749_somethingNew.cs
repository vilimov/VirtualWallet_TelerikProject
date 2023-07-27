using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VirtualWallet.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class somethingNew : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CardNumber",
                table: "Transactions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 1,
                column: "ExpirationDate",
                value: new DateTime(2025, 10, 27, 19, 17, 49, 154, DateTimeKind.Local).AddTicks(9950));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 2,
                column: "ExpirationDate",
                value: new DateTime(2024, 9, 27, 19, 17, 49, 154, DateTimeKind.Local).AddTicks(9979));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 3,
                column: "ExpirationDate",
                value: new DateTime(2027, 4, 27, 19, 17, 49, 154, DateTimeKind.Local).AddTicks(9984));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 4,
                column: "ExpirationDate",
                value: new DateTime(2028, 1, 27, 19, 17, 49, 154, DateTimeKind.Local).AddTicks(9986));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 5,
                column: "ExpirationDate",
                value: new DateTime(2026, 11, 27, 19, 17, 49, 154, DateTimeKind.Local).AddTicks(9989));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 6,
                column: "ExpirationDate",
                value: new DateTime(2025, 6, 27, 19, 17, 49, 154, DateTimeKind.Local).AddTicks(9993));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 7,
                column: "ExpirationDate",
                value: new DateTime(2025, 9, 27, 19, 17, 49, 154, DateTimeKind.Local).AddTicks(9995));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 8,
                column: "ExpirationDate",
                value: new DateTime(2024, 12, 27, 19, 17, 49, 154, DateTimeKind.Local).AddTicks(9998));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 9,
                column: "ExpirationDate",
                value: new DateTime(2027, 8, 27, 19, 17, 49, 155, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 10,
                column: "ExpirationDate",
                value: new DateTime(2026, 5, 27, 19, 17, 49, 155, DateTimeKind.Local).AddTicks(3));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 11,
                column: "ExpirationDate",
                value: new DateTime(2026, 10, 27, 19, 17, 49, 155, DateTimeKind.Local).AddTicks(6));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 12,
                column: "ExpirationDate",
                value: new DateTime(2026, 2, 27, 19, 17, 49, 155, DateTimeKind.Local).AddTicks(8));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 13,
                column: "ExpirationDate",
                value: new DateTime(2027, 1, 27, 19, 17, 49, 155, DateTimeKind.Local).AddTicks(11));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 14,
                column: "ExpirationDate",
                value: new DateTime(2027, 12, 27, 19, 17, 49, 155, DateTimeKind.Local).AddTicks(13));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 15,
                column: "ExpirationDate",
                value: new DateTime(2025, 4, 27, 19, 17, 49, 155, DateTimeKind.Local).AddTicks(15));

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CardNumber", "Date" },
                values: new object[] { null, new DateTime(2023, 7, 17, 19, 17, 49, 155, DateTimeKind.Local).AddTicks(85) });

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CardNumber", "Date" },
                values: new object[] { null, new DateTime(2023, 7, 18, 19, 17, 49, 155, DateTimeKind.Local).AddTicks(92) });

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CardNumber", "Date" },
                values: new object[] { null, new DateTime(2023, 7, 19, 19, 17, 49, 155, DateTimeKind.Local).AddTicks(94) });

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CardNumber", "Date" },
                values: new object[] { null, new DateTime(2023, 7, 20, 19, 17, 49, 155, DateTimeKind.Local).AddTicks(95) });

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CardNumber", "Date" },
                values: new object[] { null, new DateTime(2023, 7, 21, 19, 17, 49, 155, DateTimeKind.Local).AddTicks(98) });

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CardNumber", "Date" },
                values: new object[] { null, new DateTime(2023, 7, 22, 19, 17, 49, 155, DateTimeKind.Local).AddTicks(101) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "VerifiedAt",
                value: new DateTime(2023, 7, 21, 19, 17, 49, 78, DateTimeKind.Local).AddTicks(8961));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "VerifiedAt",
                value: new DateTime(2023, 7, 21, 19, 17, 49, 86, DateTimeKind.Local).AddTicks(4868));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "VerifiedAt",
                value: new DateTime(2023, 7, 22, 19, 17, 49, 93, DateTimeKind.Local).AddTicks(3307));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                column: "VerifiedAt",
                value: new DateTime(2023, 7, 22, 19, 17, 49, 100, DateTimeKind.Local).AddTicks(1451));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                column: "VerifiedAt",
                value: new DateTime(2023, 7, 24, 19, 17, 49, 106, DateTimeKind.Local).AddTicks(9679));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6,
                column: "VerifiedAt",
                value: new DateTime(2023, 7, 25, 19, 17, 49, 113, DateTimeKind.Local).AddTicks(5973));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 7,
                column: "VerifiedAt",
                value: new DateTime(2023, 7, 25, 19, 17, 49, 120, DateTimeKind.Local).AddTicks(2702));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 8,
                column: "VerifiedAt",
                value: new DateTime(2023, 7, 25, 19, 17, 49, 126, DateTimeKind.Local).AddTicks(8175));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 9,
                column: "VerifiedAt",
                value: new DateTime(2023, 7, 26, 19, 17, 49, 134, DateTimeKind.Local).AddTicks(1356));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 10,
                column: "VerifiedAt",
                value: new DateTime(2023, 7, 26, 19, 17, 49, 141, DateTimeKind.Local).AddTicks(2122));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 11,
                column: "VerifiedAt",
                value: new DateTime(2023, 7, 26, 19, 17, 49, 148, DateTimeKind.Local).AddTicks(1032));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CardNumber",
                table: "Transactions");

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
                column: "Date",
                value: new DateTime(2023, 7, 17, 14, 2, 13, 233, DateTimeKind.Local).AddTicks(440));

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2023, 7, 18, 14, 2, 13, 233, DateTimeKind.Local).AddTicks(445));

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2023, 7, 19, 14, 2, 13, 233, DateTimeKind.Local).AddTicks(447));

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 4,
                column: "Date",
                value: new DateTime(2023, 7, 20, 14, 2, 13, 233, DateTimeKind.Local).AddTicks(450));

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 5,
                column: "Date",
                value: new DateTime(2023, 7, 21, 14, 2, 13, 233, DateTimeKind.Local).AddTicks(452));

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 6,
                column: "Date",
                value: new DateTime(2023, 7, 22, 14, 2, 13, 233, DateTimeKind.Local).AddTicks(454));

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
    }
}
