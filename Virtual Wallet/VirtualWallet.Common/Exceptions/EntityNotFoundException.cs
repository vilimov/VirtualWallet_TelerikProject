﻿namespace Virtual_Wallet.VirtualWallet.Common.Exceptions
{
	public class EntityNotFoundException : ApplicationException
	{
		public EntityNotFoundException(string message)
			: base(message)
		{
		}
	}
}
