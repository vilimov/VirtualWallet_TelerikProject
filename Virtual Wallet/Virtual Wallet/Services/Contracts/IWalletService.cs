using Virtual_Wallet.Models;
using Virtual_Wallet.Models.Enum;

namespace Virtual_Wallet.Services.Contracts
{
    public interface IWalletService
    {
        Wallet CreateWallet(Wallet wallet, User user);
        IEnumerable<Wallet> GetAll();
        Wallet GetWalletById(int id);
        Wallet GetWalletByUser(string username);
        decimal GetBalance(int id);
        Currency GetCurrencyById(int id);
    }
}
