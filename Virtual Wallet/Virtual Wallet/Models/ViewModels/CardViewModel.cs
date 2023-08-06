using Virtual_Wallet.VirtualWallet.API.Models.Dtos;
using Virtual_Wallet.VirtualWallet.Domain.Entities;
using VirtualWallet.Common.AdditionalHelpers;

namespace Virtual_Wallet.Models.ViewModels
{
	public class CardViewModel : CardShowDto
	{
		public CardViewModel(Card card)
		{
			this.Name = card.Name;
			this.Number = card.Number;
			this.CardNumberHidden = CardHelper.HideCardNumber(Number);
			this.ExpirationDate = card.ExpirationDate;
			this.CardHolder = CardHelper.HideName(card.CardHolder);
			this.CurrencyCode = card.CurrencyCode.ToString();
			this.IsCreditCard = card.IsCreditCard;
			this.Username = card.User.Username;
		}
		public string CardTypeToString
		{
			get
			{
				return this.IsCreditCard == true ? "Credit" : "Debit";
			}
			set { }
		}
	}
}
