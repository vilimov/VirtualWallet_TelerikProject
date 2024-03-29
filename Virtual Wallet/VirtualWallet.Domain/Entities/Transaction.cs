﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using VirtualWallet.Domain.Enums;
using Virtual_Wallet.VirtualWallet.Domain.Enums;

namespace Virtual_Wallet.VirtualWallet.Domain.Entities
{
	public class Transaction
	{
		public int Id { get; set; }

		[Required]
		public DateTime Date { get; set; }

		[Required]
		[DataType(DataType.Currency)]
		public decimal Amount { get; set; }

        [Required]
        public TransactionType TransactionType { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
		public User Sender { get; set; }

		[Required]
		public int? SenderId { get; set; }

		[Required]
		public User Recipient { get; set; }

		[Required]
		public int? RecipientId { get; set; }

		public bool IsInbound { get; set; }
		public string? CardNumber { get; set; }

        [DataType(DataType.Currency)]
        public decimal? AmountReceived { get; set; }
        public double? CurrencyExchangeRate { get; set; }

        public Currency? SenderWalletCurrency { get; set; }
        public Currency? RecipientWalletCurrency { get; set; }
    }

}
