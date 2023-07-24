namespace Virtual_Wallet.Services
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
            throw new NotImplementedException();
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
