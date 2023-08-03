using Virtual_Wallet.VirtualWallet.Domain.Entities;

namespace Virtual_Wallet.Models.ViewModels
{
	public class MakeCardTransactionViewModel
	{
		User User { get; set; }
		Card Card { get; set; }
		decimal Amount { get; set; }
		string Description { get; set; }
	}
}
