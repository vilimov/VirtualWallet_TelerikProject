using Microsoft.EntityFrameworkCore;
using Virtual_Wallet.VirtualWallet.Common.Exceptions;
using Virtual_Wallet.VirtualWallet.Domain.Entities;
using Virtual_Wallet.VirtualWallet.Persistence.Data;
using Virtual_Wallet.VirtualWallet.Persistence.Repository.Contracts;

namespace Virtual_Wallet.VirtualWallet.Persistence.Repository
{
    public class CardRepository : ICardRepository
    {
        private readonly WalletContext context;
        public CardRepository(WalletContext context)
        {
            this.context = context;
        }

        public Card Add(Card card)
        {
            Card inactiveCard = context.Cards.FirstOrDefault(c => c.Number == card.Number);
            
            if (inactiveCard != null)
            {
                inactiveCard.IsInactive = false;
            }
            else
            {

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
            return cards ?? throw new EntityNotFoundException("No cards found!");
        }

        public Card GetById(int id)
        {
            Card card = GetAll().FirstOrDefault(c => c.Id == id);
            return card ?? throw new EntityNotFoundException($"No card with Id:{id} found");
        }
        public Card GetByUserId(int id)
        {
            throw new NotImplementedException();
        }

        public Card Remove(Card card)
        {
            throw new NotImplementedException();
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
