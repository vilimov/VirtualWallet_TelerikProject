using Virtual_Wallet.VirtualWallet.Common.Exceptions;
using Virtual_Wallet.VirtualWallet.Domain.Entities;
using Virtual_Wallet.VirtualWallet.Persistence.Repository.Contracts;
using VirtualWallet.Application.Services.Contracts;
using VirtualWallet.Domain.Entities;

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

		//public Transaction CreateTransaction(CreateTransactionRequestDto request)
		//{
		//	var sender = userRepository.GetUserById(request.SenderId);
		//	var recipient = userRepository.GetUserById(request.RecipientId);

		//	if (sender == null)
		//	{
		//		throw new EntityNotFoundException($"Sender with ID {request.SenderId} not found.");
		//	}
		//	if (recipient == null)
		//	{
		//		throw new EntityNotFoundException($"Recipient with ID {request.RecipientId} not found.");
		//	}

		//	// sender has enough balance
		//	var senderWallet = walletRepository.GetWalletByUser(sender.Username);
		//	if (senderWallet.Balance < request.Amount)
		//	{
		//		throw new InvalidOperationException($"Sender with ID {request.SenderId} does not have enough balance.");
		//	}

		//	// create transaction
		//	var transaction = new Transaction
		//	{
		//		SenderId = request.SenderId,
		//		RecipientId = request.RecipientId,
		//		Amount = request.Amount,
		//		Date = DateTime.UtcNow,
		//		IsInbound = true
		//	};

		//	// update sender and recipient balances
		//	walletRepository.AdjustBalance(senderWallet.Id, request.Amount, false);
		//	var recipientWallet = walletRepository.GetWalletByUser(recipient.Username);
		//	walletRepository.AdjustBalance(recipientWallet.Id, request.Amount, true);

		//	// continue the transaction
		//	transactionRepository.AddTransaction(transaction);

		//	return transaction;
		//}

		public void DeleteTransaction(int transactionId)
		{
			transactionRepository.DeleteTransaction(transactionId);
		}

		public Transaction GetTransactionById(int transactionId)
		{
			return transactionRepository.GetTransactionById(transactionId);
		}

		public PageResult<Transaction> GetTransactionsForUser(int userId, int pageNumber, int pageSize = 10)
		{
			return transactionRepository.GetAllTransactionsForUser(userId, pageNumber, pageSize);
		}

		public Transaction UpdateTransaction(Transaction transaction)
		{
			return transactionRepository.UpdateTransaction(transaction);
		}
	}
}
