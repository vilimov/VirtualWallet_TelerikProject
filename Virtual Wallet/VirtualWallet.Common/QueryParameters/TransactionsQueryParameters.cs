using System.ComponentModel.DataAnnotations;

namespace VirtualWallet.Common.QueryParameters
{
	public class TransactionsQueryParameters
	{
		public string? AllMyTransactions { get; set; }
		public string? Sender { get; set; }
		public string? Reciever { get; set; }
		public string? Withdrawl { get; set; }
		public string? DepositToWallet { get; set; }
		public string? TransferToUser { get; set; }

		[RegularExpression(@"((0[1-9]|[1-2][0-9]|3[0-1])-(0[1-9]|1[0-2])-[0-9]{4})|((0[1-9]|1[0-2])-[0-9]{4})", ErrorMessage = "Incorrect date format!")]
		public string? FilterByDate { get; set; }
		public int PageSize { get; set; } = 5;
		public int PageCount { get; set; } = 1;

	}
}
