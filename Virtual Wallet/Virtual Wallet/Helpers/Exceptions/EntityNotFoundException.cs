namespace Virtual_Wallet.Helpers.Exceptions
{
	public class EntityNotFoundException : ApplicationException
	{
		public EntityNotFoundException(string message)
			: base(message)
		{
		}
	}
}
