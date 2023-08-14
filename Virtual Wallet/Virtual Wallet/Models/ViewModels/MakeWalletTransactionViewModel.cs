using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using Virtual_Wallet.VirtualWallet.Domain.Entities;

namespace Virtual_Wallet.Models.ViewModels
{
	public class MakeWalletTransactionViewModel
	{
		public string RecipientUsername { get; set; }

		[Required(ErrorMessage = "The {0} field is required.")]
		[DataType(DataType.Currency, ErrorMessage = "The {0} field must be a valid currency value.")]
		[Range(0.01, double.MaxValue, ErrorMessage = "The {0} field must be greater than 0.")]
		[RegularExpression(@"^\d+(\.\d{1,2})?$", ErrorMessage = "The {0} field must have up to 2 decimal places.")]
		public decimal Amount { get; set; }

		[Required(AllowEmptyStrings = false, ErrorMessage = "The {0} field is required and must not be an empty string.")]
		[MaxLength(150, ErrorMessage = "The {0} field must be less than {1} characters.")]
		[MinLength(4, ErrorMessage = "The {0} field must be at least {1} character.")]
		public string Description { get; set; }
	}
}
