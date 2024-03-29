﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Virtual_Wallet.VirtualWallet.Domain.Enums;

namespace Virtual_Wallet.VirtualWallet.Domain.Entities
{
	public class Card
	{
		public int Id { get; set; }

		[Required]
		[MinLength(3, ErrorMessage = "The {0} field must be at least {1} characters.")]
		[MaxLength(16, ErrorMessage = "The {0} field must be less than {1} characters.")]
		public string Name { get; set; }

		[Required]
		[StringLength(16, MinimumLength = 16)]
		public string Number { get; set; }

		[Required]
		public DateTime ExpirationDate { get; set; }

		[Required]
		[StringLength(30, MinimumLength = 2)]
		public string CardHolder { get; set; }

		[Required]
		[StringLength(3, MinimumLength = 3)]
		public string CheckNumber { get; set; }

		[Required]
		public Currency CurrencyCode { get; set; }

		[Required]
		public bool IsCreditCard { get; set; }

		public bool HasExpired { get; set; }

		public bool IsInactive { get; set; }

		[Required]
		public int? UserId { get; set; }

		[Required]
		public User User { get; set; }
	}

}
