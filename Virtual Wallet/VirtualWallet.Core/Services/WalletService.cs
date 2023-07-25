using Virtual_Wallet.VirtualWallet.Domain.Entities;
using Virtual_Wallet.VirtualWallet.Domain.Enums;
using Virtual_Wallet.VirtualWallet.Persistence.Repository.Contracts;
using VirtualWallet.Application.Services.Contracts;

namespace Virtual_Wallet.VirtualWallet.Application.Services
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
            Wallet newWallet = new Wallet();
            newWallet.User = user;
            walletRepository.CreateWallet(newWallet);
            return newWallet;
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

        public decimal AddToWallet(int id, decimal amount)
        {
            return walletRepository.AddToWallet(id, amount);
        }

        public decimal WithdrawFromWallet(int id, decimal amount)
        {
            return walletRepository.WithdrawFromWallet(id, amount);
        }

        public decimal Block(int id, decimal amount)
        {
            return walletRepository.Block(id, amount);
        }

        public decimal ReleaseBlocked(int id, decimal amount)
        {
            return walletRepository.ReleaseBlocked(id, amount);
        }

        public decimal Unblock(int id, decimal amount)
        {
            return walletRepository.Unblock(id, amount);
        }

        public Wallet Delete(int id)
        {
            Wallet deletedWallet = walletRepository.Delete(id);
            return deletedWallet;
        }
    }
}
