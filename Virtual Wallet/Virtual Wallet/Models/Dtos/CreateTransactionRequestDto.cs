using System.ComponentModel.DataAnnotations;

namespace Virtual_Wallet.VirtualWallet.API.Models.Dtos
{
	public class CreateTransactionRequestDto
	{
		[Required]
		public int RecipientId { get; set; }

		[Required]
		[Range(0.01, (double)decimal.MaxValue)]
		public decimal Amount { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "The {0} field is required and must not be an empty string.")]
        [MinLength(6, ErrorMessage = "The {0} field must be at least {1} characters.")]
        public string Description { get; set; }
    }
}
