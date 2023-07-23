using Microsoft.OpenApi.Extensions;

namespace Virtual_Wallet.Models.Dtos
{
    public class WalletShowDto
    {
        public WalletShowDto()
        {
        }

        public WalletShowDto(Wallet walletModel)
        {
            Username = walletModel.User.Username;
            Ballance = walletModel.Balance.ToString("F2");
            Blocked = walletModel.Blocked.ToString("F2");
            CurrencyCode = walletModel.CurrencyCode.ToString();
            CurrencyDescription = EnumHelper.GetEnumDescription(walletModel.CurrencyCode);
        }

        public string Username { get; set; }
        public string Ballance { get; set; }
        public string Blocked { get; set; }
        public string CurrencyCode { get; set; }
        public string CurrencyDescription { get; set; }

    }
}
