namespace Virtual_Wallet.Models.ViewModels
{
	public class PaginatedWalletsViewModel
	{
		public int PageNumber { get; set; }
		public int TotalPages { get; set; }
		public int PageSize { get; set; }

		public List<WalletViewModel> WalletsShow { get; set; }
		public string Search { get; set; }
		public bool ShowPrevious => PageNumber > 1;
		public bool ShowNext => PageNumber < TotalPages;
	}
}
