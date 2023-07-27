using Microsoft.EntityFrameworkCore;
using Virtual_Wallet.VirtualWallet.Common.Exceptions;
using Virtual_Wallet.VirtualWallet.Domain.Entities;
using Virtual_Wallet.VirtualWallet.Persistence.Data;
using Virtual_Wallet.VirtualWallet.Persistence.Repository.Contracts;
using VirtualWallet.Common.AdditionalHelpers;
using VirtualWallet.Domain.Entities;

namespace Virtual_Wallet.VirtualWallet.Persistence.Repository
{
    public class TransactionRepository : ITransactionRepository
	{
		private readonly WalletContext context;

		public TransactionRepository(WalletContext context) 
		{
			this.context = context;
		}
		public List<Transaction> GetAllTransactions()
		{
			return this.context.Transactions.Include(s=>s.Sender)
											.Include(r=>r.Recipient)
											.ToList();
		}

		public Transaction GetTransactionById(int id)
		{
			var transaction = this.context.Transactions.Find(id);
			if (transaction == null)
			{
				throw new EntityNotFoundException(string.Format(Alerts.NotFound, "Transaction", "ID", $"{id}"));
            }
            return transaction;
		}
        public IList<Transaction> GetTransactionsByUserId(int userId)
		{
			var transactions = this.context.Transactions
                        .Where(t => t.SenderId == userId).ToList();
            if (transactions.Count <= 0 || transactions == null)
            {
                throw new EntityNotFoundException(Alerts.NoItemToShow);
            }
			return transactions;
        }

        public PageResult<Transaction> GetAllTransactionsForUser(int userId, int pageNumber, int pageSize = 10)
		{
			var query = this.context.Transactions
						.Where(t => t.SenderId == userId || t.RecipientId == userId);

			int count = query.Count();

			var items = query
				.Skip((pageNumber - 1) * pageSize)
				.Take(pageSize)
				.ToList();

			return new PageResult<Transaction>(items, count, pageNumber, pageSize);
		}

		public Transaction AddTransaction(Transaction transaction)
		{
			var result = this.context.Transactions.Add(transaction);
			this.context.SaveChanges();
			return result.Entity;
		}

		public Transaction UpdateTransaction(Transaction transaction)
		{
			this.context.Entry(transaction).State = EntityState.Modified;
			this.context.SaveChanges();
			return transaction;
		}

		public void DeleteTransaction(int id)
		{
			var transaction = this.context.Transactions.Find(id);
			if (transaction != null)
			{
				this.context.Transactions.Remove(transaction);
				this.context.SaveChanges();
			}
		}
	}
}
