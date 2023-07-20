﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Transactions;

namespace Virtual_Wallet.Models
{
	public class User
	{
		public int Id { get; set; }

		[Required(AllowEmptyStrings = false, ErrorMessage = "The {0} field is required and must not be empty.")]
		[MinLength(2, ErrorMessage = "The {0} field must be at least {1} characters.")]
		[MaxLength(20, ErrorMessage = "The {0} field must be less than {1} characters.")]
		public string Username { get; set; }

		[Required(AllowEmptyStrings = false, ErrorMessage = "The {0} field is required and must not be empty.")]
		[MaxLength(170)]
		[DataType(DataType.Password)]
		[Display(Name = "Password")]
		public string Password { get; set; }

		[DataType(DataType.Password)]
		[Display(Name = "Confirm password")]
		[Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
		public string ConfirmPassword { get; set; }

		[Required(ErrorMessage = "The {0} field is required.")]
		[RegularExpression(@"^([a-zA-Z0-9-.]+)@(([[0-9]{1,3}.[0-9]{1,3}.[0-9]{1,3}.)|(([a-zA-Z0-9-]+.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(]?)$", ErrorMessage = "Please enter a valid e-mail address")]
		public string Email { get; set; }

		
		[StringLength(10, MinimumLength = 10)]
		public string PhoneNumber { get; set; }

		public string Photo { get; set; }

		public bool IsAdmin { get; set; }

		public bool IsBlocked { get; set; }

		public ICollection<Card> Cards { get; set; }

		public ICollection<Transaction> Transactions { get; set; }
	}

}
