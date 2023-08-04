using System.ComponentModel.DataAnnotations;

namespace Virtual_Wallet.Models.ViewModels
{
    public class UpdateLastNameViewModel
    {
        public string CurrentLastName { get; set; }    
        [Required]
        [MaxLength(32, ErrorMessage = "The {0} field must be less than {1} characters.")]
        public string NewLastName { get; set; }
    }
}
