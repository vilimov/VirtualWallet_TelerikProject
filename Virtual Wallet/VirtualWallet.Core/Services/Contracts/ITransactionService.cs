using Virtual_Wallet.VirtualWallet.Domain.Entities;
using VirtualWallet.Domain.Entities;

namespace VirtualWallet.Application.Services.Contracts
{
	public interface ITransactionService
	{
		//Task<Transaction> CreateTransactionAsync(CreateTransactionRequestDto request);
		Task DeleteTransactionAsync(int transactionId);
		Task<Transaction> GetTransactionByIdAsync(int transactionId);
		Task<PageResult<Transaction>> GetTransactionsForUserAsync(int userId, int pageNumber, int pageSize = 10);
		Task<Transaction> UpdateTransactionAsync(Transaction transaction);
	}
}
