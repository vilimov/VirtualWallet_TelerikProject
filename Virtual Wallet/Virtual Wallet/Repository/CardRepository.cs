namespace Virtual_Wallet.Repository
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
            this.context.Cards.Add(card);
            context.SaveChanges();

            return card;
        }

        public IQueryable<Card> FilterCardsBy(CardQueryParameters queryParameters)
        {
            //ToDo
            throw new NotImplementedException();
        }

        public IQueryable<Card> GetAll()
        {
            IQueryable<Card> cards = context.Cards
                                                .Include(c => c.User);
            return cards ?? throw new EntityNotFoundException("No cards found!");
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
