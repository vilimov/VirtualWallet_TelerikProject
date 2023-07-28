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
    }
}
