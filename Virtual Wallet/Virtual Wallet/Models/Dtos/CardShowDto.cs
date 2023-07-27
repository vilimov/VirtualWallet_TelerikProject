using System.Globalization;
using System.Text.Json.Serialization;
using Virtual_Wallet.VirtualWallet.Domain.Entities;
using VirtualWallet.Common.AdditionalHelpers;

namespace Virtual_Wallet.VirtualWallet.API.Models.Dtos
{
    public class CardShowDto
    {
        public CardShowDto() { }


        public CardShowDto(Card card)
        {
            this.Number = card.Number;
            this.CardNumberHidden = CardHelper.HideCardNumber(Number);
            this.ExpirationDate = card.ExpirationDate;
            this.CardHolder = CardHelper.HideName(card.CardHolder);
            this.IsCreditCard = card.IsCreditCard;
            this.Username = card.User.Username;
        }
        [JsonIgnore]
        public string Number { get; set; }
        public string CardNumberHidden { get; set; }
        [JsonIgnore]
        public DateTime ExpirationDate { get; set; }
        public string ExpirationDateFormatted => ExpirationDate.ToString("MM/yy", CultureInfo.InvariantCulture);
        public string CardHolder { get; set; }
        public bool IsCreditCard { get; set; }
        [JsonIgnore]
        public string Username { get; set; }

    }
}
