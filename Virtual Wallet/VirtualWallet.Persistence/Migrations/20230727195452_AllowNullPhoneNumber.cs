using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VirtualWallet.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AllowNullPhoneNumber : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "Users",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10);

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 1,
                column: "ExpirationDate",
                value: new DateTime(2025, 10, 27, 22, 54, 52, 717, DateTimeKind.Local).AddTicks(1766));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 2,
                column: "ExpirationDate",
                value: new DateTime(2024, 9, 27, 22, 54, 52, 717, DateTimeKind.Local).AddTicks(1771));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 3,
                column: "ExpirationDate",
                value: new DateTime(2027, 4, 27, 22, 54, 52, 717, DateTimeKind.Local).AddTicks(1774));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 4,
                column: "ExpirationDate",
                value: new DateTime(2028, 1, 27, 22, 54, 52, 717, DateTimeKind.Local).AddTicks(1776));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 5,
                column: "ExpirationDate",
                value: new DateTime(2026, 11, 27, 22, 54, 52, 717, DateTimeKind.Local).AddTicks(1779));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 6,
                column: "ExpirationDate",
                value: new DateTime(2025, 6, 27, 22, 54, 52, 717, DateTimeKind.Local).AddTicks(1781));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 7,
                column: "ExpirationDate",
                value: new DateTime(2025, 9, 27, 22, 54, 52, 717, DateTimeKind.Local).AddTicks(1784));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 8,
                column: "ExpirationDate",
                value: new DateTime(2024, 12, 27, 22, 54, 52, 717, DateTimeKind.Local).AddTicks(1786));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 9,
                column: "ExpirationDate",
                value: new DateTime(2027, 8, 27, 22, 54, 52, 717, DateTimeKind.Local).AddTicks(1787));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 10,
                column: "ExpirationDate",
                value: new DateTime(2026, 5, 27, 22, 54, 52, 717, DateTimeKind.Local).AddTicks(1789));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 11,
                column: "ExpirationDate",
                value: new DateTime(2026, 10, 27, 22, 54, 52, 717, DateTimeKind.Local).AddTicks(1791));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 12,
                column: "ExpirationDate",
                value: new DateTime(2026, 2, 27, 22, 54, 52, 717, DateTimeKind.Local).AddTicks(1793));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 13,
                column: "ExpirationDate",
                value: new DateTime(2027, 1, 27, 22, 54, 52, 717, DateTimeKind.Local).AddTicks(1794));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 14,
                column: "ExpirationDate",
                value: new DateTime(2027, 12, 27, 22, 54, 52, 717, DateTimeKind.Local).AddTicks(1796));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 15,
                column: "ExpirationDate",
                value: new DateTime(2025, 4, 27, 22, 54, 52, 717, DateTimeKind.Local).AddTicks(1797));

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2023, 7, 17, 22, 54, 52, 717, DateTimeKind.Local).AddTicks(1908));

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2023, 7, 18, 22, 54, 52, 717, DateTimeKind.Local).AddTicks(1913));

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2023, 7, 19, 22, 54, 52, 717, DateTimeKind.Local).AddTicks(1914));

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 4,
                column: "Date",
                value: new DateTime(2023, 7, 20, 22, 54, 52, 717, DateTimeKind.Local).AddTicks(1916));

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 5,
                column: "Date",
                value: new DateTime(2023, 7, 21, 22, 54, 52, 717, DateTimeKind.Local).AddTicks(1920));

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 6,
                column: "Date",
                value: new DateTime(2023, 7, 22, 22, 54, 52, 717, DateTimeKind.Local).AddTicks(1923));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "VerifiedAt",
                value: new DateTime(2023, 7, 21, 22, 54, 52, 670, DateTimeKind.Local).AddTicks(9718));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "VerifiedAt",
                value: new DateTime(2023, 7, 21, 22, 54, 52, 675, DateTimeKind.Local).AddTicks(1680));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "VerifiedAt",
                value: new DateTime(2023, 7, 22, 22, 54, 52, 679, DateTimeKind.Local).AddTicks(3218));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                column: "VerifiedAt",
                value: new DateTime(2023, 7, 22, 22, 54, 52, 683, DateTimeKind.Local).AddTicks(5163));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                column: "VerifiedAt",
                value: new DateTime(2023, 7, 24, 22, 54, 52, 687, DateTimeKind.Local).AddTicks(6819));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6,
                column: "VerifiedAt",
                value: new DateTime(2023, 7, 25, 22, 54, 52, 691, DateTimeKind.Local).AddTicks(8615));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 7,
                column: "VerifiedAt",
                value: new DateTime(2023, 7, 25, 22, 54, 52, 696, DateTimeKind.Local).AddTicks(161));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 8,
                column: "VerifiedAt",
                value: new DateTime(2023, 7, 25, 22, 54, 52, 700, DateTimeKind.Local).AddTicks(2744));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 9,
                column: "VerifiedAt",
                value: new DateTime(2023, 7, 26, 22, 54, 52, 704, DateTimeKind.Local).AddTicks(4445));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 10,
                column: "VerifiedAt",
                value: new DateTime(2023, 7, 26, 22, 54, 52, 708, DateTimeKind.Local).AddTicks(6581));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 11,
                column: "VerifiedAt",
                value: new DateTime(2023, 7, 26, 22, 54, 52, 712, DateTimeKind.Local).AddTicks(8857));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "Users",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10,
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 1,
                column: "ExpirationDate",
                value: new DateTime(2025, 10, 27, 20, 14, 50, 749, DateTimeKind.Local).AddTicks(433));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 2,
                column: "ExpirationDate",
                value: new DateTime(2024, 9, 27, 20, 14, 50, 749, DateTimeKind.Local).AddTicks(441));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 3,
                column: "ExpirationDate",
                value: new DateTime(2027, 4, 27, 20, 14, 50, 749, DateTimeKind.Local).AddTicks(443));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 4,
                column: "ExpirationDate",
                value: new DateTime(2028, 1, 27, 20, 14, 50, 749, DateTimeKind.Local).AddTicks(445));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 5,
                column: "ExpirationDate",
                value: new DateTime(2026, 11, 27, 20, 14, 50, 749, DateTimeKind.Local).AddTicks(447));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 6,
                column: "ExpirationDate",
                value: new DateTime(2025, 6, 27, 20, 14, 50, 749, DateTimeKind.Local).AddTicks(450));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 7,
                column: "ExpirationDate",
                value: new DateTime(2025, 9, 27, 20, 14, 50, 749, DateTimeKind.Local).AddTicks(452));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 8,
                column: "ExpirationDate",
                value: new DateTime(2024, 12, 27, 20, 14, 50, 749, DateTimeKind.Local).AddTicks(453));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 9,
                column: "ExpirationDate",
                value: new DateTime(2027, 8, 27, 20, 14, 50, 749, DateTimeKind.Local).AddTicks(455));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 10,
                column: "ExpirationDate",
                value: new DateTime(2026, 5, 27, 20, 14, 50, 749, DateTimeKind.Local).AddTicks(457));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 11,
                column: "ExpirationDate",
                value: new DateTime(2026, 10, 27, 20, 14, 50, 749, DateTimeKind.Local).AddTicks(458));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 12,
                column: "ExpirationDate",
                value: new DateTime(2026, 2, 27, 20, 14, 50, 749, DateTimeKind.Local).AddTicks(460));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 13,
                column: "ExpirationDate",
                value: new DateTime(2027, 1, 27, 20, 14, 50, 749, DateTimeKind.Local).AddTicks(461));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 14,
                column: "ExpirationDate",
                value: new DateTime(2027, 12, 27, 20, 14, 50, 749, DateTimeKind.Local).AddTicks(463));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 15,
                column: "ExpirationDate",
                value: new DateTime(2025, 4, 27, 20, 14, 50, 749, DateTimeKind.Local).AddTicks(464));

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2023, 7, 17, 20, 14, 50, 749, DateTimeKind.Local).AddTicks(533));

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2023, 7, 18, 20, 14, 50, 749, DateTimeKind.Local).AddTicks(537));

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2023, 7, 19, 20, 14, 50, 749, DateTimeKind.Local).AddTicks(539));

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 4,
                column: "Date",
                value: new DateTime(2023, 7, 20, 20, 14, 50, 749, DateTimeKind.Local).AddTicks(540));

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 5,
                column: "Date",
                value: new DateTime(2023, 7, 21, 20, 14, 50, 749, DateTimeKind.Local).AddTicks(542));

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 6,
                column: "Date",
                value: new DateTime(2023, 7, 22, 20, 14, 50, 749, DateTimeKind.Local).AddTicks(544));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "VerifiedAt",
                value: new DateTime(2023, 7, 21, 20, 14, 50, 705, DateTimeKind.Local).AddTicks(4531));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "VerifiedAt",
                value: new DateTime(2023, 7, 21, 20, 14, 50, 709, DateTimeKind.Local).AddTicks(3670));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "VerifiedAt",
                value: new DateTime(2023, 7, 22, 20, 14, 50, 713, DateTimeKind.Local).AddTicks(3410));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                column: "VerifiedAt",
                value: new DateTime(2023, 7, 22, 20, 14, 50, 717, DateTimeKind.Local).AddTicks(2459));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                column: "VerifiedAt",
                value: new DateTime(2023, 7, 24, 20, 14, 50, 721, DateTimeKind.Local).AddTicks(2506));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6,
                column: "VerifiedAt",
                value: new DateTime(2023, 7, 25, 20, 14, 50, 725, DateTimeKind.Local).AddTicks(2680));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 7,
                column: "VerifiedAt",
                value: new DateTime(2023, 7, 25, 20, 14, 50, 729, DateTimeKind.Local).AddTicks(2213));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 8,
                column: "VerifiedAt",
                value: new DateTime(2023, 7, 25, 20, 14, 50, 733, DateTimeKind.Local).AddTicks(2028));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 9,
                column: "VerifiedAt",
                value: new DateTime(2023, 7, 26, 20, 14, 50, 737, DateTimeKind.Local).AddTicks(1541));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 10,
                column: "VerifiedAt",
                value: new DateTime(2023, 7, 26, 20, 14, 50, 741, DateTimeKind.Local).AddTicks(997));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 11,
                column: "VerifiedAt",
                value: new DateTime(2023, 7, 26, 20, 14, 50, 745, DateTimeKind.Local).AddTicks(545));
        }
    }
}
