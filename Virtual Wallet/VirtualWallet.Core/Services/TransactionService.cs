using Virtual_Wallet.VirtualWallet.API.Helpers.Exceptions;
using Virtual_Wallet.VirtualWallet.Core.Entities;
using Virtual_Wallet.VirtualWallet.Persistence.Repository.Contracts;
using VirtualWallet.Core.Entities;

namespace Virtual_Wallet.VirtualWallet.Application.Services
{
    public class TransactionService : ITransactionService
	{
		private readonly ITransactionRepository transactionRepository;
		private readonly IWalletRepository walletRepository;
		private readonly IUserRepository userRepository;

		public TransactionService(ITransactionRepository transactionRepository, IWalletRepository walletRepository, IUserRepository userRepository)
		{
			this.transactionRepository = transactionRepository;
			this.walletRepository = walletRepository;
			this.userRepository = userRepository;
		}

		public async Task<Transaction> CreateTransactionAsync(CreateTransactionRequest request)
		{
			
			var sender = await userRepository.GetUserById(request.SenderId);
			var recipient = await userRepository.GetUserById(request.RecipientId);
			
			if (sender == null)
			{
				throw new EntityNotFoundException($"Sender with ID {request.SenderId} not found.");
			}
			if (recipient == null)
			{
				throw new EntityNotFoundException($"Recipient with ID {request.RecipientId} not found.");
			}

			// sender has enough balance
			var senderWallet = walletRepository.GetWalletByUser(sender.Username);
			if (senderWallet.Balance < request.Amount)
			{
				throw new InvalidOperationException($"Sender with ID {request.SenderId} does not have enough balance.");
			}

			// create transaction
			var transaction = new Transaction
			{
				SenderId = request.SenderId,
				RecipientId = request.RecipientId,
				Amount = request.Amount,
				Date = DateTime.UtcNow,
				IsInbound = true
			};

			// update sender and recipient balances
			walletRepository.AdjustBalance(senderWallet.Id, request.Amount, false);
			var recipientWallet = walletRepository.GetWalletByUser(recipient.Username);
			walletRepository.AdjustBalance(recipientWallet.Id, request.Amount, true);

			// continue the transaction
			await transactionRepository.AddTransaction(transaction);

			return transaction;
		}

		public async Task DeleteTransactionAsync(int transactionId)
		{
			await transactionRepository.DeleteTransaction(transactionId);
		}

		public async Task<Transaction> GetTransactionByIdAsync(int transactionId)
		{
			return await transactionRepository.GetTransactionById(transactionId);
		}

		public async Task<PageResult<Transaction>> GetTransactionsForUserAsync(int userId, int pageNumber, int pageSize = 10)
		{
			return await transactionRepository.GetAllTransactionsForUser(userId, pageNumber, pageSize);
		}

		public async Task<Transaction> UpdateTransactionAsync(Transaction transaction)
		{
			return await transactionRepository.UpdateTransaction(transaction);
		}
	}
}
