using System.ComponentModel.DataAnnotations;

namespace Virtual_Wallet.Models.Dtos
{
    public class CreateBankTransactionDto
    {
        [Required]
        [DataType(DataType.Currency)]
        public decimal Amount { get; set; }

        [Required]
        public int CardId { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "The {0} field is required and must not be an empty string.")]
        [MinLength(6, ErrorMessage = "The {0} field must be at least {1} characters.")]
        public string Description { get; set; }
    }
}
