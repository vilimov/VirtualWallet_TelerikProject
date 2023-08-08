namespace Virtual_Wallet.Models.ViewModels.Admin
{
    public class UserAdminViewModel
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsBlocked { get; set; }
        public bool IsDeleted { get; set; }

    }
}
