using System.ComponentModel.DataAnnotations;

namespace Virtual_Wallet.Models.ViewModels
{
    public class UpdatePhoneViewModel
    {
        public string CurrentPhoneNumber { get; set; }
        [Required]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "Phone number must be exactly 10 digits.")]
        public string NewPhoneNumber { get; set; }
    }
}
