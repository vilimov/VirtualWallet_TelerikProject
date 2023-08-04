using System.ComponentModel.DataAnnotations;

namespace Virtual_Wallet.Models.ViewModels
{
    public class UpdateLastNameViewMovel
    {
        [Required]
        [MaxLength(32, ErrorMessage = "The {0} field must be less than {1} characters.")]
        public string NewLastName { get; set; }
    }
}
