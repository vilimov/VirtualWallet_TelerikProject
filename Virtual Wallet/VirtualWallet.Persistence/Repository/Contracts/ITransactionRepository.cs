using Virtual_Wallet.VirtualWallet.Domain.Entities;
using VirtualWallet.Domain.Entities;

namespace Virtual_Wallet.VirtualWallet.Persistence.Repository.Contracts
{
	public interface ITransactionRepository
	{
		Transaction GetTransactionById(int id);
		PageResult<Transaction> GetAllTransactionsForUser(int userId, int pageNumber, int pageSize = 10);
		Transaction AddTransaction(Transaction transaction);
		Transaction UpdateTransaction(Transaction transaction);
		void DeleteTransaction(int id);
		public List<Transaction> GetAllTransactions();
		public IList<Transaction> GetTransactionsByUserId(int userId);


    }
}
