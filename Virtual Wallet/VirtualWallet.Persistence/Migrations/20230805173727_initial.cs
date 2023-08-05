﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace VirtualWallet.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(170)", maxLength: 170, nullable: false),
                    Salt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VerificationToken = table.Column<string>(type: "nvarchar(170)", maxLength: 170, nullable: true),
                    VerifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Photo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsAdmin = table.Column<bool>(type: "bit", nullable: false),
                    IsBlocked = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    WalletId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                    Number = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                    ExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CardHolder = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    CheckNumber = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    CurrencyCode = table.Column<int>(type: "int", nullable: false),
                    IsCreditCard = table.Column<bool>(type: "bit", nullable: false),
                    HasExpired = table.Column<bool>(type: "bit", nullable: false),
                    IsInactive = table.Column<bool>(type: "bit", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cards_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(20,5)", precision: 20, scale: 5, nullable: false),
                    TransactionType = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SenderId = table.Column<int>(type: "int", nullable: false),
                    RecipientId = table.Column<int>(type: "int", nullable: false),
                    IsInbound = table.Column<bool>(type: "bit", nullable: false),
                    CardNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AmountReceived = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CurrencyExchangeRate = table.Column<double>(type: "float", nullable: true),
                    SenderWalletCurrency = table.Column<int>(type: "int", nullable: true),
                    RecipientWalletCurrency = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transactions_Users_RecipientId",
                        column: x => x.RecipientId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Transactions_Users_SenderId",
                        column: x => x.SenderId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Wallets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CurrencyCode = table.Column<int>(type: "int", nullable: false),
                    Balance = table.Column<decimal>(type: "decimal(20,5)", precision: 20, scale: 5, nullable: false),
                    Blocked = table.Column<decimal>(type: "decimal(20,5)", precision: 20, scale: 5, nullable: false),
                    IsInactive = table.Column<bool>(type: "bit", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wallets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Wallets_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FirstName", "IsAdmin", "IsBlocked", "IsDeleted", "LastName", "Password", "PhoneNumber", "Photo", "Salt", "Username", "VerificationToken", "VerifiedAt", "WalletId" },
                values: new object[,]
                {
                    { 1, "elon@musk.com", "Elon", true, false, false, "Musk", "z3cYHVk1R4my8gZeon0xrHmfDE8Vpxd5j7QTpIvc3GM=", "1234567890", "elon_musk.jpg", "aYkdwwd7tFrZOsBA2Za0qQ==", "ElonMusk", null, new DateTime(2023, 7, 30, 20, 37, 27, 7, DateTimeKind.Local).AddTicks(537), 1 },
                    { 2, "jeff@amazon.com", "Jeff", false, false, false, "Bezos", "p3zsqKJ0kKcdPlp9wSUJtBAP7H9EZ1D1C9miQv32JkU=", "9876543210", "jeff_bezos.jpg", "aYkdwwd7tFrZOsBA2Za0qQ==", "JeffBezos", null, new DateTime(2023, 7, 30, 20, 37, 27, 11, DateTimeKind.Local).AddTicks(239), 2 },
                    { 3, "warren@berkshire.com", "Warren", false, false, false, "Buffett", "n7p8JbjMz1idjRo1BwE2ldlT4rHSxVxGhwQKMT2YIgg=", "9876543210", "warren_buffett.jpg", "aYkdwwd7tFrZOsBA2Za0qQ==", "WarrenBuffett", null, new DateTime(2023, 7, 31, 20, 37, 27, 15, DateTimeKind.Local).AddTicks(200), 3 },
                    { 4, "BillGates@gmaill.com", "Bill", true, false, false, "Gates", "ljrqrV6Ma5F+Z8Q4O4MhRWt9+6b8YXlaQCfFNmVFOoc=", "1234567890", "bill_gates.jpg", "aYkdwwd7tFrZOsBA2Za0qQ==", "BillGates", null, new DateTime(2023, 7, 31, 20, 37, 27, 19, DateTimeKind.Local).AddTicks(658), 4 },
                    { 5, "larry@oracle.com", "Larry", false, false, false, "Ellison", "yWItNvpeF65jhQ4lIBSZug2OEw1vOLgqORfMwqAH/AE=", "9876543210", "larry_ellison.jpg", "aYkdwwd7tFrZOsBA2Za0qQ==", "LarryEllison", null, new DateTime(2023, 8, 2, 20, 37, 27, 23, DateTimeKind.Local).AddTicks(348), 5 },
                    { 6, "mark@facebook.com", "Mark", true, false, false, "Zuckerberg", "aAIBn4DcscHU4QfinnbAq76vHXEca+ruz+r7Q1+m+yA=", "1234567890", "mark_zuckerberg.jpg", "aYkdwwd7tFrZOsBA2Za0qQ==", "MarkZuckerberg", null, new DateTime(2023, 8, 3, 20, 37, 27, 26, DateTimeKind.Local).AddTicks(9897), 6 },
                    { 7, "larry@google.com", "Larry", false, false, false, "Page", "UHRkaY7AmMrwMQMx8yL45Qjwrjhgsdcn2RwppcDM6Ro=", "9876543210", "larry_page.jpg", "aYkdwwd7tFrZOsBA2Za0qQ==", "LarryPage", null, new DateTime(2023, 8, 3, 20, 37, 27, 30, DateTimeKind.Local).AddTicks(9820), 7 },
                    { 8, "sergey@google.com", "Sergey", false, false, false, "Brin", "ogHZo0NPhyhEMdJfs1jGUGjnKf/s4awGIuuYy8025ok=", "1234567890", "sergey_brin.jpg", "aYkdwwd7tFrZOsBA2Za0qQ==", "SergeyBrin", null, new DateTime(2023, 8, 3, 20, 37, 27, 35, DateTimeKind.Local).AddTicks(312), 8 },
                    { 9, "amancio@zara.com", "Amancio", false, false, false, "Ortega", "D5iGczcroSmodpIen53mk2Fj/21O4MusmC6GKb01QF8=", "9876543210", "amancio_ortega.jpg", "aYkdwwd7tFrZOsBA2Za0qQ==", "AmancioOrtega", null, new DateTime(2023, 8, 4, 20, 37, 27, 39, DateTimeKind.Local).AddTicks(371), 9 },
                    { 10, "carlos@telmex.com", "Carlos", false, false, false, "SlimHelu", "cJuzqjHngfuzVhEQFZUEFKaAP+N7qHF+AjJxPdluHaI=", "1234567890", "carlos_slim_helu.jpg", "aYkdwwd7tFrZOsBA2Za0qQ==", "CarlosSlimHelu", null, new DateTime(2023, 8, 4, 20, 37, 27, 43, DateTimeKind.Local).AddTicks(670), 10 },
                    { 11, "mkm_vw@abv.bg", "Admin", true, false, false, "Adminov", "mGCUINPf0hSqMTwCdcnxoQWdGEhsJrYOpjpvQarWLFo=", "1234567890", "Admin.jpg", "aYkdwwd7tFrZOsBA2Za0qQ==", "Admin", null, new DateTime(2023, 8, 4, 20, 37, 27, 47, DateTimeKind.Local).AddTicks(602), 11 },
                    { 12, "User@user.com", "User", false, false, false, "Userov", "mGCUINPf0hSqMTwCdcnxoQWdGEhsJrYOpjpvQarWLFo=", "1234567890", "User.jpg", "aYkdwwd7tFrZOsBA2Za0qQ==", "User", null, new DateTime(2023, 8, 4, 20, 37, 27, 51, DateTimeKind.Local).AddTicks(2292), 12 },
                    { 13, "GwShotwell@SpaceX.com", "Gwynne", false, false, false, "Shotwell", "mGCUINPf0hSqMTwCdcnxoQWdGEhsJrYOpjpvQarWLFo=", "1224364852", "GwynneShotwell.jpg", "aYkdwwd7tFrZOsBA2Za0qQ==", "GwynneShotwell", null, new DateTime(2023, 8, 4, 20, 37, 27, 55, DateTimeKind.Local).AddTicks(2192), 12 },
                    { 14, "SafraCatz@Oracle.com", "Safra", false, false, false, "Catz", "mGCUINPf0hSqMTwCdcnxoQWdGEhsJrYOpjpvQarWLFo=", "1234567890", "SafraCatz.jpg", "aYkdwwd7tFrZOsBA2Za0qQ==", "SafraCatz", null, new DateTime(2023, 8, 4, 20, 37, 27, 59, DateTimeKind.Local).AddTicks(2052), 12 }
                });

            migrationBuilder.InsertData(
                table: "Cards",
                columns: new[] { "Id", "CardHolder", "CheckNumber", "CurrencyCode", "ExpirationDate", "HasExpired", "IsCreditCard", "IsInactive", "Name", "Number", "UserId" },
                values: new object[,]
                {
                    { 1, "Elon Musk", "649", 3, new DateTime(2025, 11, 5, 20, 37, 27, 63, DateTimeKind.Local).AddTicks(1994), false, true, false, "ElonUSD", "8676880603590752", 1 },
                    { 2, "Jeff Bezos", "223", 3, new DateTime(2024, 10, 5, 20, 37, 27, 63, DateTimeKind.Local).AddTicks(2000), false, true, false, "JeffUSD", "3997331179433371", 2 },
                    { 3, "Warren Buffett", "684", 3, new DateTime(2027, 5, 5, 20, 37, 27, 63, DateTimeKind.Local).AddTicks(2003), false, true, false, "WarrenUSD", "7469810858990903", 3 },
                    { 4, "Bill Gates", "623", 3, new DateTime(2028, 2, 5, 20, 37, 27, 63, DateTimeKind.Local).AddTicks(2005), false, false, false, "BillUSD", "7372340136556716", 4 },
                    { 5, "Larry Ellison", "636", 3, new DateTime(2026, 12, 5, 20, 37, 27, 63, DateTimeKind.Local).AddTicks(2008), false, false, false, "LarryUSD", "4503408821426590", 5 },
                    { 6, "Mark Zuckerberg", "973", 2, new DateTime(2025, 7, 5, 20, 37, 27, 63, DateTimeKind.Local).AddTicks(2010), false, true, false, "MarkEUR", "9539114984387891", 6 },
                    { 7, "Larry Page", "247", 2, new DateTime(2025, 10, 5, 20, 37, 27, 63, DateTimeKind.Local).AddTicks(2013), false, false, false, "LarryEUR", "3820743154136639", 7 },
                    { 8, "Sergey Brin", "367", 2, new DateTime(2025, 1, 5, 20, 37, 27, 63, DateTimeKind.Local).AddTicks(2014), false, false, false, "SergeyEUR", "1513410988134823", 8 },
                    { 9, "Amancio Ortega", "256", 2, new DateTime(2027, 9, 5, 20, 37, 27, 63, DateTimeKind.Local).AddTicks(2016), false, false, false, "AmancioEUR", "4588654764785024", 9 },
                    { 10, "Carlos Slim Helu", "208", 2, new DateTime(2026, 6, 5, 20, 37, 27, 63, DateTimeKind.Local).AddTicks(2018), false, false, false, "CarlosEUR", "3525471461987263", 10 },
                    { 11, "Admin", "543", 1, new DateTime(2026, 11, 5, 20, 37, 27, 63, DateTimeKind.Local).AddTicks(2020), false, true, false, "AdminBGN", "3187868110023152", 11 },
                    { 12, "Elon Musk", "660", 1, new DateTime(2026, 3, 5, 20, 37, 27, 63, DateTimeKind.Local).AddTicks(2021), false, false, false, "ElonBGN", "3896973357363677", 1 },
                    { 13, "Warren Buffett", "696", 1, new DateTime(2027, 2, 5, 20, 37, 27, 63, DateTimeKind.Local).AddTicks(2023), false, true, false, "WarrenBGN", "5672253593826517", 3 },
                    { 14, "Bill Gates", "994", 1, new DateTime(2028, 1, 5, 20, 37, 27, 63, DateTimeKind.Local).AddTicks(2025), false, true, false, "BillBGN", "8832823205243008", 4 },
                    { 15, "Amancio Ortega", "645", 1, new DateTime(2025, 5, 5, 20, 37, 27, 63, DateTimeKind.Local).AddTicks(2026), false, true, false, "AmancioBGN", "5243292944936184", 9 }
                });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "Id", "Amount", "AmountReceived", "CardNumber", "CurrencyExchangeRate", "Date", "Description", "IsInbound", "RecipientId", "RecipientWalletCurrency", "SenderId", "SenderWalletCurrency", "TransactionType" },
                values: new object[,]
                {
                    { 1, 111m, 101.03m, null, 0.91020000000000001, new DateTime(2023, 7, 26, 20, 37, 27, 63, DateTimeKind.Local).AddTicks(2101), "Transaction", false, 10, 2, 1, 3, 2 },
                    { 2, 222m, 202.06m, null, 0.91020000000000001, new DateTime(2023, 7, 27, 20, 37, 27, 63, DateTimeKind.Local).AddTicks(2110), "Transfer to my friend Amancio ", false, 9, 2, 2, 3, 2 },
                    { 3, 333m, 303.1m, null, 0.91020000000000001, new DateTime(2023, 7, 28, 20, 37, 27, 63, DateTimeKind.Local).AddTicks(2112), "buying new car", false, 8, 2, 3, 3, 2 },
                    { 4, 444m, 790.59m, null, 1.7806, new DateTime(2023, 7, 29, 20, 37, 27, 63, DateTimeKind.Local).AddTicks(2115), "Payment over invoice 12345678", false, 7, 1, 4, 3, 2 },
                    { 5, 555m, 555m, null, 0.0, new DateTime(2023, 7, 30, 20, 37, 27, 63, DateTimeKind.Local).AddTicks(2117), "Invoice 22446688", false, 6, 1, 5, 1, 2 },
                    { 6, 666m, 1185.88m, null, 1.7806, new DateTime(2023, 7, 31, 20, 37, 27, 63, DateTimeKind.Local).AddTicks(2119), "Deposit for vacation", false, 11, 1, 1, 3, 2 },
                    { 7, 200m, null, "************0752", null, new DateTime(2023, 8, 1, 20, 37, 27, 63, DateTimeKind.Local).AddTicks(2121), "Some cash for my wallet ;)", false, 1, null, 1, 3, 3 },
                    { 8, 1024m, null, "************3371", null, new DateTime(2023, 8, 1, 20, 37, 27, 63, DateTimeKind.Local).AddTicks(2122), "Transfer from card", false, 2, null, 2, 3, 3 },
                    { 9, 50000m, null, "************7891", null, new DateTime(2023, 8, 1, 20, 37, 27, 63, DateTimeKind.Local).AddTicks(2125), "Transfer from card", false, 6, null, 6, 1, 3 },
                    { 10, 1200m, 2136.72m, null, 1.7806, new DateTime(2023, 8, 1, 20, 37, 27, 63, DateTimeKind.Local).AddTicks(2127), "Pay my rent", false, 6, 1, 1, 3, 2 },
                    { 11, 505.55m, 283.61m, null, 0.56159999999999999, new DateTime(2023, 8, 1, 20, 37, 27, 63, DateTimeKind.Local).AddTicks(2129), "Give Warren some coins", false, 3, 3, 5, 1, 2 },
                    { 12, 33.24m, 18.53m, null, 0.56159999999999999, new DateTime(2023, 8, 2, 20, 37, 27, 63, DateTimeKind.Local).AddTicks(2130), "payment", false, 1, 3, 6, 1, 2 },
                    { 13, 156m, null, "************6716", null, new DateTime(2023, 8, 2, 20, 37, 27, 63, DateTimeKind.Local).AddTicks(2132), "why not to cash back some money", false, 4, null, 4, 3, 4 },
                    { 14, 22.99m, null, "************3371", null, new DateTime(2023, 8, 2, 20, 37, 27, 63, DateTimeKind.Local).AddTicks(2134), "personal stuff", false, 4, null, 4, 3, 3 },
                    { 15, 50m, null, "************0752", null, new DateTime(2023, 8, 2, 20, 37, 27, 63, DateTimeKind.Local).AddTicks(2135), "I am transfering some money back to my card", false, 1, null, 1, 3, 4 },
                    { 16, 0.01m, 0.01m, null, 0.0, new DateTime(2023, 8, 3, 20, 37, 27, 63, DateTimeKind.Local).AddTicks(2137), "donation", false, 2, 3, 1, 3, 2 },
                    { 17, 12225.35m, 12225.35m, null, 0.0, new DateTime(2023, 8, 3, 20, 37, 27, 63, DateTimeKind.Local).AddTicks(2140), "Payment for invoice 223332556", false, 3, 3, 1, 3, 2 },
                    { 18, 336m, 336m, null, 0.0, new DateTime(2023, 8, 3, 20, 37, 27, 63, DateTimeKind.Local).AddTicks(2165), "Invoice 103104105", false, 2, 3, 1, 3, 2 },
                    { 19, 1024m, null, "************3371", null, new DateTime(2023, 8, 3, 20, 37, 27, 63, DateTimeKind.Local).AddTicks(2167), "Transfer from card", false, 1, null, 1, 3, 3 },
                    { 20, 1566m, null, "************3371", null, new DateTime(2023, 8, 3, 20, 37, 27, 63, DateTimeKind.Local).AddTicks(2169), "Transfer from card", false, 1, null, 1, 3, 3 }
                });

            migrationBuilder.InsertData(
                table: "Wallets",
                columns: new[] { "Id", "Balance", "Blocked", "CurrencyCode", "IsInactive", "UserId" },
                values: new object[,]
                {
                    { 1, 111111.11m, 0m, 3, false, 1 },
                    { 2, 99999.99m, 0m, 3, false, 2 },
                    { 3, 88888.88m, 0m, 3, false, 3 },
                    { 4, 77777.77m, 0m, 3, false, 4 },
                    { 5, 66666.66m, 0m, 1, false, 5 },
                    { 6, 55555.55m, 0m, 1, false, 6 },
                    { 7, 44444.44m, 0m, 1, false, 7 },
                    { 8, 33333.33m, 0m, 2, false, 8 },
                    { 9, 22222.22m, 0m, 2, false, 9 },
                    { 10, 11111.11m, 0m, 2, false, 10 },
                    { 11, 9999.99m, 0m, 1, false, 11 },
                    { 12, 0.00m, 0m, 1, false, 12 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cards_UserId",
                table: "Cards",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_RecipientId",
                table: "Transactions",
                column: "RecipientId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_SenderId",
                table: "Transactions",
                column: "SenderId");

            migrationBuilder.CreateIndex(
                name: "IX_Wallets_UserId",
                table: "Wallets",
                column: "UserId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cards");

            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "Wallets");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}