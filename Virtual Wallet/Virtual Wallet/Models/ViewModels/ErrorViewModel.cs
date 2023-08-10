namespace Virtual_Wallet.VirtualWallet.API.Models.ViewModels
{
	public class ErrorViewModel
	{
		public string? RequestId { get; set; }

		public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
	}
}