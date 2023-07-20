using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Virtual_Wallet.Models
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
		public User Sender { get; set; }

		[Required]
		public int SenderId { get; set; }

		[Required]
		public User Recipient { get; set; }

		[Required]
		public int RecipientId { get; set; }

		public bool IsInbound { get; set; }
	}

}
