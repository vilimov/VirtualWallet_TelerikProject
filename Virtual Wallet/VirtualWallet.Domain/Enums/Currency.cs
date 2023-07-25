using System.ComponentModel;

namespace Virtual_Wallet.VirtualWallet.Domain.Enums
{
    public enum Currency
    {
        [Description("Bulgarian Lev")] BGN = 1,
        [Description("Euro")] EUR = 2,
        [Description("United States Dollar")] USD = 3
    }
}