﻿namespace Virtual_Wallet.Models.ViewModels
{
    public class UpdateAvatarViewModel
    {
        public string Username { get; set; }
        public IFormFile NewProfilePicture { get; set; }
        public string CurrentImage { get; set; }
    }
}
