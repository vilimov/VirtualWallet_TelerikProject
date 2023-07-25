using System.ComponentModel.DataAnnotations;

namespace Virtual_Wallet.VirtualWallet.API.Models.Dtos
{
	public class UserLoginDto
	{
		[Required(AllowEmptyStrings = false, ErrorMessage = "The {0} field is required and must not be empty.")]
		[MinLength(2), MaxLength(20)]
		public string Username { get; set; }

		[Required(AllowEmptyStrings = false, ErrorMessage = "The {0} field is required and must not be empty.")]
		[MinLength(8), MaxLength(20)]
		public string Password { get; set; }
	}
}
