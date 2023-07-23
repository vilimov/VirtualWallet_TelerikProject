﻿using Virtual_Wallet.Repository.Contracts;

namespace Virtual_Wallet.Repository
{
    public class WalletRepository : IWalletRepository
    {
        private readonly WalletContext context;

        public WalletRepository(WalletContext context)
        {
            this.context = context;
        }
        public Wallet CreateWallet(Wallet wallet)
        {
            this.context.Wallets.Add(wallet);
            context.SaveChanges();

            return wallet;
        }

        public IEnumerable<Wallet> GetAll()
        {
            IEnumerable<Wallet> result = context.Wallets
                           .Include(w => w.User);
            return result.ToList() ?? throw new EntityNotFoundException("No wallets were found");
        }

        public Wallet GetWalletById(int id)
        {
            Wallet wallet = GetAll().FirstOrDefault(w => w.Id == id);
            return wallet ?? throw new EntityNotFoundException($"Wallet with Id: {id} does not exist!");
        }

        public Wallet GetWalletByUser(string username)
        {
            Wallet wallet = GetAll().FirstOrDefault(w => w.User.Username == username);
            return wallet ?? throw new EntityNotFoundException($"User with Username: {username} does not have a wallet");
        }

        public decimal GetBalance(int id)
        {
            return GetWalletById(id).Balance;
        }

        public Currency GetCurrencyById(int id)
        {
            return GetWalletById(id).CurrencyCode;
        }

        public decimal AddToWallet(int id, decimal amount)
        {
            Wallet wallet = GetWalletById(id);
            wallet.Balance += amount;
            context.SaveChanges();
            return wallet.Balance;
        }

        public decimal WithdrawFromWallet(int id, decimal amount)
        {
            Wallet wallet = GetWalletById(id);
            if (wallet.Balance < amount)
            {
                throw new InsuficientAmountException($"Insufficient amount!");
            }

            wallet.Balance -= amount;
            context.SaveChanges();
            return wallet.Balance;
        }

        public decimal Block (int id, decimal amount)
        {
            Wallet wallet = GetWalletById(id);
            if (wallet.Balance < amount)
            {
                throw new InsuficientAmountException($"Insufficient amount!");
            }

            wallet.Balance -= amount;
            wallet.Blocked += amount;
            context.SaveChanges();
            return wallet.Balance;
        }

        public decimal ReleaseBlocked(int id, decimal amount)
        {
            Wallet wallet = GetWalletById(id);
            if (wallet.Blocked < amount)
            {
                throw new InsuficientAmountException($"Insufficient amount!");
            }

            wallet.Blocked -= amount;
            context.SaveChanges();
            return wallet.Balance;
        }

        public decimal Unblock(int id, decimal amount)
        {
            Wallet wallet = GetWalletById(id);
            wallet.Balance += amount;
            context.SaveChanges();
            return wallet.Balance;
        }

        public Wallet Delete(int id)
        {
            Wallet deletedWallet = GetWalletById(id);
            if (deletedWallet.Balance > 0 || deletedWallet.Blocked > 0)
            {
                string balance = $"{deletedWallet.Balance.ToString("F2")} {deletedWallet.CurrencyCode.ToString()}";
                string blocked = $"{deletedWallet.Blocked.ToString("F2")} {deletedWallet.CurrencyCode.ToString()}";
                throw new WalletNotEmptyException($"This wallet's balance is {balance} and has {blocked} blocked! Wallet must be empty in order to be deleted");
            }
            context.Wallets.Remove(deletedWallet);
            context.SaveChanges();
            return deletedWallet;
        }
    }
}