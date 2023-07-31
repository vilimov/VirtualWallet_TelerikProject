using Microsoft.EntityFrameworkCore;
using System.Globalization;
using Virtual_Wallet.VirtualWallet.Common.Exceptions;
using Virtual_Wallet.VirtualWallet.Domain.Entities;
using Virtual_Wallet.VirtualWallet.Persistence.Data;
using Virtual_Wallet.VirtualWallet.Persistence.Repository.Contracts;
using VirtualWallet.Common.AdditionalHelpers;
using VirtualWallet.Common.QueryParameters;
using VirtualWallet.Domain.Entities;
using VirtualWallet.Domain.Enums;

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

        public IList<Transaction> GetFilteredTransactions(TransactionsQueryParameters filter, User user)
		{
            List<Transaction> transactions = GetAllTransactions();
            if (!string.IsNullOrEmpty(filter.AllMyTransactions))
            {
                transactions = transactions.FindAll(t => t.SenderId == user.Id || t.RecipientId == user.Id);
            }
            if (!string.IsNullOrEmpty(filter.Sender))
            {
                transactions = transactions.FindAll(t => t.SenderId == user.Id);
            }
            if (!string.IsNullOrEmpty(filter.Reciever))
            {
                transactions = transactions.FindAll(t => t.RecipientId == user.Id);
            }
            if (!string.IsNullOrEmpty(filter.Withdrawl))
            {
                transactions = transactions.FindAll(t => t.TransactionType == TransactionType.Withdrawal && t.SenderId == user.Id);
            }
            if (!string.IsNullOrEmpty(filter.FeedWallet))
            {
                transactions = transactions.FindAll(t => t.TransactionType == TransactionType.BankTransfer && t.SenderId == user.Id);
            }
            if (!string.IsNullOrEmpty(filter.FilterByDate))
            {
                if (DateTime.TryParseExact(filter.FilterByDate, "dd-MM-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime inputDate))
                {
                    string formattedInputDate = inputDate.ToString("yyyy-MM-dd");
                    transactions = transactions.FindAll(t => t.Date.Date == DateTime.Parse(formattedInputDate).Date);
                }
                else if (DateTime.TryParseExact(filter.FilterByDate, "MM-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime inputMonthYear))
                {
                    // The user entered a month and year (without the day)
                    transactions = transactions.FindAll(t => t.Date.Month == inputMonthYear.Month && t.Date.Year == inputMonthYear.Year);
                }
            }

            return transactions;

        }

		public Transaction GetTransactionById(int id)
		{
            var transaction = this.context.Transactions
               .Include(t => t.Sender)
			   .Include(t => t.Recipient)
               .FirstOrDefault(t => t.Id == id);

            if (transaction == null)
            {
                throw new EntityNotFoundException(Alerts.NoItemToShow);
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
