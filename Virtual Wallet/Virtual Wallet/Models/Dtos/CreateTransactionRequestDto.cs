using System.ComponentModel.DataAnnotations;

namespace Virtual_Wallet.Models.Dtos
{
	public class CreateTransactionRequest
	{
		[Required]
		public int SenderId { get; set; }

		[Required]
		public int RecipientId { get; set; }

		[Required]
		[Range(0.01, (double)decimal.MaxValue)]
		public decimal Amount { get; set; }
	}
}
