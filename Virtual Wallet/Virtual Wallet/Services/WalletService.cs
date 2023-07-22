using Virtual_Wallet.Models;
using Virtual_Wallet.Models.Enum;
using Virtual_Wallet.Repository.Contracts;
using Virtual_Wallet.Services.Contracts;

namespace Virtual_Wallet.Services
{
    public class WalletService : IWalletService
    {
        private readonly IWalletRepository walletRepository;

        public WalletService(IWalletRepository walletRepository)
        {
            this.walletRepository = walletRepository;
        }

        public Wallet CreateWallet(Wallet wallet, User user)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Wallet> GetAll()
        {
            return walletRepository.GetAll();
        }

        public Wallet GetWalletById(int id)
        {
            return walletRepository.GetWalletById(id);
        }

        public Wallet GetWalletByUser(string username)
        {
            return walletRepository.GetWalletByUser(username);
        }

        public decimal GetBalance(int id)
        {
            return walletRepository.GetBalance(id);
        }

        public Currency GetCurrencyById(int id)
        {
            return walletRepository.GetCurrencyById(id);
        }

    }
}
