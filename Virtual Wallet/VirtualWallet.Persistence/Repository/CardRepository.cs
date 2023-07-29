using Microsoft.EntityFrameworkCore;
using Virtual_Wallet.VirtualWallet.Common.Exceptions;
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
            if (card.ExpirationDate.AddMonths(1) <= DateTime.Now)
            {
                throw new CardAlreadyExpired(Alerts.CardAlreadyExpired);
            }

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

       /* public IQueryable<Card> FilterCardsBy(CardQueryParameters queryParameters)
        {
            //ToDo
            throw new NotImplementedException();
        }*/

        public IQueryable<Card> GetAll()
        {
            IQueryable<Card> cards = context.Cards
                                                .Where(c => !c.IsInactive)
                                                .Include(c => c.User);
            return cards ?? throw new EntityNotFoundException(Alerts.NoItemToShow);
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

        public void Deactivate(Card card)
        {            
            card.IsInactive = true;
        }

    }
}
