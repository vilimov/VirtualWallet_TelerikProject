using Virtual_Wallet.VirtualWallet.Domain.Entities;
using Virtual_Wallet.VirtualWallet.Domain.Enums;
using VirtualWallet.Persistence.QueryParameters;

namespace Virtual_Wallet.VirtualWallet.Persistence.Repository.Contracts
{
    public interface IWalletRepository
    {
        Wallet CreateWallet(Wallet wallet, User user);
        IQueryable<Wallet> GetAll();
        IList<Wallet> GetFilteredWallets(WalletQueryParameters filter);
        Wallet GetWalletById(int id);
        Wallet GetWalletByUser(string username);
        decimal GetBalance(int id);
        Currency GetCurrencyById(int id);
        decimal AddToWallet(int id, decimal amount);
        decimal WithdrawFromWallet(int id, decimal amount);     
        Wallet Update(int id, double exchangeRate, Currency newCurrencyCode);
        Wallet Delete(int id);
    
        //decimal AdjustBalance(int walletId, decimal amount, bool isDeposit);

	}
}
