namespace Virtual_Wallet.VirtualWallet.Common.Exceptions
{
	public class UserNotFoundException : Exception
	{
		public UserNotFoundException(int userId)
			: base($"No user found with id {userId}")
		{
		}
	}
}
