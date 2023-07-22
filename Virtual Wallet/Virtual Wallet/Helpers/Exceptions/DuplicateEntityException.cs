namespace Virtual_Wallet.Helpers.Exceptions
{
	public class DuplicateEntityException : ApplicationException
	{
		public DuplicateEntityException(string message)
			: base(message)
		{
		}
	}
}
