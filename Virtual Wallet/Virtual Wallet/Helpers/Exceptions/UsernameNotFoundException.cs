namespace Virtual_Wallet.Helpers.Exceptions
{
	public class UsernameNotFoundException : Exception
	{
		public UsernameNotFoundException(string username)
			: base($"No user found with username {username}")
		{
		}
	}
}
