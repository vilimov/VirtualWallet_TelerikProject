using Virtual_Wallet.VirtualWallet.Domain.Entities;
using VirtualWallet.Domain.Entities;

namespace VirtualWallet.Application.Services.Contracts
{
	public interface ITransactionService
	{
		//Transaction CreateTransaction(CreateTransactionRequestDto request);
		void DeleteTransaction(int transactionId);
		Transaction GetTransactionById(int transactionId);
		PageResult<Transaction> GetTransactionsForUser(int userId, int pageNumber, int pageSize = 10);
		Transaction UpdateTransaction(Transaction transaction);
	}
}
