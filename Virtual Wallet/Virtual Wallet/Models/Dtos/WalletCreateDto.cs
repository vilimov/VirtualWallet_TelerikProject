using Microsoft.AspNetCore.Mvc;

namespace Virtual_Wallet.Models.Dtos
{
    public class WalletCreateDto
    {
        [Required]
        [Range(1, 3)]
        public Currency Currency { get; set; }

        public decimal Balance { get; set; } = 0;

    }
}
