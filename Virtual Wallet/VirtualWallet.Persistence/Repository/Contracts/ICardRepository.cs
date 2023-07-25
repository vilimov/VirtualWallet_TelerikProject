using Virtual_Wallet.VirtualWallet.Domain.Entities;

namespace Virtual_Wallet.VirtualWallet.Persistence.Repository.Contracts
{
    public interface ICardRepository
    {
        IQueryable<Card> GetAll();
        Card GetById(int id);
        Card GetByUserId(int id);
        //IQueryable<Card> FilterCardsBy(CardQueryParameters queryParameters);
        Card Add(Card card);
        Card Remove(Card card);
    }
}
