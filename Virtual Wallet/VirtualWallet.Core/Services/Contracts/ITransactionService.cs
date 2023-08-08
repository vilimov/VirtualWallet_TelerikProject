using Virtual_Wallet.VirtualWallet.Domain.Entities;
using VirtualWallet.Common.QueryParameters;
using VirtualWallet.Domain.Entities;

namespace VirtualWallet.Application.Services.Contracts
{
	public interface ITransactionService
	{
		//Transaction CreateTransaction(CreateTransactionRequestDto request);
		//void DeleteTransaction(int transactionId);
		Transaction GetTransactionById(int transactionId);
		//PageResult<Transaction> GetTransactionsForUser(int userId, int pageNumber, int pageSize = 10);
		//Transaction UpdateTransaction(Transaction transaction);
		public IList<Transaction> GetAllTransactions();
		public IList<Transaction> GetTransactionsByUserId(int userId);
		public Transaction AddMoneyCardToWallet(User user, Card card, decimal amount, string description);
		public Transaction AddMoneyWalletToWallet(User sender, User recipient, decimal amount, string description);
		public Transaction WithdrawalTransfer(User user, Card card, decimal amount, string description);
		public IList<Transaction> GetFilteredTransactions(TransactionsQueryParameters filter, User user);
		//public IList<Transaction> GetAllTransactions(int pageNumber, int pageSize, TransactionsQueryParameters? filter, User user);
		public IList<Transaction> GetAllTransactions(int pageNumber, int pageSize, User user, string search = null);
		//public IList<Transaction> GetFilteredTransactions(int pageNumber, int pageSize, TransactionsQueryParameters filter, User user);
		public IList<Transaction> GetTransactionsByUserId(int pageNumber, int pageSize, User user, string search = null);
		public int GetTransactionsCount(string search, User user);
		public IList<Transaction> GetFilteredTransactions(int pageNumber, int pageSize, TransactionsQueryParameters filter, User user, string search = null);

	}
}
