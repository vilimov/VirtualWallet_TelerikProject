using System.ComponentModel.DataAnnotations;
using Virtual_Wallet.VirtualWallet.Domain.Enums;

namespace Virtual_Wallet.Models.ViewModels
{
	public class CardUpdateViewModel
	{
		[MinLength(3, ErrorMessage = "The {0} field must be at least {1} characters.")]
		[MaxLength(16, ErrorMessage = "The {0} field must be less than {1} characters.")]
		public string? Name { get; set; }

		[RegularExpression(@"(0[1-9]|1[0-2])[0-9][0-9]", ErrorMessage = "Incorrect date format!")]
		public string? ExpireDateFormatted { get; set; }

		[StringLength(30, MinimumLength = 2)]
		public string? CardHolder { get; set; }

		[StringLength(3, MinimumLength = 3)]
		[RegularExpression(@"\d*", ErrorMessage = "Incorrect check number format!")]
		public string? CheckNumber { get; set; }

		public Currency? CurrencyCode { get; set; }

		public bool? IsCreditCard { get; set; }
	}
}
