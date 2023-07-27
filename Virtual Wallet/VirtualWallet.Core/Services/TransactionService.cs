using Org.BouncyCastle.Asn1.X509;
using Org.BouncyCastle.Cms;
using Virtual_Wallet.VirtualWallet.Common.Exceptions;
using Virtual_Wallet.VirtualWallet.Domain.Entities;
using Virtual_Wallet.VirtualWallet.Persistence.Repository.Contracts;
using VirtualWallet.Application.Services.Contracts;
using VirtualWallet.Common.AdditionalHelpers;
using VirtualWallet.Common.Exceptions;
using VirtualWallet.Domain.Entities;
using VirtualWallet.Domain.Enums;

namespace Virtual_Wallet.VirtualWallet.Application.Services
{
	public class TransactionService : ITransactionService
	{
		private readonly ITransactionRepository transactionRepository;
		private readonly IWalletRepository walletRepository;
		private readonly IUserRepository userRepository;
		private readonly IWalletService walletService;
		public TransactionService(ITransactionRepository transactionRepository, 
									IWalletRepository walletRepository, 
									IUserRepository userRepository, 
									IWalletService walletService)
		{
			this.transactionRepository = transactionRepository;
			this.walletRepository = walletRepository;
			this.userRepository = userRepository;
			this.walletService = walletService;
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

		public IList<Transaction> GetAllTransactions()
		{
			return transactionRepository.GetAllTransactions();
		}
		public void DeleteTransaction(int transactionId)
		{
			transactionRepository.DeleteTransaction(transactionId);
		}

		public Transaction GetTransactionById(int transactionId)
		{
			return transactionRepository.GetTransactionById(transactionId);
		}

        public IList<Transaction> GetTransactionsByUserId(int userId)
        {
            return transactionRepository.GetTransactionsByUserId(userId);
        }
        public PageResult<Transaction> GetTransactionsForUser(int userId, int pageNumber, int pageSize = 10)
		{
			return transactionRepository.GetAllTransactionsForUser(userId, pageNumber, pageSize);
		}

		public Transaction UpdateTransaction(Transaction transaction)
		{
			return transactionRepository.UpdateTransaction(transaction);
		}

		public Transaction AddMoneyCardToWallet(User user, Card card, Wallet wallet, decimal amount)
		{
			if(user == null || card == null || wallet == null)
			{
				throw new EntityNotFoundException(Alerts.ItemNotFound);
			}
			//check card is of the same user and if wallet if of the same user
			if(card.UserId != user.Id || wallet.UserId != user.Id)
			{
				throw new UnauthorizedOperationException(Alerts.InvalidAttenpt);
            }

            Transaction transaction = new Transaction()
			{
				Date = DateTime.Now,
				Amount = amount,
				TransactionType = TransactionType.BankTransfer,
                Sender = user,
                Recipient = user,
                CardNumber = CardHelper.HideCardNumber(card.Number)
			};

			var moneyAdded = walletService.AddToWallet(wallet.Id, amount);
			var transactionMade = transactionRepository.AddTransaction(transaction);

            return transactionMade;
        }
	}
}
