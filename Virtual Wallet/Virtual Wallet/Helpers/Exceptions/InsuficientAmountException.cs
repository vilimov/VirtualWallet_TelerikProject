namespace Virtual_Wallet.Helpers.Exceptions
{
    public class InsuficientAmountException : ApplicationException
    {
        public InsuficientAmountException(string message) : base(message) { }
    }
}
