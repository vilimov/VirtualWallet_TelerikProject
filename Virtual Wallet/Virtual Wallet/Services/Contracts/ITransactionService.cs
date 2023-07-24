using Virtual_Wallet.Models.Dtos;
using Virtual_Wallet.Repository;

namespace Virtual_Wallet.Services.Contracts
{
	public interface ITransactionService
	{
		Task<Transaction> CreateTransactionAsync(CreateTransactionRequest request);
		Task DeleteTransactionAsync(int transactionId);
		Task<Transaction> GetTransactionByIdAsync(int transactionId);
		Task<PageResult<Transaction>> GetTransactionsForUserAsync(int userId, int pageNumber, int pageSize = 10);
		Task<Transaction> UpdateTransactionAsync(Transaction transaction);
	}
}
