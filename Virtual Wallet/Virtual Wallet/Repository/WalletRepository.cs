using Virtual_Wallet.Data;
using Virtual_Wallet.Models;
using Virtual_Wallet.Models.Enum;
using Virtual_Wallet.Repository.Contracts;

namespace Virtual_Wallet.Repository
{
    public class WalletRepository : IWalletRepository
    {
        private readonly WalletContext _context;
        public Wallet CreateWallet(Wallet wallet)
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
