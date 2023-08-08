using Org.BouncyCastle.Asn1.X509;
using Org.BouncyCastle.Cms;
using Virtual_Wallet.VirtualWallet.Common.Exceptions;
using Virtual_Wallet.VirtualWallet.Domain.Entities;
using Virtual_Wallet.VirtualWallet.Domain.Enums;
using Virtual_Wallet.VirtualWallet.Persistence.Repository;
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
        private readonly IEmailService emailService;
		public TransactionService(ITransactionRepository transactionRepository, 
									IWalletService walletService,
									IEmailService emailService)
		{
			this.transactionRepository = transactionRepository;
			this.walletService = walletService;
			this.emailService = emailService;
		}

		public IList<Transaction> GetAllTransactions(int pageNumber, int pageSize, TransactionsQueryParameters? filter, User user)
		{
			//return transactionRepository.GetAllTransactions();
            var tratransactions = transactionRepository.GetAllTransactions().AsQueryable();
			if (filter != null)
			{
				tratransactions = transactionRepository.GetFilteredTransactions(filter, user).AsQueryable();
			}

			return tratransactions
				.Skip((pageNumber - 1) * pageSize)
				.Take(pageSize)
				.ToList();

		}

        public IList<Transaction> GetFilteredTransactions(int pageNumber, int pageSize, TransactionsQueryParameters filter, User user) 
        {
			//return transactionRepository.GetFilteredTransactions(filter, user);
			var tratransactions = transactionRepository.GetAllTransactions().AsQueryable();
			
            if (filter != null)
			{
				tratransactions = transactionRepository.GetFilteredTransactions(filter, user).AsQueryable();
			}

			return tratransactions
				.Skip((pageNumber - 1) * pageSize)
				.Take(pageSize)
				.ToList();
		}

		public int GetTransactionsCount(TransactionsQueryParameters filter, User user)
		{
			var tratransactions = transactionRepository.GetAllTransactions().AsQueryable();

			if (filter != null)
			{
				tratransactions = tratransactions = transactionRepository.GetFilteredTransactions(filter, user).AsQueryable();
			}

			return tratransactions.Count();
		}


		public Transaction GetTransactionById(int transactionId)
		{
			return transactionRepository.GetTransactionById(transactionId);
		}

        public IList<Transaction> GetTransactionsByUserId(int userId)
        {
            return transactionRepository.GetTransactionsByUserId(userId);
        }
		public IList<Transaction> GetTransactionsByUserId(int pageNumber, int pageSize, TransactionsQueryParameters filter, User user)
		{
			filter.AllMyTransactions = "true";
			var tratransactions = transactionRepository.GetAllTransactions().AsQueryable();
			if (filter != null)
			{
				tratransactions = transactionRepository.GetFilteredTransactions(filter, user).AsQueryable();
			}

			return tratransactions
				.Skip((pageNumber - 1) * pageSize)
				.Take(pageSize)
				.ToList();

		}
		/* Not Used For Now
        public PageResult<Transaction> GetTransactionsForUser(int userId, int pageNumber, int pageSize = 10)
		{
			return transactionRepository.GetAllTransactionsForUser(userId, pageNumber, pageSize);
		}

		public Transaction UpdateTransaction(Transaction transaction)
		{
			return transactionRepository.UpdateTransaction(transaction);
		}
        		public void DeleteTransaction(int transactionId)
		{
			transactionRepository.DeleteTransaction(transactionId);
		}
        */

		public Transaction AddMoneyCardToWallet(User user, Card card, decimal amount, string description)
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
				TransactionType = TransactionType.Deposit,
                Sender = user,
                Recipient = user,
                CardNumber = CardHelper.HideCardNumber(card.Number),
                Description = description,
                SenderWalletCurrency = wallet.CurrencyCode
            };

			var moneyAdded = walletService.AddToWallet(wallet.Id, amount);
			var transactionMade = transactionRepository.AddTransaction(transaction);

            return transactionMade;
        }

        public Transaction AddMoneyWalletToWallet(User sender, User recipient, decimal amount, string description)
        {
            if (sender == null || recipient == null)
            {
                throw new EntityNotFoundException(Alerts.ItemNotFound);
            }

            if (sender.IsBlocked)
			{
                throw new UnauthorizedOperationException(Alerts.BlockedUser);
            }

			if (sender == recipient)
			{
				throw new UnauthorizedOperationException(Alerts.InvalidAttenpt);
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
                TransactionType = TransactionType.Transfer,
                Sender = sender,
                Recipient = recipient,
                AmountReceived = (decimal)moneyToReceive,
                CurrencyExchangeRate = bgnToUsdRate,
                Description = description,
                SenderWalletCurrency = senderWallet.CurrencyCode,
                RecipientWalletCurrency = recepientWallet.CurrencyCode
            };

			var moneyRemovedFromSender = walletService.WithdrawFromWallet(senderWallet.Id, amount);
            var moneyAddedtoRecipient = walletService.AddToWallet(recepientWallet.Id, moneyToReceive);

            var transactionMade = transactionRepository.AddTransaction(transaction);

			var mailRequest = new Mail
			{
				Body = $"Hello {recipient.Username}! User {sender.Username} just trsnsfer to you the amount of {transaction.AmountReceived} {recepientWallet.CurrencyCode} with subject *{transaction.Description}*.",
				To = recipient.Email,
				Subject = "MaxKashMate money trsnsfer"
			};

			emailService.SendEmail(mailRequest);

			return transactionMade;
        }

        public Transaction WithdrawalTransfer(User user, Card card, decimal amount, string description)
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

			var currencyWallet = wallet.CurrencyCode;
			var currencyCard = card.CurrencyCode;
			var moneyToReceive = amount;
			double exchangeRate = 0;
			if (currencyWallet != currencyCard)
			{

				PairRatesJson rateJson = Rates.GetExchangeRates(currencyWallet.ToString(), currencyCard.ToString());
				if (rateJson == null)
				{
					throw new UnauthorizedOperationException(Alerts.FailedCurrencyRate);
				}
				else
				{
					exchangeRate = rateJson.conversion_rate;
					moneyToReceive = (decimal)exchangeRate * moneyToReceive;
				}

			}

			Transaction transaction = new Transaction()
            {
                Date = DateTime.Now,
                Amount = amount,
                TransactionType = TransactionType.Withdraw,
                Sender = user,
                Recipient = user,
                CardNumber = CardHelper.HideCardNumber(card.Number),
                Description = description,
                SenderWalletCurrency = wallet.CurrencyCode,
				CurrencyExchangeRate = exchangeRate,
				AmountReceived = (decimal)moneyToReceive,
				RecipientWalletCurrency = card.CurrencyCode
			};

            var moneyRemoved = walletService.WithdrawFromWallet(wallet.Id, amount);
            var transactionMade = transactionRepository.AddTransaction(transaction);

            return transactionMade;
        }
    }
}
