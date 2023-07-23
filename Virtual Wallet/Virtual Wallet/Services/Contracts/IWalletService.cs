namespace Virtual_Wallet.Services.Contracts
{
    public interface IWalletService
    {
        Wallet CreateWallet(Wallet wallet, User user);
        IEnumerable<Wallet> GetAll();
        Wallet GetWalletById(int id);
        Wallet GetWalletByUser(string username);
        decimal GetBalance(int id);
        Currency GetCurrencyById(int id);
        decimal AddToWallet(int id, decimal amount);
        decimal WithdrawFromWallet(int id, decimal amount);
        decimal Block(int id, decimal amount);
        decimal ReleaseBlocked(int id, decimal amount);
        decimal Unblock(int id, decimal amount);
        Wallet Delete(int id);
    }
}
