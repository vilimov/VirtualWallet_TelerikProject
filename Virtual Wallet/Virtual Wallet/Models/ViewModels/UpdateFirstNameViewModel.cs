using System.ComponentModel.DataAnnotations;

namespace Virtual_Wallet.Models.ViewModels
{
    public class UpdateFirstNameViewModel
    {
        [Required]
        [MaxLength(32, ErrorMessage = "The {0} field must be less than {1} characters.")]
        public string NewFirstName { get; set; }
    }
}
