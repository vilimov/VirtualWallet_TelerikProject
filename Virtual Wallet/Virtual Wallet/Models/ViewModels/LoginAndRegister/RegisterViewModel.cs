using System.ComponentModel.DataAnnotations;

namespace Virtual_Wallet.Models.ViewModels.LoginAndRegister
{
    public class RegisterViewModel
    {
        [Required]
        [StringLength(20, MinimumLength = 2)]
        public string Username { get; set; }

        [Required(ErrorMessage = "The {0} field is required.")]
        [RegularExpression(@"^([a-zA-Z0-9-.]+)@(([[0-9]{1,3}.[0-9]{1,3}.[0-9]{1,3}.)|(([a-zA-Z0-9-]+.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(]?)$", ErrorMessage = "Please enter a valid e-mail address")]
        public string Email { get; set; }

        [MaxLength(32, ErrorMessage = "The {0} field must be less than {1} characters.")]
        public string FirstName { get; set; }

        [MaxLength(32, ErrorMessage = "The {0} field must be less than {1} characters.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Phone number is required.")]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "Phone number must be exactly 10 digits.")]
        public string Phone { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "The {0} field is required and must not be empty.")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*\W).{8,}$", ErrorMessage = "Password needs 8+ chars, a lower and upper case, a digit, and a symbol.")]
        [MaxLength(20, ErrorMessage = "The {0} field must be less than {1} characters.")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirm password is required.")]
        [Compare("Password", ErrorMessage = "Passwords do not match.")]
        public string ConfirmPassword { get; set; }
    }
}
