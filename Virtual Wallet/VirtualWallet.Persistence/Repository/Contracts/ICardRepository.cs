using Virtual_Wallet.VirtualWallet.Common.QueryParameters;
using Virtual_Wallet.VirtualWallet.Domain.Entities;

namespace Virtual_Wallet.VirtualWallet.Persistence.Repository.Contracts
{
    public interface ICardRepository
    {
        IQueryable<Card> GetAll();
        IList<Card> GetFilteredCards(CardQueryParameters filter);
        Card GetById(int id);
        Card GetByNumber(string number);
        IQueryable<Card> GetByUser(User user);
        Card Add(Card card, User user);
		Card Update(Card card, User user, int id);
		Card Remove(int id);
    }
}
