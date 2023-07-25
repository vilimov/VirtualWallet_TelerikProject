using Virtual_Wallet.VirtualWallet.Core.Entities;

namespace Virtual_Wallet.VirtualWallet.Core.Services.Contracts
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
