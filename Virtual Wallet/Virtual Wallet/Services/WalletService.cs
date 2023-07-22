using Virtual_Wallet.Models;
using Virtual_Wallet.Models.Enum;
using Virtual_Wallet.Services.Contracts;

namespace Virtual_Wallet.Services
{
    public class WalletService : IWalletService
    {
        public Wallet CreateWallet(Wallet wallet, User user)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Wallet> GetAll()
        {
            throw new NotImplementedException();
        }

        public decimal GetBalance(Wallet wallet)
        {
            throw new NotImplementedException();
        }

        public Currency GetCurrencyById(int id)
        {
            throw new NotImplementedException();
        }

        public Wallet GetWalletById(int id)
        {
            throw new NotImplementedException();
        }

        public Wallet GetWalletByUser(string username)
        {
            throw new NotImplementedException();
        }
    }
}
