namespace Virtual_Wallet.Models.ViewModels.UserProfileUpdate
{
    public class UpdateAvatarViewModel
    {
        public string Username { get; set; }
        public IFormFile NewProfilePicture { get; set; }
        public string CurrentImage { get; set; }
    }
}
