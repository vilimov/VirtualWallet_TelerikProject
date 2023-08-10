using System.ComponentModel;
using System.Reflection;

namespace Virtual_Wallet.VirtualWallet.Domain.Enums
{
	public static class EnumHelper
	{
		public static string GetEnumDescription(Enum value)
		{
			FieldInfo field = value.GetType().GetField(value.ToString());
			if (field == null)
			{
				return value.ToString();
			}

			DescriptionAttribute attribute = field.GetCustomAttribute<DescriptionAttribute>();

			return attribute?.Description ?? value.ToString();
		}
	}
}
