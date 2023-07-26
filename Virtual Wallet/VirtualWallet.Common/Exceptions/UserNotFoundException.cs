namespace Virtual_Wallet.VirtualWallet.Common.Exceptions
{
	public class UserNotFoundException : ApplicationException
    {
		public UserNotFoundException(string message)
			: base(message)
		{
		}
	}
}
