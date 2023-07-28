using Org.BouncyCastle.Asn1.X509;
using Org.BouncyCastle.Cms;
using Virtual_Wallet.VirtualWallet.Common.Exceptions;
using Virtual_Wallet.VirtualWallet.Domain.Entities;
using Virtual_Wallet.VirtualWallet.Domain.Enums;
using Virtual_Wallet.VirtualWallet.Persistence.Repository.Contracts;
using VirtualWallet.Application.ExchangeRateAPI;
using VirtualWallet.Application.Services.Contracts;
using VirtualWallet.Common.AdditionalHelpers;
using VirtualWallet.Common.Exceptions;
using VirtualWallet.Common.QueryParameters;
using VirtualWallet.Domain.Entities;
using VirtualWallet.Domain.Enums;

namespace Virtual_Wallet.VirtualWallet.Application.Services
{
	public class TransactionService : ITransactionService
	{
		private readonly ITransactionRepository transactionRepository;
		private readonly IWalletService walletService;
		public TransactionService(ITransactionRepository transactionRepository, 
									IWalletService walletService)
		{
			this.transactionRepository = transactionRepository;
			this.walletService = walletService;
		}

		public IList<Transaction> GetAllTransactions()
		{
			return transactionRepository.GetAllTransactions();
		}

        public IList<Transaction> GetFilteredTransactions(TransactionsQueryParameters filter, User user) 
        {
            return transactionRepository.GetFilteredTransactions(filter, user);
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

		public Transaction AddMoneyCardToWallet(User user, Card card, decimal amount)
		{
            if (user.IsBlocked)
            {
                throw new UnauthorizedOperationException(Alerts.BlockedUser);
            }

            if (user == null || card == null)
			{
				throw new EntityNotFoundException(Alerts.ItemNotFound);
			}

			Wallet wallet = walletService.GetWalletByUser(user.Username);

            if (wallet == null)
            {
                throw new EntityNotFoundException(Alerts.ItemNotFound);
            }

            //check card is of the same user and is wallet if of the same user
            if (card.UserId != user.Id || wallet.UserId != user.Id)
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

        public Transaction AddMoneyWalletToWallet(User sender, User recipient, decimal amount)
        {
            if (sender == null || recipient == null)
            {
                throw new EntityNotFoundException(Alerts.ItemNotFound);
            }

            if (sender.IsBlocked)
			{
                throw new UnauthorizedOperationException(Alerts.BlockedUser);
            }
            
			Wallet senderWallet = walletService.GetWalletByUser(sender.Username);
			decimal senderWalletAmount = walletService.GetBalance(senderWallet.Id);
			if(senderWalletAmount < amount) 
			{
                throw new InsuficientAmountException(Alerts.InsufficientAmount);
            }

            Wallet recepientWallet = walletService.GetWalletByUser(recipient.Username);

            var currencySender = senderWallet.CurrencyCode;
            var currencyRecipient = recepientWallet.CurrencyCode;
            var moneyToReceive = amount;
            double bgnToUsdRate = 0;
            if (currencySender != currencyRecipient)
            {
                RatesJson rateJson = Rates.GetExchangeRates(currencySender.ToString());

                if (rateJson != null)
                {
                    if (currencyRecipient == Currency.BGN)
                    {
                        bgnToUsdRate = rateJson.conversion_rates.BGN;
                    }else if (currencyRecipient == Currency.USD)
                    {
                        bgnToUsdRate = rateJson.conversion_rates.USD;
                    }else
                    {
                        bgnToUsdRate = rateJson.conversion_rates.EUR;
                    }
                    // You can store the BGN rate in a variable
                    moneyToReceive = (decimal)bgnToUsdRate * moneyToReceive;
                }
                else
                {
                    throw new UnauthorizedOperationException(Alerts.FailedCurrencyRate);
                }
            }

            Transaction transaction = new Transaction()
            {
                Date = DateTime.Now,
                Amount = amount,
                TransactionType = TransactionType.InternalOutCome,
                Sender = sender,
                Recipient = recipient,
                AmountReceived = (decimal)moneyToReceive,
                CurrencyExchangeRate = bgnToUsdRate
            };

			var moneyRemovedFromSender = walletService.WithdrawFromWallet(senderWallet.Id, amount);
            var moneyAddedtoRecipient = walletService.AddToWallet(recepientWallet.Id, moneyToReceive);

            var transactionMade = transactionRepository.AddTransaction(transaction);

            return transactionMade;
        }

        public Transaction WithdrawalTransfer(User user, Card card, decimal amount)
        {
            if (user.IsBlocked)
            {
                throw new UnauthorizedOperationException(Alerts.BlockedUser);
            }

            if (user == null || card == null)
            {
                throw new EntityNotFoundException(Alerts.ItemNotFound);
            }

            Wallet wallet = walletService.GetWalletByUser(user.Username);

            if (wallet == null)
            {
                throw new EntityNotFoundException(Alerts.ItemNotFound);
            }

            //check card is of the same user and is wallet if of the same user
            if (card.UserId != user.Id || wallet.UserId != user.Id)
            {
                throw new UnauthorizedOperationException(Alerts.InvalidAttenpt);
            }

            Transaction transaction = new Transaction()
            {
                Date = DateTime.Now,
                Amount = amount,
                TransactionType = TransactionType.Withdrawal,
                Sender = user,
                Recipient = user,
                CardNumber = CardHelper.HideCardNumber(card.Number)
            };

            var moneyRemoved = walletService.WithdrawFromWallet(wallet.Id, amount);
            var transactionMade = transactionRepository.AddTransaction(transaction);

            return transactionMade;
        }
    }
}
