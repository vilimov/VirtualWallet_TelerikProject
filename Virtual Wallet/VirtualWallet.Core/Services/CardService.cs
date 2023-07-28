using Virtual_Wallet.VirtualWallet.Domain.Entities;
using Virtual_Wallet.VirtualWallet.Persistence.Repository.Contracts;
using VirtualWallet.Application.Services.Contracts;

namespace Virtual_Wallet.VirtualWallet.Application.Services
{
    public class CardService : ICardService
    {
        private readonly ICardRepository cardRepository;

        public CardService(ICardRepository cardRepository) 
        {
            this.cardRepository = cardRepository;
        }

        public Card Add(Card card, User user)
        {
            Card createdCard = this.cardRepository.Add(card, user);
            return createdCard;
        }

        /*public IEnumerable<Card> FilterCardsBy(CardQueryParameters queryParameters)
        {
            throw new NotImplementedException();
        }*/

        public IEnumerable<Card> GetAll()
        {
            IEnumerable<Card> cards = this.cardRepository.GetAll();
            return cards;

        }

        public Card GetById(int id)
        {
            Card card = this.cardRepository.GetById(id);
            return card;
        }

        public Card GetByNumber(string number)
        {
            Card card = cardRepository.GetByNumber(number);
            return card;
        }

        public Card GetByUserId(int id)
        {
            throw new NotImplementedException();
        }

        public Card Remove(int id)
        {
            Card removedCard = this.cardRepository.Remove(id);
            return removedCard;
        }
    }
}
