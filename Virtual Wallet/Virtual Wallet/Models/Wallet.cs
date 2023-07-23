﻿namespace Virtual_Wallet.Models
{
    public class Wallet
    {
        public int Id { get; set; }

        [Required]
        public Currency CurrencyCode { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        public decimal Balance { get; set; }

        [Range(0, double.MaxValue)]
        public decimal Blocked { get; set; }

        [Required]
        public int? UserId { get; set; }

        [Required]
        public User User { get; set; }
    }
}