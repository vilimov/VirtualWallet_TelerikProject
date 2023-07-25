namespace Virtual_Wallet.VirtualWallet.Common.Exceptions
{
    public class InsuficientAmountException : ApplicationException
    {
        public InsuficientAmountException(string message) : base(message) { }
    }
}
