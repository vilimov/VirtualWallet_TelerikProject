namespace Virtual_Wallet.VirtualWallet.Common.Exceptions
{
    public class WalletNotEmptyException : ApplicationException
    {
        public WalletNotEmptyException(string message) : base(message) { }
    }
}
