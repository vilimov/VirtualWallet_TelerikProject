﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Virtual_Wallet.VirtualWallet.Persistence.Data;

#nullable disable

namespace VirtualWallet.Persistence.Migrations
{
    [DbContext(typeof(WalletContext))]
    [Migration("20230727110213_transactionModel")]
    partial class transactionModel
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Virtual_Wallet.VirtualWallet.Domain.Entities.Card", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CardHolder")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("CheckNumber")
                        .IsRequired()
                        .HasMaxLength(3)
                        .HasColumnType("nvarchar(3)");

                    b.Property<DateTime>("ExpirationDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsCreditCard")
                        .HasColumnType("bit");

                    b.Property<bool>("IsInactive")
                        .HasColumnType("bit");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasMaxLength(16)
                        .HasColumnType("nvarchar(16)");

                    b.Property<int?>("UserId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Cards");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CardHolder = "Elon Musk",
                            CheckNumber = "649",
                            ExpirationDate = new DateTime(2025, 10, 27, 14, 2, 13, 233, DateTimeKind.Local).AddTicks(312),
                            IsCreditCard = true,
                            IsInactive = false,
                            Number = "8676880603590752",
                            UserId = 1
                        },
                        new
                        {
                            Id = 2,
                            CardHolder = "Jeff Bezos",
                            CheckNumber = "223",
                            ExpirationDate = new DateTime(2024, 9, 27, 14, 2, 13, 233, DateTimeKind.Local).AddTicks(325),
                            IsCreditCard = true,
                            IsInactive = false,
                            Number = "3997331179433371",
                            UserId = 2
                        },
                        new
                        {
                            Id = 3,
                            CardHolder = "Warren Buffett",
                            CheckNumber = "684",
                            ExpirationDate = new DateTime(2027, 4, 27, 14, 2, 13, 233, DateTimeKind.Local).AddTicks(328),
                            IsCreditCard = true,
                            IsInactive = false,
                            Number = "7469810858990903",
                            UserId = 3
                        },
                        new
                        {
                            Id = 4,
                            CardHolder = "Bill Gates",
                            CheckNumber = "623",
                            ExpirationDate = new DateTime(2028, 1, 27, 14, 2, 13, 233, DateTimeKind.Local).AddTicks(331),
                            IsCreditCard = false,
                            IsInactive = false,
                            Number = "7372340136556716",
                            UserId = 4
                        },
                        new
                        {
                            Id = 5,
                            CardHolder = "Larry Ellison",
                            CheckNumber = "636",
                            ExpirationDate = new DateTime(2026, 11, 27, 14, 2, 13, 233, DateTimeKind.Local).AddTicks(334),
                            IsCreditCard = false,
                            IsInactive = false,
                            Number = "4503408821426590",
                            UserId = 5
                        },
                        new
                        {
                            Id = 6,
                            CardHolder = "Mark Zuckerberg",
                            CheckNumber = "973",
                            ExpirationDate = new DateTime(2025, 6, 27, 14, 2, 13, 233, DateTimeKind.Local).AddTicks(337),
                            IsCreditCard = true,
                            IsInactive = false,
                            Number = "9539114984387891",
                            UserId = 6
                        },
                        new
                        {
                            Id = 7,
                            CardHolder = "Larry Page",
                            CheckNumber = "247",
                            ExpirationDate = new DateTime(2025, 9, 27, 14, 2, 13, 233, DateTimeKind.Local).AddTicks(339),
                            IsCreditCard = false,
                            IsInactive = false,
                            Number = "3820743154136639",
                            UserId = 7
                        },
                        new
                        {
                            Id = 8,
                            CardHolder = "Sergey Brin",
                            CheckNumber = "367",
                            ExpirationDate = new DateTime(2024, 12, 27, 14, 2, 13, 233, DateTimeKind.Local).AddTicks(341),
                            IsCreditCard = false,
                            IsInactive = false,
                            Number = "1513410988134823",
                            UserId = 8
                        },
                        new
                        {
                            Id = 9,
                            CardHolder = "Amancio Ortega",
                            CheckNumber = "256",
                            ExpirationDate = new DateTime(2027, 8, 27, 14, 2, 13, 233, DateTimeKind.Local).AddTicks(344),
                            IsCreditCard = false,
                            IsInactive = false,
                            Number = "4588654764785024",
                            UserId = 9
                        },
                        new
                        {
                            Id = 10,
                            CardHolder = "Carlos Slim Helu",
                            CheckNumber = "208",
                            ExpirationDate = new DateTime(2026, 5, 27, 14, 2, 13, 233, DateTimeKind.Local).AddTicks(347),
                            IsCreditCard = false,
                            IsInactive = false,
                            Number = "3525471461987263",
                            UserId = 10
                        },
                        new
                        {
                            Id = 11,
                            CardHolder = "Admin",
                            CheckNumber = "543",
                            ExpirationDate = new DateTime(2026, 10, 27, 14, 2, 13, 233, DateTimeKind.Local).AddTicks(349),
                            IsCreditCard = true,
                            IsInactive = false,
                            Number = "3187868110023152",
                            UserId = 11
                        },
                        new
                        {
                            Id = 12,
                            CardHolder = "Elon Musk",
                            CheckNumber = "660",
                            ExpirationDate = new DateTime(2026, 2, 27, 14, 2, 13, 233, DateTimeKind.Local).AddTicks(352),
                            IsCreditCard = false,
                            IsInactive = false,
                            Number = "3896973357363677",
                            UserId = 1
                        },
                        new
                        {
                            Id = 13,
                            CardHolder = "Warren Buffett",
                            CheckNumber = "696",
                            ExpirationDate = new DateTime(2027, 1, 27, 14, 2, 13, 233, DateTimeKind.Local).AddTicks(354),
                            IsCreditCard = true,
                            IsInactive = false,
                            Number = "5672253593826517",
                            UserId = 3
                        },
                        new
                        {
                            Id = 14,
                            CardHolder = "Bill Gates",
                            CheckNumber = "994",
                            ExpirationDate = new DateTime(2027, 12, 27, 14, 2, 13, 233, DateTimeKind.Local).AddTicks(356),
                            IsCreditCard = true,
                            IsInactive = false,
                            Number = "8832823205243008",
                            UserId = 4
                        },
                        new
                        {
                            Id = 15,
                            CardHolder = "Amancio Ortega",
                            CheckNumber = "645",
                            ExpirationDate = new DateTime(2025, 4, 27, 14, 2, 13, 233, DateTimeKind.Local).AddTicks(358),
                            IsCreditCard = true,
                            IsInactive = false,
                            Number = "5243292944936184",
                            UserId = 9
                        });
                });

            modelBuilder.Entity("Virtual_Wallet.VirtualWallet.Domain.Entities.Transaction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("Amount")
                        .HasPrecision(20, 5)
                        .HasColumnType("decimal(20,5)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsInbound")
                        .HasColumnType("bit");

                    b.Property<int?>("RecipientId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<int?>("SenderId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<int>("TransactionType")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RecipientId");

                    b.HasIndex("SenderId");

                    b.ToTable("Transactions");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Amount = 111m,
                            Date = new DateTime(2023, 7, 17, 14, 2, 13, 233, DateTimeKind.Local).AddTicks(440),
                            IsInbound = false,
                            RecipientId = 10,
                            SenderId = 1,
                            TransactionType = 0
                        },
                        new
                        {
                            Id = 2,
                            Amount = 222m,
                            Date = new DateTime(2023, 7, 18, 14, 2, 13, 233, DateTimeKind.Local).AddTicks(445),
                            IsInbound = false,
                            RecipientId = 9,
                            SenderId = 2,
                            TransactionType = 0
                        },
                        new
                        {
                            Id = 3,
                            Amount = 333m,
                            Date = new DateTime(2023, 7, 19, 14, 2, 13, 233, DateTimeKind.Local).AddTicks(447),
                            IsInbound = false,
                            RecipientId = 8,
                            SenderId = 3,
                            TransactionType = 0
                        },
                        new
                        {
                            Id = 4,
                            Amount = 444m,
                            Date = new DateTime(2023, 7, 20, 14, 2, 13, 233, DateTimeKind.Local).AddTicks(450),
                            IsInbound = false,
                            RecipientId = 7,
                            SenderId = 4,
                            TransactionType = 0
                        },
                        new
                        {
                            Id = 5,
                            Amount = 555m,
                            Date = new DateTime(2023, 7, 21, 14, 2, 13, 233, DateTimeKind.Local).AddTicks(452),
                            IsInbound = false,
                            RecipientId = 6,
                            SenderId = 5,
                            TransactionType = 0
                        },
                        new
                        {
                            Id = 6,
                            Amount = 666m,
                            Date = new DateTime(2023, 7, 22, 14, 2, 13, 233, DateTimeKind.Local).AddTicks(454),
                            IsInbound = false,
                            RecipientId = 11,
                            SenderId = 1,
                            TransactionType = 0
                        });
                });

            modelBuilder.Entity("Virtual_Wallet.VirtualWallet.Domain.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("bit");

                    b.Property<bool>("IsBlocked")
                        .HasColumnType("bit");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(170)
                        .HasColumnType("nvarchar(170)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Photo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Salt")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("VerificationToken")
                        .HasMaxLength(170)
                        .HasColumnType("nvarchar(170)");

                    b.Property<DateTime?>("VerifiedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "elon@musk.com",
                            IsAdmin = true,
                            IsBlocked = false,
                            Password = "z3cYHVk1R4my8gZeon0xrHmfDE8Vpxd5j7QTpIvc3GM=",
                            PhoneNumber = "1234567890",
                            Photo = "elon_musk.jpg",
                            Salt = "aYkdwwd7tFrZOsBA2Za0qQ==",
                            Username = "ElonMusk",
                            VerifiedAt = new DateTime(2023, 7, 21, 14, 2, 13, 159, DateTimeKind.Local).AddTicks(3704)
                        },
                        new
                        {
                            Id = 2,
                            Email = "jeff@amazon.com",
                            IsAdmin = false,
                            IsBlocked = false,
                            Password = "p3zsqKJ0kKcdPlp9wSUJtBAP7H9EZ1D1C9miQv32JkU=",
                            PhoneNumber = "9876543210",
                            Photo = "jeff_bezos.jpg",
                            Salt = "aYkdwwd7tFrZOsBA2Za0qQ==",
                            Username = "JeffBezos",
                            VerifiedAt = new DateTime(2023, 7, 21, 14, 2, 13, 165, DateTimeKind.Local).AddTicks(8586)
                        },
                        new
                        {
                            Id = 3,
                            Email = "warren@berkshire.com",
                            IsAdmin = false,
                            IsBlocked = false,
                            Password = "n7p8JbjMz1idjRo1BwE2ldlT4rHSxVxGhwQKMT2YIgg=",
                            PhoneNumber = "9876543210",
                            Photo = "warren_buffett.jpg",
                            Salt = "aYkdwwd7tFrZOsBA2Za0qQ==",
                            Username = "WarrenBuffett",
                            VerifiedAt = new DateTime(2023, 7, 22, 14, 2, 13, 172, DateTimeKind.Local).AddTicks(6032)
                        },
                        new
                        {
                            Id = 4,
                            Email = "BillGates@gmaill.com",
                            IsAdmin = true,
                            IsBlocked = false,
                            Password = "ljrqrV6Ma5F+Z8Q4O4MhRWt9+6b8YXlaQCfFNmVFOoc=",
                            PhoneNumber = "1234567890",
                            Photo = "bill_gates.jpg",
                            Salt = "aYkdwwd7tFrZOsBA2Za0qQ==",
                            Username = "BillGates",
                            VerifiedAt = new DateTime(2023, 7, 22, 14, 2, 13, 179, DateTimeKind.Local).AddTicks(7596)
                        },
                        new
                        {
                            Id = 5,
                            Email = "larry@oracle.com",
                            IsAdmin = false,
                            IsBlocked = false,
                            Password = "yWItNvpeF65jhQ4lIBSZug2OEw1vOLgqORfMwqAH/AE=",
                            PhoneNumber = "9876543210",
                            Photo = "larry_ellison.jpg",
                            Salt = "aYkdwwd7tFrZOsBA2Za0qQ==",
                            Username = "LarryEllison",
                            VerifiedAt = new DateTime(2023, 7, 24, 14, 2, 13, 186, DateTimeKind.Local).AddTicks(5614)
                        },
                        new
                        {
                            Id = 6,
                            Email = "mark@facebook.com",
                            IsAdmin = true,
                            IsBlocked = false,
                            Password = "aAIBn4DcscHU4QfinnbAq76vHXEca+ruz+r7Q1+m+yA=",
                            PhoneNumber = "1234567890",
                            Photo = "mark_zuckerberg.jpg",
                            Salt = "aYkdwwd7tFrZOsBA2Za0qQ==",
                            Username = "MarkZuckerberg",
                            VerifiedAt = new DateTime(2023, 7, 25, 14, 2, 13, 193, DateTimeKind.Local).AddTicks(997)
                        },
                        new
                        {
                            Id = 7,
                            Email = "larry@google.com",
                            IsAdmin = false,
                            IsBlocked = false,
                            Password = "UHRkaY7AmMrwMQMx8yL45Qjwrjhgsdcn2RwppcDM6Ro=",
                            PhoneNumber = "9876543210",
                            Photo = "larry_page.jpg",
                            Salt = "aYkdwwd7tFrZOsBA2Za0qQ==",
                            Username = "LarryPage",
                            VerifiedAt = new DateTime(2023, 7, 25, 14, 2, 13, 199, DateTimeKind.Local).AddTicks(5103)
                        },
                        new
                        {
                            Id = 8,
                            Email = "sergey@google.com",
                            IsAdmin = false,
                            IsBlocked = false,
                            Password = "ogHZo0NPhyhEMdJfs1jGUGjnKf/s4awGIuuYy8025ok=",
                            PhoneNumber = "1234567890",
                            Photo = "sergey_brin.jpg",
                            Salt = "aYkdwwd7tFrZOsBA2Za0qQ==",
                            Username = "SergeyBrin",
                            VerifiedAt = new DateTime(2023, 7, 25, 14, 2, 13, 206, DateTimeKind.Local).AddTicks(317)
                        },
                        new
                        {
                            Id = 9,
                            Email = "amancio@zara.com",
                            IsAdmin = false,
                            IsBlocked = false,
                            Password = "D5iGczcroSmodpIen53mk2Fj/21O4MusmC6GKb01QF8=",
                            PhoneNumber = "9876543210",
                            Photo = "amancio_ortega.jpg",
                            Salt = "aYkdwwd7tFrZOsBA2Za0qQ==",
                            Username = "AmancioOrtega",
                            VerifiedAt = new DateTime(2023, 7, 26, 14, 2, 13, 212, DateTimeKind.Local).AddTicks(4272)
                        },
                        new
                        {
                            Id = 10,
                            Email = "carlos@telmex.com",
                            IsAdmin = false,
                            IsBlocked = false,
                            Password = "cJuzqjHngfuzVhEQFZUEFKaAP+N7qHF+AjJxPdluHaI=",
                            PhoneNumber = "1234567890",
                            Photo = "carlos_slim_helu.jpg",
                            Salt = "aYkdwwd7tFrZOsBA2Za0qQ==",
                            Username = "CarlosSlimHelu",
                            VerifiedAt = new DateTime(2023, 7, 26, 14, 2, 13, 218, DateTimeKind.Local).AddTicks(8205)
                        },
                        new
                        {
                            Id = 11,
                            Email = "Ad@min.com",
                            IsAdmin = true,
                            IsBlocked = false,
                            Password = "mGCUINPf0hSqMTwCdcnxoQWdGEhsJrYOpjpvQarWLFo=",
                            PhoneNumber = "1234567890",
                            Photo = "Admin.jpg",
                            Salt = "aYkdwwd7tFrZOsBA2Za0qQ==",
                            Username = "Admin",
                            VerifiedAt = new DateTime(2023, 7, 26, 14, 2, 13, 226, DateTimeKind.Local).AddTicks(5340)
                        });
                });

            modelBuilder.Entity("Virtual_Wallet.VirtualWallet.Domain.Entities.Wallet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("Balance")
                        .HasPrecision(20, 5)
                        .HasColumnType("decimal(20,5)");

                    b.Property<decimal>("Blocked")
                        .HasPrecision(20, 5)
                        .HasColumnType("decimal(20,5)");

                    b.Property<int>("CurrencyCode")
                        .HasColumnType("int");

                    b.Property<bool>("IsInactive")
                        .HasColumnType("bit");

                    b.Property<int?>("UserId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Wallets");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Balance = 111111.11m,
                            Blocked = 0m,
                            CurrencyCode = 3,
                            IsInactive = false,
                            UserId = 1
                        },
                        new
                        {
                            Id = 2,
                            Balance = 99999.99m,
                            Blocked = 0m,
                            CurrencyCode = 3,
                            IsInactive = false,
                            UserId = 2
                        },
                        new
                        {
                            Id = 3,
                            Balance = 88888.88m,
                            Blocked = 0m,
                            CurrencyCode = 3,
                            IsInactive = false,
                            UserId = 3
                        },
                        new
                        {
                            Id = 4,
                            Balance = 77777.77m,
                            Blocked = 0m,
                            CurrencyCode = 3,
                            IsInactive = false,
                            UserId = 4
                        },
                        new
                        {
                            Id = 5,
                            Balance = 66666.66m,
                            Blocked = 0m,
                            CurrencyCode = 1,
                            IsInactive = false,
                            UserId = 5
                        },
                        new
                        {
                            Id = 6,
                            Balance = 55555.55m,
                            Blocked = 0m,
                            CurrencyCode = 1,
                            IsInactive = false,
                            UserId = 6
                        },
                        new
                        {
                            Id = 7,
                            Balance = 44444.44m,
                            Blocked = 0m,
                            CurrencyCode = 1,
                            IsInactive = false,
                            UserId = 7
                        },
                        new
                        {
                            Id = 8,
                            Balance = 33333.33m,
                            Blocked = 0m,
                            CurrencyCode = 2,
                            IsInactive = false,
                            UserId = 8
                        },
                        new
                        {
                            Id = 9,
                            Balance = 22222.22m,
                            Blocked = 0m,
                            CurrencyCode = 2,
                            IsInactive = false,
                            UserId = 9
                        },
                        new
                        {
                            Id = 10,
                            Balance = 11111.11m,
                            Blocked = 0m,
                            CurrencyCode = 2,
                            IsInactive = false,
                            UserId = 10
                        },
                        new
                        {
                            Id = 11,
                            Balance = 9999.99m,
                            Blocked = 0m,
                            CurrencyCode = 1,
                            IsInactive = false,
                            UserId = 11
                        },
                        new
                        {
                            Id = 12,
                            Balance = 0.00m,
                            Blocked = 0m,
                            CurrencyCode = 1,
                            IsInactive = false,
                            UserId = 11
                        },
                        new
                        {
                            Id = 13,
                            Balance = 0.00m,
                            Blocked = 0m,
                            CurrencyCode = 1,
                            IsInactive = false,
                            UserId = 11
                        });
                });

            modelBuilder.Entity("Virtual_Wallet.VirtualWallet.Domain.Entities.Card", b =>
                {
                    b.HasOne("Virtual_Wallet.VirtualWallet.Domain.Entities.User", "User")
                        .WithMany("Cards")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Virtual_Wallet.VirtualWallet.Domain.Entities.Transaction", b =>
                {
                    b.HasOne("Virtual_Wallet.VirtualWallet.Domain.Entities.User", "Recipient")
                        .WithMany("ReceivedTransactions")
                        .HasForeignKey("RecipientId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Virtual_Wallet.VirtualWallet.Domain.Entities.User", "Sender")
                        .WithMany("SentTransactions")
                        .HasForeignKey("SenderId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Recipient");

                    b.Navigation("Sender");
                });

            modelBuilder.Entity("Virtual_Wallet.VirtualWallet.Domain.Entities.Wallet", b =>
                {
                    b.HasOne("Virtual_Wallet.VirtualWallet.Domain.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Virtual_Wallet.VirtualWallet.Domain.Entities.User", b =>
                {
                    b.Navigation("Cards");

                    b.Navigation("ReceivedTransactions");

                    b.Navigation("SentTransactions");
                });
#pragma warning restore 612, 618
        }
    }
}
