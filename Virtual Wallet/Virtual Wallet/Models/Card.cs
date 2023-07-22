using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Virtual_Wallet.Models
{
	public class Card
	{
		public int Id { get; set; }

		[Required]
		[StringLength(16, MinimumLength = 16)]
		public string Number { get; set; }

		[Required]
		public DateTime ExpirationDate { get; set; }
        //public string ExpirationDateFormatted => ExpirationDate.ToString("MM.yyyy");

        [Required]
		[StringLength(30, MinimumLength = 2)]
		public string CardHolder { get; set; }

		[Required]
		[StringLength(3, MinimumLength = 3)]
		public string CheckNumber { get; set; }

		[Required]
		public bool IsCreditCard { get; set; }

        [Required]
        public int? UserId { get; set; }

        [Required]
		public User User { get; set; }

	}

}
