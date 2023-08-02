using Virtual_Wallet.VirtualWallet.Domain.Entities;
using Virtual_Wallet.VirtualWallet.Domain.Enums;
using VirtualWallet.Persistence.QueryParameters;

namespace VirtualWallet.Application.Services.Contracts
{
	public interface IWalletService
	{
		Wallet CreateWallet(Wallet wallet, User user);
		IEnumerable<Wallet> GetAll();
		IEnumerable<Wallet> GetFilteredWallets(WalletQueryParameters filter);

        Wallet GetWalletById(int id);
		Wallet GetWalletByUser(string username);
		decimal GetBalance(int id);
		Currency GetCurrencyById(int id);
		decimal AddToWallet(int id, decimal amount);
		decimal WithdrawFromWallet(int id, decimal amount);
		Wallet Update(User user, Wallet newWallet);
		Wallet Delete(int id);
	}
}
