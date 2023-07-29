using System.ComponentModel.DataAnnotations;
using System.Globalization;
using Virtual_Wallet.VirtualWallet.Domain.Entities;

namespace Virtual_Wallet.VirtualWallet.API.Models.Dtos
{
    public class CardAddDto
    {
        [Required]
        [StringLength(16, MinimumLength = 16)]
        [RegularExpression(@"\d*", ErrorMessage = "Incorrect card format!")]
        public string Number { get; set; }

        [Required]
        //[StringLength(4, MinimumLength = 4)]
        [RegularExpression(@"(0[1-9]|1[0-2])[0-9][0-9]", ErrorMessage = "Incorrect date format!")]
        public string? ExpireDateFormatted { get; set; }
                

        [Required]
        [StringLength(30, MinimumLength = 2)]
        public string CardHolder { get; set; }

        [Required]
        [StringLength(3, MinimumLength = 3)]
        [RegularExpression(@"\d*", ErrorMessage = "Incorrect check number format!")]
        public string CheckNumber { get; set; }

        [Required]
        public bool IsCreditCard { get; set; }
    }
}
