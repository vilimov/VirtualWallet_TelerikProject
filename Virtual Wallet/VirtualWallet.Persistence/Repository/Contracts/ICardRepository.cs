using Virtual_Wallet.VirtualWallet.Domain.Entities;

namespace Virtual_Wallet.VirtualWallet.Persistence.Repository.Contracts
{
    public interface ICardRepository
    {
        IQueryable<Card> GetAll();
        Card GetById(int id);
        Card GetByNumber(string number);
        //IQueryable<Card> FilterCardsBy(CardQueryParameters queryParameters);
        Card Add(Card card, User user);
        Card Remove(int id);
    }
}
