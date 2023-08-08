namespace Virtual_Wallet.Models.ViewModels.Admin
{
    public class DashboardViewModel
    {
        public int PageNumber { get; set; } 
        public int TotalPages { get; set; } 
        public int PageSize { get; set; } 

        public List<UserAdminViewModel> Users { get; set; }

        public string Search { get; set; }
        public bool ShowPrevious => PageNumber > 1;
        public bool ShowNext => PageNumber < TotalPages;

    }
}
