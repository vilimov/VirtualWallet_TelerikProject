﻿using System.ComponentModel.DataAnnotations;

namespace Virtual_Wallet.VirtualWallet.Common.QueryParameters
{
    public class CardQueryParameters
    {
        public bool? IsCredit { get; set; }

        [RegularExpression(@"(0[1-9]|1[0-2])[0-9][0-9]", ErrorMessage = "Incorrect date format!")]
        public DateTime? ExpiresBefore { get; set; }

        [RegularExpression(@"(0[1-9]|1[0-2])[0-9][0-9]", ErrorMessage = "Incorrect date format!")]
        public DateTime? ExpiresAfter { get; set; }

        public bool? IsInactive { get; set; }
        public string? SortBy { get; set; }
        public string? SortOrder { get; set; }
    }
}