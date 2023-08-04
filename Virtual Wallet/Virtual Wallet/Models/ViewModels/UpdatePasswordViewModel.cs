using System.ComponentModel.DataAnnotations;

namespace Virtual_Wallet.Models.ViewModels
{
    public class UpdatePasswordViewModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "The {0} field is required and must not be empty.")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*\W).{8,}$", ErrorMessage = "Password needs 8+ chars, a lower and upper case, a digit, and a symbol.")]
        [MaxLength(20, ErrorMessage = "The {0} field must be less than {1} characters.")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string NewPassword { get; set; }
        [Required(ErrorMessage = "Confirm password is required.")]
        [Compare("Password", ErrorMessage = "Passwords do not match.")]
        public string NewConfirmPassword { get; set; }
    }
}
