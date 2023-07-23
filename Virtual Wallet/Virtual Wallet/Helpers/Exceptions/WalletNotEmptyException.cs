namespace Virtual_Wallet.Helpers.Exceptions
{
    public class WalletNotEmptyException : ApplicationException
    {
        public WalletNotEmptyException(string message) : base(message) { }
    }
}
