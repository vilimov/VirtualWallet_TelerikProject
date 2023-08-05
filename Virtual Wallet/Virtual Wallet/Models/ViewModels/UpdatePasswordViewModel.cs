using System.ComponentModel.DataAnnotations;

namespace Virtual_Wallet.Models.ViewModels
{
    public class UpdatePasswordViewModel
    {
        [Required(ErrorMessage = "Current password field is required.")]
        [DataType(DataType.Password)]
        [Display(Name = "Current Password")]
        public string CurrentPassword { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "The new password field is required.")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*\W).{8,}$", ErrorMessage = "Password needs 8+ chars, a lower and upper case, a digit, and a symbol.")]
        [MaxLength(20, ErrorMessage = "The {0} field must be less than {1} characters.")]
        [DataType(DataType.Password)]
        [Display(Name = "New Password")]
        public string NewPassword { get; set; }

        [Required(ErrorMessage = "Confirm password field is required.")]
		[DataType(DataType.Password)]
		[Display(Name = "Confirm Password")]
		[Compare("NewPassword", ErrorMessage = "Passwords do not match.")]
        public string ConfirmPassword { get; set; }
    }
}
