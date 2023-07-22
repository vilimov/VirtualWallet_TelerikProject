﻿
using AutoMapper.Execution;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System;
using Virtual_Wallet.Models;

namespace Virtual_Wallet.Data
{
    public class WalletContext : DbContext
    {
        public WalletContext(DbContextOptions<WalletContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Card> Cards { get; set; }
        public DbSet<Wallet> Wallets { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        //public DbSet<Address> Addresses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //var salt = AuthManager.GenerateSalt();
            var users = new List<User>()
            {
                new User { Id = 1, Username = "ElonMusk", Password = "password123", ConfirmPassword = "password123", Email = "elon@musk.com", PhoneNumber = "1234567890", Photo = "elon_musk.jpg", IsAdmin = true, IsBlocked = false},
                new User { Id = 2, Username = "JeffBezos", Password = "password456", ConfirmPassword = "password456", Email = "jeff@amazon.com", PhoneNumber = "9876543210", Photo = "jeff_bezos.jpg", IsAdmin = false, IsBlocked = false},
                new User { Id = 3, Username = "WarrenBuffett", Password = "password789", ConfirmPassword = "password789", Email = "warren@berkshire.com", PhoneNumber = "9876543210", Photo = "warren_buffett.jpg", IsAdmin = false, IsBlocked = false},
                new User { Id = 4, Username = "BillGates", Password = "password111", ConfirmPassword = "password111", Email = "bill@microsoft.com", PhoneNumber = "1234567890", Photo = "bill_gates.jpg", IsAdmin = true, IsBlocked = false},
                new User { Id = 5, Username = "LarryEllison", Password = "password222", ConfirmPassword = "password222", Email = "larry@oracle.com", PhoneNumber = "9876543210", Photo = "larry_ellison.jpg", IsAdmin = false, IsBlocked = false},
                new User { Id = 6, Username = "MarkZuckerberg", Password = "password333", ConfirmPassword = "password333", Email = "mark@facebook.com", PhoneNumber = "1234567890", Photo = "mark_zuckerberg.jpg", IsAdmin = true, IsBlocked = false},
                new User { Id = 7, Username = "LarryPage", Password = "password444", ConfirmPassword = "password444", Email = "larry@google.com", PhoneNumber = "9876543210", Photo = "larry_page.jpg", IsAdmin = false, IsBlocked = false},
                new User { Id = 8, Username = "SergeyBrin", Password = "password555", ConfirmPassword = "password555", Email = "sergey@google.com", PhoneNumber = "1234567890", Photo = "sergey_brin.jpg", IsAdmin = false, IsBlocked = false},
                new User { Id = 9, Username = "AmancioOrtega", Password = "password666", ConfirmPassword = "password666", Email = "amancio@zara.com", PhoneNumber = "9876543210", Photo = "amancio_ortega.jpg", IsAdmin = false, IsBlocked = false},
                new User { Id = 10, Username = "CarlosSlimHelu", Password = "password777", ConfirmPassword = "password777", Email = "carlos@telmex.com", PhoneNumber = "1234567890", Photo = "carlos_slim_helu.jpg", IsAdmin = false, IsBlocked = false},
                new User { Id = 11, Username = "Admin", Password = "123", ConfirmPassword = "123", Email = "Ad@min.com", PhoneNumber = "1234567890", Photo = "Admin.jpg", IsAdmin = true, IsBlocked = false}
            };
            modelBuilder.Entity<User>().HasData(users);

            var cards = new List<Card>()
            {
                new Card { Id = 1, Number = "8676880603590752", ExpirationDate = DateTime.Now.AddYears(2).AddMonths(3), CardHolder = "Elon Musk", CheckNumber = "649", IsCreditCard = true, UserId = 1},
                new Card { Id = 2, Number = "3997331179433371", ExpirationDate = DateTime.Now.AddYears(1).AddMonths(2), CardHolder = "Jeff Bezos", CheckNumber = "223", IsCreditCard = true, UserId = 2},
                new Card {Id = 3, Number = "7469810858990903", ExpirationDate = DateTime.Now.AddYears(3).AddMonths(9), CardHolder = "Warren Buffett", CheckNumber = "684", IsCreditCard = true, UserId = 3},
                new Card { Id = 4, Number = "7372340136556716", ExpirationDate = DateTime.Now.AddYears(4).AddMonths(6), CardHolder = "Bill Gates", CheckNumber = "623", IsCreditCard = false, UserId = 4 },
                new Card { Id = 5, Number = "4503408821426590", ExpirationDate = DateTime.Now.AddYears(3).AddMonths(4), CardHolder = "Larry Ellison", CheckNumber = "636", IsCreditCard = false, UserId = 5 },
                new Card { Id = 6, Number = "9539114984387891", ExpirationDate = DateTime.Now.AddYears(1).AddMonths(11), CardHolder = "Mark Zuckerberg", CheckNumber = "973", IsCreditCard = true, UserId = 6 },
                new Card { Id = 7, Number = "3820743154136639", ExpirationDate = DateTime.Now.AddYears(2).AddMonths(2), CardHolder = "Larry Page", CheckNumber = "247", IsCreditCard = false, UserId = 7 },
                new Card { Id = 8, Number = "1513410988134823", ExpirationDate = DateTime.Now.AddYears(1).AddMonths(5), CardHolder = "Sergey Brin", CheckNumber = "367", IsCreditCard = false, UserId = 8 },
                new Card { Id = 9, Number = "4588654764785024", ExpirationDate = DateTime.Now.AddYears(4).AddMonths(1), CardHolder = "Amancio Ortega", CheckNumber = "256", IsCreditCard = false, UserId = 9 },
                new Card { Id = 10, Number = "3525471461987263", ExpirationDate = DateTime.Now.AddYears(2).AddMonths(10), CardHolder = "Carlos Slim Helu", CheckNumber = "208", IsCreditCard = false, UserId = 10 },
                new Card { Id = 11, Number = "3187868110023152", ExpirationDate = DateTime.Now.AddYears(3).AddMonths(3), CardHolder = "Admin", CheckNumber = "543", IsCreditCard = true, UserId = 11 },
                new Card { Id = 12, Number = "3896973357363677", ExpirationDate = DateTime.Now.AddYears(2).AddMonths(7), CardHolder = "Elon Musk", CheckNumber = "660", IsCreditCard = false, UserId = 1 },
                new Card { Id = 13, Number = "5672253593826517", ExpirationDate = DateTime.Now.AddYears(3).AddMonths(6), CardHolder = "Warren Buffett", CheckNumber = "696", IsCreditCard = true, UserId = 3 },
                new Card { Id = 14, Number = "8832823205243008", ExpirationDate = DateTime.Now.AddYears(4).AddMonths(5), CardHolder = "Bill Gates", CheckNumber = "994", IsCreditCard = true, UserId = 4 },
                new Card { Id = 15, Number = "5243292944936184", ExpirationDate = DateTime.Now.AddYears(1).AddMonths(9), CardHolder = "Amancio Ortega", CheckNumber = "645", IsCreditCard = true, UserId = 9 }
            };
            modelBuilder.Entity<Card>().HasData(cards);

            var wallets = new List<Wallet>()
            {
                new Wallet { Id = 1, Currency = Models.Enum.Currency.USD, Balance = 10000, UserId = 1 },
                new Wallet { Id = 2, Currency = Models.Enum.Currency.USD, Balance = 10000, UserId = 2 },
                new Wallet { Id = 3, Currency = Models.Enum.Currency.USD, Balance = 10000, UserId = 3 },
                new Wallet { Id = 4, Currency = Models.Enum.Currency.USD, Balance = 10000, UserId = 4 },
                new Wallet { Id = 5, Currency = Models.Enum.Currency.BGN, Balance = 10000, UserId = 5 },
                new Wallet { Id = 6, Currency = Models.Enum.Currency.BGN, Balance = 10000, UserId = 6 },
                new Wallet { Id = 7, Currency = Models.Enum.Currency.BGN, Balance = 10000, UserId = 7 },
                new Wallet { Id = 8, Currency = Models.Enum.Currency.EUR, Balance = 10000, UserId = 8 },
                new Wallet { Id = 9, Currency = Models.Enum.Currency.EUR, Balance = 10000, UserId = 9 },
                new Wallet { Id = 10, Currency = Models.Enum.Currency.EUR, Balance = 10000, UserId = 10 },
                new Wallet { Id = 11, Currency = Models.Enum.Currency.BGN, Balance = 10000, UserId = 11 }
            };
            modelBuilder.Entity<Wallet>().HasData(wallets);

            var transactions = new List<Transaction>()
            {
                new Transaction { Id = 1, Date = DateTime.Now.AddDays(-10), Amount = 100, SenderId = 1, RecipientId = 10},
                new Transaction { Id = 2, Date = DateTime.Now.AddDays(-9), Amount = 200, SenderId = 2, RecipientId = 9},
                new Transaction { Id = 3, Date = DateTime.Now.AddDays(-8), Amount = 300, SenderId = 3, RecipientId = 8},
                new Transaction { Id = 4, Date = DateTime.Now.AddDays(-7), Amount = 400, SenderId = 4, RecipientId = 7},
                new Transaction { Id = 5, Date = DateTime.Now.AddDays(-6), Amount = 500, SenderId = 5, RecipientId = 6},
                new Transaction { Id = 6, Date = DateTime.Now.AddDays(-5), Amount = 1000, SenderId = 1, RecipientId = 11},
            };
            modelBuilder.Entity<Transaction>().HasData(transactions);


            modelBuilder.Entity<Transaction>()
                .HasOne(t => t.Sender)
                .WithMany(u => u.SentTransactions)
                .HasForeignKey(t => t.SenderId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Transaction>()
                .HasOne(t => t.Recipient)
                .WithMany(u => u.ReceivedTransactions)
                .HasForeignKey(t => t.RecipientId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Transaction>()
                .Property(t => t.Amount)
                .HasPrecision(20, 5);

            modelBuilder.Entity<Wallet>()
                .Property(w => w.Balance)
                .HasPrecision(20, 5);

            modelBuilder.Entity<Wallet>()
                .Property(w => w.Blocked)
                .HasPrecision(20, 5);
        }
    }
}
