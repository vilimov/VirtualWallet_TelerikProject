using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Virtual_Wallet.VirtualWallet.Domain.Enums;

namespace VirtualWallet.Persistence.QueryParameters
{
	public class WalletQueryParameters
	{
		public string? Username { get; set; }
		public Currency? CurrencyCode { get; set; }
		public decimal? BallanceLessThan { get; set; }
		public decimal? BallanceMoreThan { get; set; }
		public decimal? BlockedLessThan { get; set; }
		public decimal? BlockedMoreThan { get; set; }
		public bool? IsInactive { get; set; }
		public string? SortBy { get; set; }
		public string? SortOrder { get; set; }
	}
}
