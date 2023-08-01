using Virtual_Wallet.VirtualWallet.Common.QueryParameters;
using Virtual_Wallet.VirtualWallet.Domain.Entities;
using Virtual_Wallet.VirtualWallet.Domain.Enums;
using Virtual_Wallet.VirtualWallet.Persistence.Repository;
using Virtual_Wallet.VirtualWallet.Persistence.Repository.Contracts;
using VirtualWallet.Application.ExchangeRateAPI;
using VirtualWallet.Application.Services.Contracts;
using VirtualWallet.Common.AdditionalHelpers;
using VirtualWallet.Common.Exceptions;
using VirtualWallet.Persistence.QueryParameters;

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
            wallet.User = user;
            walletRepository.CreateWallet(wallet);
            return wallet;
        }

        public IEnumerable<Wallet> GetAll()
        {
            return walletRepository.GetAll();
        }

        public IEnumerable<Wallet> GetFilteredWallets(WalletQueryParameters filter)
        {
            return walletRepository.GetFilteredWallets(filter);
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

        public Wallet Update(User user, Currency newCurrencyCode)
        {
            Wallet currentWallet = walletRepository.GetWalletByUser(user.Username);
            Currency currentCurrencyCode = currentWallet.CurrencyCode;

            PairRatesJson rateJson = Rates.GetExchangeRates(currentCurrencyCode.ToString(), newCurrencyCode.ToString());
            if (rateJson == null)
            {
                throw new UnauthorizedOperationException(Alerts.FailedCurrencyRate);
            }
            else
            {
                double exchangeRate = rateJson.conversion_rate;
                return this.walletRepository.Update(currentWallet.Id, exchangeRate, newCurrencyCode);
            }
        }

        public Wallet Delete(int id)
        {
            Wallet deletedWallet = walletRepository.Delete(id);
            return deletedWallet;
        }
    }
}
