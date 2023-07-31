using System;
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
                    VerificationToken = table.Column<string>(type: "nvarchar(170)", maxLength: 170, nullable: true),
                    VerifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Photo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsAdmin = table.Column<bool>(type: "bit", nullable: false),
                    IsBlocked = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
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
                    Number = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                    ExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CardHolder = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    CheckNumber = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
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
                    SenderId = table.Column<int>(type: "int", nullable: false),
                    RecipientId = table.Column<int>(type: "int", nullable: false),
                    IsInbound = table.Column<bool>(type: "bit", nullable: false),
                    CardNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AmountReceived = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CurrencyExchangeRate = table.Column<double>(type: "float", nullable: true)
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
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "IsAdmin", "IsBlocked", "IsDeleted", "Password", "PhoneNumber", "Photo", "Salt", "Username", "VerificationToken", "VerifiedAt" },
                values: new object[,]
                {
                    { 1, "elon@musk.com", true, false, false, "z3cYHVk1R4my8gZeon0xrHmfDE8Vpxd5j7QTpIvc3GM=", "1234567890", "elon_musk.jpg", "aYkdwwd7tFrZOsBA2Za0qQ==", "ElonMusk", null, new DateTime(2023, 7, 25, 16, 17, 21, 206, DateTimeKind.Local).AddTicks(9563) },
                    { 2, "jeff@amazon.com", false, false, false, "p3zsqKJ0kKcdPlp9wSUJtBAP7H9EZ1D1C9miQv32JkU=", "9876543210", "jeff_bezos.jpg", "aYkdwwd7tFrZOsBA2Za0qQ==", "JeffBezos", null, new DateTime(2023, 7, 25, 16, 17, 21, 213, DateTimeKind.Local).AddTicks(9886) },
                    { 3, "warren@berkshire.com", false, false, false, "n7p8JbjMz1idjRo1BwE2ldlT4rHSxVxGhwQKMT2YIgg=", "9876543210", "warren_buffett.jpg", "aYkdwwd7tFrZOsBA2Za0qQ==", "WarrenBuffett", null, new DateTime(2023, 7, 26, 16, 17, 21, 221, DateTimeKind.Local).AddTicks(121) },
                    { 4, "BillGates@gmaill.com", true, false, false, "ljrqrV6Ma5F+Z8Q4O4MhRWt9+6b8YXlaQCfFNmVFOoc=", "1234567890", "bill_gates.jpg", "aYkdwwd7tFrZOsBA2Za0qQ==", "BillGates", null, new DateTime(2023, 7, 26, 16, 17, 21, 227, DateTimeKind.Local).AddTicks(5941) },
                    { 5, "larry@oracle.com", false, false, false, "yWItNvpeF65jhQ4lIBSZug2OEw1vOLgqORfMwqAH/AE=", "9876543210", "larry_ellison.jpg", "aYkdwwd7tFrZOsBA2Za0qQ==", "LarryEllison", null, new DateTime(2023, 7, 28, 16, 17, 21, 234, DateTimeKind.Local).AddTicks(4886) },
                    { 6, "mark@facebook.com", true, false, false, "aAIBn4DcscHU4QfinnbAq76vHXEca+ruz+r7Q1+m+yA=", "1234567890", "mark_zuckerberg.jpg", "aYkdwwd7tFrZOsBA2Za0qQ==", "MarkZuckerberg", null, new DateTime(2023, 7, 29, 16, 17, 21, 241, DateTimeKind.Local).AddTicks(5365) },
                    { 7, "larry@google.com", false, false, false, "UHRkaY7AmMrwMQMx8yL45Qjwrjhgsdcn2RwppcDM6Ro=", "9876543210", "larry_page.jpg", "aYkdwwd7tFrZOsBA2Za0qQ==", "LarryPage", null, new DateTime(2023, 7, 29, 16, 17, 21, 247, DateTimeKind.Local).AddTicks(9471) },
                    { 8, "sergey@google.com", false, false, false, "ogHZo0NPhyhEMdJfs1jGUGjnKf/s4awGIuuYy8025ok=", "1234567890", "sergey_brin.jpg", "aYkdwwd7tFrZOsBA2Za0qQ==", "SergeyBrin", null, new DateTime(2023, 7, 29, 16, 17, 21, 254, DateTimeKind.Local).AddTicks(7800) },
                    { 9, "amancio@zara.com", false, false, false, "D5iGczcroSmodpIen53mk2Fj/21O4MusmC6GKb01QF8=", "9876543210", "amancio_ortega.jpg", "aYkdwwd7tFrZOsBA2Za0qQ==", "AmancioOrtega", null, new DateTime(2023, 7, 30, 16, 17, 21, 261, DateTimeKind.Local).AddTicks(3001) },
                    { 10, "carlos@telmex.com", false, false, false, "cJuzqjHngfuzVhEQFZUEFKaAP+N7qHF+AjJxPdluHaI=", "1234567890", "carlos_slim_helu.jpg", "aYkdwwd7tFrZOsBA2Za0qQ==", "CarlosSlimHelu", null, new DateTime(2023, 7, 30, 16, 17, 21, 268, DateTimeKind.Local).AddTicks(5986) },
                    { 11, "Ad@min.com", true, false, false, "mGCUINPf0hSqMTwCdcnxoQWdGEhsJrYOpjpvQarWLFo=", "1234567890", "Admin.jpg", "aYkdwwd7tFrZOsBA2Za0qQ==", "Admin", null, new DateTime(2023, 7, 30, 16, 17, 21, 275, DateTimeKind.Local).AddTicks(973) },
                    { 12, "User@user.com", false, false, false, "mGCUINPf0hSqMTwCdcnxoQWdGEhsJrYOpjpvQarWLFo=", "1234567890", "User.jpg", "aYkdwwd7tFrZOsBA2Za0qQ==", "User", null, new DateTime(2023, 7, 30, 16, 17, 21, 281, DateTimeKind.Local).AddTicks(5123) }
                });

            migrationBuilder.InsertData(
                table: "Cards",
                columns: new[] { "Id", "CardHolder", "CheckNumber", "ExpirationDate", "HasExpired", "IsCreditCard", "IsInactive", "Number", "UserId" },
                values: new object[,]
                {
                    { 1, "Elon Musk", "649", new DateTime(2025, 10, 31, 16, 17, 21, 288, DateTimeKind.Local).AddTicks(7769), false, true, false, "8676880603590752", 1 },
                    { 2, "Jeff Bezos", "223", new DateTime(2024, 9, 30, 16, 17, 21, 288, DateTimeKind.Local).AddTicks(7805), false, true, false, "3997331179433371", 2 },
                    { 3, "Warren Buffett", "684", new DateTime(2027, 4, 30, 16, 17, 21, 288, DateTimeKind.Local).AddTicks(7808), false, true, false, "7469810858990903", 3 },
                    { 4, "Bill Gates", "623", new DateTime(2028, 1, 31, 16, 17, 21, 288, DateTimeKind.Local).AddTicks(7811), false, false, false, "7372340136556716", 4 },
                    { 5, "Larry Ellison", "636", new DateTime(2026, 11, 30, 16, 17, 21, 288, DateTimeKind.Local).AddTicks(7813), false, false, false, "4503408821426590", 5 },
                    { 6, "Mark Zuckerberg", "973", new DateTime(2025, 6, 30, 16, 17, 21, 288, DateTimeKind.Local).AddTicks(7816), false, true, false, "9539114984387891", 6 },
                    { 7, "Larry Page", "247", new DateTime(2025, 9, 30, 16, 17, 21, 288, DateTimeKind.Local).AddTicks(7818), false, false, false, "3820743154136639", 7 },
                    { 8, "Sergey Brin", "367", new DateTime(2024, 12, 31, 16, 17, 21, 288, DateTimeKind.Local).AddTicks(7821), false, false, false, "1513410988134823", 8 },
                    { 9, "Amancio Ortega", "256", new DateTime(2027, 8, 31, 16, 17, 21, 288, DateTimeKind.Local).AddTicks(7824), false, false, false, "4588654764785024", 9 },
                    { 10, "Carlos Slim Helu", "208", new DateTime(2026, 5, 31, 16, 17, 21, 288, DateTimeKind.Local).AddTicks(7826), false, false, false, "3525471461987263", 10 },
                    { 11, "Admin", "543", new DateTime(2026, 10, 31, 16, 17, 21, 288, DateTimeKind.Local).AddTicks(7829), false, true, false, "3187868110023152", 11 },
                    { 12, "Elon Musk", "660", new DateTime(2026, 2, 28, 16, 17, 21, 288, DateTimeKind.Local).AddTicks(7831), false, false, false, "3896973357363677", 1 },
                    { 13, "Warren Buffett", "696", new DateTime(2027, 1, 31, 16, 17, 21, 288, DateTimeKind.Local).AddTicks(7833), false, true, false, "5672253593826517", 3 },
                    { 14, "Bill Gates", "994", new DateTime(2027, 12, 31, 16, 17, 21, 288, DateTimeKind.Local).AddTicks(7835), false, true, false, "8832823205243008", 4 },
                    { 15, "Amancio Ortega", "645", new DateTime(2025, 4, 30, 16, 17, 21, 288, DateTimeKind.Local).AddTicks(7838), false, true, false, "5243292944936184", 9 }
                });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "Id", "Amount", "AmountReceived", "CardNumber", "CurrencyExchangeRate", "Date", "IsInbound", "RecipientId", "SenderId", "TransactionType" },
                values: new object[,]
                {
                    { 1, 111m, null, null, null, new DateTime(2023, 7, 21, 16, 17, 21, 288, DateTimeKind.Local).AddTicks(7915), false, 10, 1, 0 },
                    { 2, 222m, null, null, null, new DateTime(2023, 7, 22, 16, 17, 21, 288, DateTimeKind.Local).AddTicks(7922), false, 9, 2, 0 },
                    { 3, 333m, null, null, null, new DateTime(2023, 7, 23, 16, 17, 21, 288, DateTimeKind.Local).AddTicks(7924), false, 8, 3, 0 },
                    { 4, 444m, null, null, null, new DateTime(2023, 7, 24, 16, 17, 21, 288, DateTimeKind.Local).AddTicks(7927), false, 7, 4, 0 },
                    { 5, 555m, null, null, null, new DateTime(2023, 7, 25, 16, 17, 21, 288, DateTimeKind.Local).AddTicks(7929), false, 6, 5, 0 },
                    { 6, 666m, null, null, null, new DateTime(2023, 7, 26, 16, 17, 21, 288, DateTimeKind.Local).AddTicks(7932), false, 11, 1, 0 }
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
                    { 12, 0.00m, 0m, 1, false, 11 },
                    { 13, 0.00m, 0m, 1, false, 11 }
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
                column: "UserId");
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
