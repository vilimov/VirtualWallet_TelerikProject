namespace Virtual_Wallet.VirtualWallet.Common.Exceptions
{
	public class UsernameNotFoundException : ApplicationException
    {
		public UsernameNotFoundException(string message)
			: base(message)
		{
		}
	}
}
