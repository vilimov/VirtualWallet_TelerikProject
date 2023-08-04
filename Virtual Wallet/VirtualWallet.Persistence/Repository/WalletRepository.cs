using Microsoft.EntityFrameworkCore;
using System.Globalization;
using Virtual_Wallet.VirtualWallet.Common.Exceptions;
using Virtual_Wallet.VirtualWallet.Common.QueryParameters;
using Virtual_Wallet.VirtualWallet.Domain.Entities;
using Virtual_Wallet.VirtualWallet.Domain.Enums;
using Virtual_Wallet.VirtualWallet.Persistence.Data;
using Virtual_Wallet.VirtualWallet.Persistence.Repository.Contracts;
using VirtualWallet.Common.AdditionalHelpers;
using VirtualWallet.Persistence.QueryParameters;

namespace Virtual_Wallet.VirtualWallet.Persistence.Repository
{
    public class WalletRepository : IWalletRepository
    {
        private readonly WalletContext context;

        public WalletRepository(WalletContext context)
        {
            this.context = context;
        }
        public Wallet CreateWallet(Wallet wallet, User user)
        {
            if (user.WalletId == null)
            {
                wallet.User = user;
                this.context.Wallets.Add(wallet);
                context.SaveChanges();
            }
            else 
            {
                throw new DuplicateEntityException(Alerts.ExistingWallet);
            }
            return wallet;
        }

        public IEnumerable<Wallet> GetAll()
        {
            IEnumerable<Wallet> result = context.Wallets
                           .Where(w => !w.IsInactive)
                           .Include(w => w.User);
            return result.ToList() ?? throw new EntityNotFoundException(Alerts.NoItemToShow);
        }

        public IList<Wallet> GetFilteredWallets(WalletQueryParameters filter)
        {
            List<Wallet> wallets = GetAll().ToList();
            if (!string.IsNullOrEmpty(filter.CurrencyCode.ToString()))
            {
                wallets = wallets.FindAll(w => w.CurrencyCode == filter.CurrencyCode);
            }
            if (!string.IsNullOrEmpty(filter.BallanceMoreThan.ToString()))
            {
                wallets = wallets.FindAll(w => w.Balance >= filter.BallanceMoreThan);
            }
            if (!string.IsNullOrEmpty(filter.BallanceLessThan.ToString()))
            {
                wallets = wallets.FindAll(w => w.Balance <= filter.BallanceLessThan);
            }
            if (!string.IsNullOrEmpty(filter.BlockedMoreThan.ToString()))
            {
                wallets = wallets.FindAll(w => w.Blocked >= filter.BlockedMoreThan);
            }
            if (!string.IsNullOrEmpty(filter.BlockedLessThan.ToString()))
            {
                wallets = wallets.FindAll(w => w.Blocked <= filter.BlockedLessThan);
            }
            if (!string.IsNullOrEmpty(filter.IsInactive.ToString()))
            {
                wallets = wallets.FindAll(w => w.IsInactive == filter.IsInactive);
            }
            if (!string.IsNullOrEmpty(filter.SortBy))
            {
                switch (filter.SortBy.ToLower())
                {
                    case "ballance":
                        wallets = wallets.OrderByDescending(wallet => wallet.Balance).ToList();
                        break;
                    case "blocked":
                        wallets = wallets.OrderByDescending(wallet => wallet.Blocked).ToList();
                        break;
                    default:
                        break;
                }
            }
            if (!string.IsNullOrEmpty(filter.SortOrder))
            {
                switch (filter.SortOrder.ToLower())
                {
                    case "asc":
                        wallets.Reverse();
                        break;
                    default:
                        break;
                }
            }
            return wallets;
        }

        public Wallet GetWalletById(int id)
        {
            Wallet wallet = GetAll().FirstOrDefault(w => w.Id == id);
            return wallet ?? throw new EntityNotFoundException(Alerts.NoItemToShow);
        }

        public Wallet GetWalletByUser(string username)
        {
            Wallet wallet = GetAll().FirstOrDefault(w => w.User.Username == username);
            return wallet ?? throw new EntityNotFoundException(Alerts.NoItemToShow); ;
        }

        public decimal GetBalance(int id)
        {
            return GetWalletById(id).Balance;
        }

        public Currency GetCurrencyById(int id)
        {
            return GetWalletById(id).CurrencyCode;
        }

        public decimal AddToWallet(int id, decimal amount)
        {
            Wallet wallet = GetWalletById(id);
            wallet.Balance += amount;
            context.SaveChanges();
            return wallet.Balance;
        }

        public decimal WithdrawFromWallet(int id, decimal amount)
        {
            Wallet wallet = GetWalletById(id);
            if (wallet.Balance < amount)
            {
                throw new InsuficientAmountException(Alerts.InsufficientAmount);
            }

            wallet.Balance -= amount;
            context.SaveChanges();
            return wallet.Balance;
        }
      
        public Wallet Update(int id, double exchangeRate, Currency newCurrencyCode)
        {
            Wallet wallet = GetWalletById(id);
            wallet.Balance *= (decimal)exchangeRate;
            wallet.Blocked *= (decimal)exchangeRate;
            wallet.CurrencyCode = newCurrencyCode;
            context.SaveChanges();
            return wallet;
        }

        public Wallet Delete(int id)
        {
            Wallet waletToDelete = GetWalletById(id);
            if (waletToDelete.Balance > 0 || waletToDelete.Blocked > 0)
            {
                string balance = $"{waletToDelete.Balance.ToString("F2")} {waletToDelete.CurrencyCode.ToString()}";
                string blocked = $"{waletToDelete.Blocked.ToString("F2")} {waletToDelete.CurrencyCode.ToString()}";
                throw new WalletNotEmptyException(String.Format(Alerts.WalletNotEmpty, balance, blocked));
            }
            Deactivate(waletToDelete);
            context.SaveChanges();
            return waletToDelete;
        }

        public void Deactivate (Wallet wallet)
        { 
            wallet.IsInactive = true;
        }
	}
}
