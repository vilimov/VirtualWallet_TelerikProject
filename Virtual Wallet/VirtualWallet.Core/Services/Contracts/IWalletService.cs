using Virtual_Wallet.VirtualWallet.Domain.Entities;
using Virtual_Wallet.VirtualWallet.Domain.Enums;

namespace VirtualWallet.Application.Services.Contracts
{
	public interface IWalletService
	{
		Wallet CreateWallet(Wallet wallet, User user);
		IEnumerable<Wallet> GetAll();
		Wallet GetWalletById(int id);
		Wallet GetWalletByUser(string username);
		decimal GetBalance(int id);
		Currency GetCurrencyById(int id);
		decimal AddToWallet(int id, decimal amount);
		decimal WithdrawFromWallet(int id, decimal amount);
		decimal Block(int id, decimal amount);
		decimal ReleaseBlocked(int id, decimal amount);
		decimal Unblock(int id, decimal amount);
		Wallet Update(User user, Currency newCurrencyCode);
		Wallet Delete(int id);
	}
}
