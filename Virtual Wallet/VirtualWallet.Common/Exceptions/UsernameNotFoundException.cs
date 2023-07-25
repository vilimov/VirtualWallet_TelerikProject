namespace Virtual_Wallet.VirtualWallet.Common.Exceptions
{
	public class UsernameNotFoundException : Exception
	{
		public UsernameNotFoundException(string username)
			: base($"No user found with username {username}")
		{
		}
	}
}
