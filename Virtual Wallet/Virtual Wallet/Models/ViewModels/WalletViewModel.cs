using Virtual_Wallet.VirtualWallet.API.Models.Dtos;
using Virtual_Wallet.VirtualWallet.Domain.Entities;
using Virtual_Wallet.VirtualWallet.Domain.Enums;

namespace Virtual_Wallet.Models.ViewModels
{
	public class WalletViewModel : WalletShowDto
	{
		public WalletViewModel(Wallet walletModel) 
		{
			Username = walletModel.User.Username;
			Ballance = walletModel.Balance.ToString("F2");
			Blocked = walletModel.Blocked.ToString("F2");
			CurrencyCode = walletModel.CurrencyCode.ToString();
			CurrencyDescription = EnumHelper.GetEnumDescription(walletModel.CurrencyCode);
		}
	}
}
