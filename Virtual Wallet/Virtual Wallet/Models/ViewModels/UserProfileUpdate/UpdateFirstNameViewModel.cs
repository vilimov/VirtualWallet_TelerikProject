using System.ComponentModel.DataAnnotations;

namespace Virtual_Wallet.Models.ViewModels
{
    public class UpdateFirstNameViewModel
    {
        public string CurrentFirstName { get; set; }
        [Required(ErrorMessage = "First name field is required.")]
		[MaxLength(32, ErrorMessage = "The {0} field must be less than {1} characters.")]
        public string NewFirstName { get; set; }
    }
}
