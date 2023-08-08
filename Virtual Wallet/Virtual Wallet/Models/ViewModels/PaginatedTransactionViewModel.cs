namespace Virtual_Wallet.Models.ViewModels
{
	public class PaginatedTransactionViewModel
	{
		public int PageNumber { get; set; }  // Current page number
		public int TotalPages { get; set; }  // Total number of pages
		public int PageSize { get; set; }    // Number of items per page

		public List<TransactionViewModel> TansactionsShow { get; set; }  // List of transactions
		public string Search { get; set; }
		public bool ShowPrevious => PageNumber > 1;
		public bool ShowNext => PageNumber < TotalPages;
	}
}
