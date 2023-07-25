using Virtual_Wallet.VirtualWallet.Domain.Entities;
using Virtual_Wallet.VirtualWallet.Domain.Enums;

namespace Virtual_Wallet.VirtualWallet.Persistence.Repository.Contracts
{
    public interface IWalletRepository
    {
        Wallet CreateWallet(Wallet wallet);
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
        Wallet Delete(int id);
    
        decimal AdjustBalance(int walletId, decimal amount, bool isDeposit);

	}
}
