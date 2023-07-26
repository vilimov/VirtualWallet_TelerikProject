using Microsoft.EntityFrameworkCore;
using Virtual_Wallet.VirtualWallet.Common.Exceptions;
using Virtual_Wallet.VirtualWallet.Domain.Entities;
using Virtual_Wallet.VirtualWallet.Domain.Enums;
using Virtual_Wallet.VirtualWallet.Persistence.Data;
using Virtual_Wallet.VirtualWallet.Persistence.Repository.Contracts;

namespace Virtual_Wallet.VirtualWallet.Persistence.Repository
{
    public class WalletRepository : IWalletRepository
    {
        private readonly WalletContext context;

        public WalletRepository(WalletContext context)
        {
            this.context = context;
        }
        public Wallet CreateWallet(Wallet wallet)
        {
            this.context.Wallets.Add(wallet);
            context.SaveChanges();

            return wallet;
        }

        public IEnumerable<Wallet> GetAll()
        {
            IEnumerable<Wallet> result = context.Wallets
                           .Where(w => !w.IsInactive)
                           .Include(w => w.User);
            return result.ToList() ?? throw new EntityNotFoundException("No wallets were found");
        }

        public Wallet GetWalletById(int id)
        {
            Wallet wallet = GetAll().FirstOrDefault(w => w.Id == id);
            return wallet ?? throw new EntityNotFoundException($"Wallet with Id: {id} does not exist!");
        }

        public Wallet GetWalletByUser(string username)
        {
            Wallet wallet = GetAll().FirstOrDefault(w => w.User.Username == username);
            return wallet ?? throw new EntityNotFoundException($"User with Username: {username} does not have a wallet");
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
                throw new InsuficientAmountException($"Insufficient amount!");
            }

            wallet.Balance -= amount;
            context.SaveChanges();
            return wallet.Balance;
        }

        public decimal Block (int id, decimal amount)
        {
            Wallet wallet = GetWalletById(id);
            if (wallet.Balance < amount)
            {
                throw new InsuficientAmountException($"Insufficient amount!");
            }

            wallet.Balance -= amount;
            wallet.Blocked += amount;
            context.SaveChanges();
            return wallet.Balance;
        }

        public decimal ReleaseBlocked(int id, decimal amount)
        {
            Wallet wallet = GetWalletById(id);
            if (wallet.Blocked < amount)
            {
                throw new InsuficientAmountException($"Insufficient amount!");
            }

            wallet.Blocked -= amount;
            context.SaveChanges();
            return wallet.Balance;
        }

        public decimal Unblock(int id, decimal amount)
        {
            Wallet wallet = GetWalletById(id);
            wallet.Balance += amount;
            context.SaveChanges();
            return wallet.Balance;
        }

        public Wallet Delete(int id)
        {
            Wallet waletToDelete = GetWalletById(id);
            if (waletToDelete.Balance > 0 || waletToDelete.Blocked > 0)
            {
                string balance = $"{waletToDelete.Balance.ToString("F2")} {waletToDelete.CurrencyCode.ToString()}";
                string blocked = $"{waletToDelete.Blocked.ToString("F2")} {waletToDelete.CurrencyCode.ToString()}";
                throw new WalletNotEmptyException($"This wallet's balance is {balance} and has {blocked} blocked! Wallet must be empty in order to be deleted!");
            }
            Deactivate(waletToDelete);
            context.SaveChanges();
            return waletToDelete;
        }
		public decimal AdjustBalance(int walletId, decimal amount, bool isDeposit)
		{
			var wallet = GetWalletById(walletId);
			if (wallet == null)
			{
				throw new EntityNotFoundException($"Wallet with ID {walletId} not found.");
			}

			if (isDeposit)
			{
				wallet.Balance += amount;
			}
			else
			{
				if (wallet.Balance < amount)
				{
					throw new InvalidOperationException($"Not enough funds in wallet with ID {walletId}.");
				}
				wallet.Balance -= amount;
			}

			this.context.Entry(wallet).State = EntityState.Modified;
			this.context.SaveChanges();

			return wallet.Balance;
		}

        public void Deactivate (Wallet wallet)
        { 
            wallet.IsInactive = true;
        }
	}
}
