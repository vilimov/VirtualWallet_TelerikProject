using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualWallet.Common.AdditionalHelpers
{
	public class CardHelper
	{
		public static string HideCardNumber(string cardNumber)
		{
			int visibleDigits = 4;
			int totalDigits = cardNumber.Length;
			int hiddenDigits = totalDigits - visibleDigits;

			string hiddenPart = new string('*', hiddenDigits);
			string visiblePart = cardNumber.Substring(hiddenDigits);

			return hiddenPart + visiblePart;
		}

		public static string HideName(string username)
		{
			string hiddenName = string.Empty;

			for (int i = 0; i < username.Length; i++)
			{
				if (
					i == 0 ||
					i == 1 ||
					i == username.Length - 2 ||
					i == username.Length - 1)
				{
					hiddenName += username[i];
				}
				else
				{
					hiddenName += "*";
				}
			}
			return hiddenName;
		}
	}
}
