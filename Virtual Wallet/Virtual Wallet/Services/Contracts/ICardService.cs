namespace Virtual_Wallet.Services.Contracts
{
    public interface ICardService
    {
        IEnumerable<Card> GetAll();
        Card GetById(int id);
        Card GetByUserId(int id);
        IEnumerable<Card> FilterCardsBy(CardQueryParameters queryParameters);
        Card Add(Card card);
        Card Remove(Card card);
    }
}
