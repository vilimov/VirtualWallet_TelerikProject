using Virtual_Wallet.Models;
using Virtual_Wallet.Models.Enum;

namespace Virtual_Wallet.Repository.Contracts
{
    public interface IWalletRepository
    {
        Wallet CreateWallet(Wallet wallet);
        IEnumerable<Wallet> GetAll();
        Wallet GetWalletById(int id);
        Wallet GetWalletByUser(string username);
        decimal GetBalance(int id);
        Currency GetCurrencyById(int id);
    }
}
