using Virtual_Wallet.VirtualWallet.Common.QueryParameters;
using Virtual_Wallet.VirtualWallet.Domain.Entities;

namespace VirtualWallet.Application.Services.Contracts
{
    public interface ICardService
    {
        IEnumerable<Card> GetAll();
        IEnumerable<Card> GetAll(int pageNumber, int pageSize, string search = null);
		IEnumerable<Card> GetFilteredCards(CardQueryParameters filter);
        int GetCardsCount(string search = null);
		Card GetById(int id);
        Card GetByNumber(string number);
        IEnumerable<Card> GetByUser(User user);
        Card Add(Card card, User user);
        Card Update(Card card, User user, int id);
		Card Remove(int id);
    }
}
