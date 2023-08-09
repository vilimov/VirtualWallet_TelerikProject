using Virtual_Wallet.VirtualWallet.API.Models.Dtos;

namespace Virtual_Wallet.Models.ViewModels
{
	public class PaginatedCardsViewModel
	{
		public int PageNumber { get; set; }  // Current page number
		public int TotalPages { get; set; }  // Total number of pages
		public int PageSize { get; set; }    // Number of items per page

		public List<CardViewModel> CardsShow { get; set; }  // List of cards
		public string Search { get; set; }
		public bool ShowPrevious => PageNumber > 1;
		public bool ShowNext => PageNumber < TotalPages;
	}
}
