using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using Virtual_Wallet.VirtualWallet.Domain.Entities;

namespace Virtual_Wallet.Models.ViewModels
{
	public class MakeCardTransactionViewModel
	{
		public SelectList Cards { get; set; }

		[Required(ErrorMessage = "The {0} field is required")]
		public int CardId { get; set; }

		[Required(ErrorMessage = "The {0} field is required")]
		[DataType(DataType.Currency)]
		public decimal Amount { get; set; }

		[Required(AllowEmptyStrings = false, ErrorMessage = "The {0} field is required and must not be an empty string.")]
		[MaxLength(150, ErrorMessage = "The {0} field must be less than {1} characters.")]
		[MinLength(4, ErrorMessage = "The {0} field must be at least {1} character.")]
		public string Description { get; set; }
	}
}
