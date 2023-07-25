using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using Virtual_Wallet.VirtualWallet.Domain.Enums;

namespace Virtual_Wallet.VirtualWallet.API.Models.Dtos
{
    public class WalletCreateDto
    {
        [Required]
        [Range(1, 3)]
        public Currency Currency { get; set; }

        public decimal Balance { get; set; } = 0;

    }
}
