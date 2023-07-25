using Virtual_Wallet.VirtualWallet.Domain.Entities;
using VirtualWallet.Domain.Entities;

namespace Virtual_Wallet.VirtualWallet.Persistence.Repository.Contracts
{
	public interface ITransactionRepository
	{
		Task<Transaction> GetTransactionById(int id);
		Task<PageResult<Transaction>> GetAllTransactionsForUser(int userId, int pageNumber, int pageSize = 10);
		Task<Transaction> AddTransaction(Transaction transaction);
		Task<Transaction> UpdateTransaction(Transaction transaction);
		Task DeleteTransaction(int id);
	}
}
