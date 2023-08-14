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
            var transactionList = this.context.Transactions
				.Include(s => s.Sender)
				.ThenInclude(s => s.Cards)
				.Include(s => s.Sender.Wallet)
				.Include(r => r.Recipient)
				.ThenInclude(r => r.Cards)
				.Include(r => r.Recipient.Wallet)
				.ToList();

			transactionList.Reverse();

			return transactionList;
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
                transactions = transactions.FindAll(t => t.Sender.Username.Contains(filter.Sender));
            }
            if (!string.IsNullOrEmpty(filter.Reciever))
            {
                transactions = transactions.FindAll(t => t.Recipient.Username.Contains(filter.Reciever));
            }
            if (!string.IsNullOrEmpty(filter.Withdrawl))
            {
                transactions = transactions.FindAll(t => t.TransactionType == TransactionType.Withdraw);
            }
            if (!string.IsNullOrEmpty(filter.DepositToWallet))
            {
                transactions = transactions.FindAll(t => t.TransactionType == TransactionType.Deposit);
            }
			if (!string.IsNullOrEmpty(filter.TransferToUser))
			{
				transactions = transactions.FindAll(t => t.TransactionType == TransactionType.Transfer );
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

			if (transactions == null)
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
	}
}
