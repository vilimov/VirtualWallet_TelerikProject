using Microsoft.EntityFrameworkCore;
using System.Globalization;
using Virtual_Wallet.VirtualWallet.Common.Exceptions;
using Virtual_Wallet.VirtualWallet.Common.QueryParameters;
using Virtual_Wallet.VirtualWallet.Domain.Entities;
using Virtual_Wallet.VirtualWallet.Persistence.Data;
using Virtual_Wallet.VirtualWallet.Persistence.Repository.Contracts;
using VirtualWallet.Common.AdditionalHelpers;
using VirtualWallet.Common.Exceptions;

namespace Virtual_Wallet.VirtualWallet.Persistence.Repository
{
    public class CardRepository : ICardRepository
    {
        private readonly WalletContext context;
        public CardRepository(WalletContext context)
        {
            this.context = context;
        }

        public Card Add(Card card, User user)
        {
            CheckForExistingCardName(card, user);
            CheckExpirationDate(card);

            Card inactiveCard = context.Cards.FirstOrDefault(c => c.Number == card.Number);
            if (inactiveCard != null && inactiveCard.IsInactive == false)
            {
                throw new DuplicateEntityException(Alerts.CardAlreadyAdded);
            }
            else if (inactiveCard != null && inactiveCard.CardHolder == card.CardHolder && inactiveCard.CheckNumber == card.CheckNumber)
            {
                inactiveCard.IsInactive = false;
            }
            else
            {
                card.User = user;
                this.context.Cards.Add(card);
            }
            context.SaveChanges();

            return card;
        }

		public Card Update(Card updatedCard, User user, int id)
		{
			CheckForExistingCardName(updatedCard, user);
			CheckExpirationDate(updatedCard);
            Card currentCard = GetById(id);
			if (!string.IsNullOrEmpty(updatedCard.Name))
			{
				currentCard.Name = updatedCard.Name;
			}
			if (updatedCard.ExpirationDate.AddMonths(1) >= DateTime.Now)
			{
				currentCard.ExpirationDate = updatedCard.ExpirationDate;
			}
			if (!string.IsNullOrEmpty(updatedCard.CurrencyCode.ToString()))
			{
				currentCard.CurrencyCode = updatedCard.CurrencyCode;
			}
			if (!string.IsNullOrEmpty(updatedCard.IsCreditCard.ToString()))
			{
				currentCard.IsCreditCard = updatedCard.IsCreditCard;
			}
			if (!string.IsNullOrEmpty(updatedCard.CardHolder))
			{
				currentCard.CardHolder = updatedCard.CardHolder;
			}
			if (!string.IsNullOrEmpty(updatedCard.CheckNumber))
			{
				currentCard.CheckNumber = updatedCard.CheckNumber;
			}
			context.SaveChanges();

			return currentCard;
		}



        public IQueryable<Card> GetAll()
        {
            IQueryable<Card> cards = context.Cards
                                                .Where(c => !c.IsInactive)
                                                .Include(c => c.User);
            return cards ?? throw new EntityNotFoundException(Alerts.NoItemToShow);
        }

        public IList<Card> GetFilteredCards(CardQueryParameters filter)
        {
            List<Card> cards = GetAll().ToList();
			if (!string.IsNullOrEmpty(filter.Name))
			{
                string searchString = filter.Name;
				cards = cards.Where(c => c.Name.Contains(searchString, StringComparison.InvariantCultureIgnoreCase)).ToList();
			}
			if (!string.IsNullOrEmpty(filter.IsCredit.ToString()))
            {
                cards = cards.FindAll(c => c.IsCreditCard == filter.IsCredit);
            }
            if (!string.IsNullOrEmpty(filter.ExpiresBefore))
            {
                DateTime expiresBefore = DateTime.ParseExact(filter.ExpiresBefore.ToString(), "MMyy", CultureInfo.InvariantCulture);
                cards = cards.FindAll(c => c.ExpirationDate <= expiresBefore);
            }
            if (!string.IsNullOrEmpty(filter.ExpiresAfter))
            {
                DateTime expiresAfter = DateTime.ParseExact(filter.ExpiresAfter.ToString(), "MMyy", CultureInfo.InvariantCulture);
                cards = cards.FindAll(c => c.ExpirationDate >= expiresAfter);
            }
            if (!string.IsNullOrEmpty(filter.IsInactive.ToString()))
            {
                cards = cards.FindAll(c => c.IsInactive == filter.IsInactive);
            }
            if (!string.IsNullOrEmpty(filter.SortBy))
            {
                switch (filter.SortBy.ToLower())
                {
                    case "date":
                        cards = cards.OrderByDescending(card => card.ExpirationDate).ToList();
                        break;
                    case "cardholder":
                        cards = cards.OrderByDescending(card => card.CardHolder).ToList();
                        break;
                    default:
                        break;
                }
            }
            if (!string.IsNullOrEmpty(filter.SortOrder))
            {
                switch (filter.SortOrder.ToLower())
                {
                    case "asc":
                        cards.Reverse();
                        break;
                    default:
                        break;
                }
            }
            return cards;
        }

        public Card GetById(int id)
        {
            Card card = GetAll().FirstOrDefault(c => c.Id == id);
            return card ?? throw new EntityNotFoundException(Alerts.NoItemToShow);
        }

        public Card GetByNumber(string number)
        {
            Card card = GetAll().FirstOrDefault(c => c.Number == number);
            return card ?? throw new EntityNotFoundException(Alerts.NoItemToShow);
        }

        public IQueryable<Card> GetByUser(User user)
        {
            IQueryable<Card> cards = context.Cards
                                                .Where(c => !c.IsInactive && c.UserId == user.Id)
                                                .Include(c => c.User);
            return cards ?? throw new EntityNotFoundException(Alerts.NoItemToShow);
        }

        public Card Remove(int id)
        {
            Card cardToDelete = GetById(id);
            Deactivate(cardToDelete);
            this.context.SaveChanges();
            return cardToDelete;
        }

        public void CheckForExistingCardName(Card card, User user)
        {
			List<Card> cards = context.Cards.Where(c => c.UserId == user.Id).ToList();
			foreach (Card c in cards)
			{
				if (c.Name == card.Name)
				{
					throw new DuplicateEntityException(Alerts.CardNameAlreadyExists);
				}
			}
		}

        public void CheckExpirationDate(Card card)
        {
            DateTime defaultDate = DateTime.MinValue;
			if (card.ExpirationDate.AddMonths(1) < DateTime.Now && card.ExpirationDate != defaultDate)
			{
				throw new CardAlreadyExpired(Alerts.CardAlreadyExpired);
			}
		}

        public void Deactivate(Card card)
        {
            card.IsInactive = true;
        }
	}
}
