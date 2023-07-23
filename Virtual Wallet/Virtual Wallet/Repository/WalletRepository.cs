using Virtual_Wallet.Data;
using Virtual_Wallet.Models;
using Virtual_Wallet.Models.Enum;
using Virtual_Wallet.Repository.Contracts;
using Microsoft.EntityFrameworkCore;
using Virtual_Wallet.Helpers.Exceptions;

namespace Virtual_Wallet.Repository
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
                return GetWalletById(id).Currency;
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
	}
}
