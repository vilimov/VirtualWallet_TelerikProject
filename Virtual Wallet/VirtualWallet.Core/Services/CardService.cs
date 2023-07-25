using Virtual_Wallet.VirtualWallet.Core.Services.Contracts;

namespace Virtual_Wallet.VirtualWallet.Core.Services
{
    public class CardService : ICardService
    {
        private readonly ICardRepository cardRepository;

        public CardService(ICardRepository cardRepository) 
        {
            this.cardRepository = cardRepository;
        }

        public Card Add(Card card)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Card> FilterCardsBy(CardQueryParameters queryParameters)
        {
            throw new NotImplementedException();
        }

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

        public Card GetByUserId(int id)
        {
            throw new NotImplementedException();
        }

        public Card Remove(Card card)
        {
            throw new NotImplementedException();
        }
    }
}
