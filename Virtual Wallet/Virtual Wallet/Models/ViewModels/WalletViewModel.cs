using System.Text.Json.Serialization;
using Virtual_Wallet.VirtualWallet.API.Models.Dtos;
using Virtual_Wallet.VirtualWallet.Domain.Entities;
using Virtual_Wallet.VirtualWallet.Domain.Enums;

namespace Virtual_Wallet.Models.ViewModels
{
	public class WalletViewModel
	{
		public WalletViewModel() { }

		public WalletViewModel(Wallet walletModel)
		{
			Id = walletModel.Id;
			Username = walletModel.User.Username;
			Ballance = walletModel.Balance.ToString("F2");
			Blocked = walletModel.Blocked.ToString("F2");
			CurrencyCode = walletModel.CurrencyCode.ToString();
			CurrencyDescription = EnumHelper.GetEnumDescription(walletModel.CurrencyCode);
		}

		public int Id { get; set; }

		public string Username { get; set; }

		public string Ballance { get; set; }

		public string Blocked { get; set; }

		public string CurrencyCode { get; set; }

		public string CurrencyDescription { get; set; }
	}
}
