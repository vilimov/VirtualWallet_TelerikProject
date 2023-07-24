namespace Virtual_Wallet.Models.QueryParameters
{
    public class CardQueryParameters
    {
        public string CardHolder { get; set; }
        public string Username { get; set; }
        public bool IsCredit { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string SortBy { get; set; }
        public string SortOrder { get; set; }
    }
}
