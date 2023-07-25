using System.Globalization;
using System.Text.Json.Serialization;
using Virtual_Wallet.VirtualWallet.Domain.Entities;

namespace Virtual_Wallet.VirtualWallet.API.Models.Dtos
{
    public class CardShowDto
    {
        public CardShowDto() { }


        public CardShowDto(Card card)
        {
            this.Number = card.Number;
            this.CardNumberHidden = HideCardNumber(Number);
            this.ExpirationDate = card.ExpirationDate;
            this.CardHolder = HideName(card.CardHolder);
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

        private string HideCardNumber(string cardNumber)
        {
            // Keep only the last 4 digits of the card number and replace the rest with "*"
            int visibleDigits = 4;
            int totalDigits = cardNumber.Length;
            int hiddenDigits = totalDigits - visibleDigits;

            string hiddenPart = new string('*', hiddenDigits);
            string visiblePart = cardNumber.Substring(hiddenDigits);

            return hiddenPart + visiblePart;
        }

        private string HideName(string username)
        {
            string hiddenName = string.Empty;
            for (int i = 0; i < username.Length; i++) 
            {
                if (i == 0 || i == 1 || i == username.Length - 2 || i == username.Length - 1)
                {
                    hiddenName += username[i];
                }
                else 
                {
                    hiddenName += "*";
                }
            }
            return hiddenName;
        }
    }
}
