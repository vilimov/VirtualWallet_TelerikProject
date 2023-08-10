using Virtual_Wallet.Models.ViewModels;

namespace Virtual_Wallet.Models.ViewModels
{
	public class PaginatedTransactionViewModel
	{
		public List<TransactionViewModel> TansactionsShow { get; set; } = new List<TransactionViewModel>();
		public int Pages { get; set; }
		public int CurrentPages { get; set; }
        public string Search { get; set; }
        public bool ShowPrevious => CurrentPages > 1;
        public bool ShowNext => CurrentPages < Pages;
    }
}

