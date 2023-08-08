using System.ComponentModel.DataAnnotations;
using Virtual_Wallet.Models.Dtos;
using Virtual_Wallet.VirtualWallet.Domain.Entities;
using Virtual_Wallet.VirtualWallet.Domain.Enums;
using VirtualWallet.Domain.Enums;

namespace Virtual_Wallet.Models.ViewModels
{
    public class TransactionViewModel
    {
        public int Id { get; set; }
        public TransactionType TransactionType { get; set; }
        public DateTime Date { get; set; }

        [DataType(DataType.Currency)]
        public decimal Amount { get; set; }
        public string Description { get; set; }
        public User Sender { get; set; }
        public User Recipient { get; set; }
        public string? CardNumber { get; set; }

        [DataType(DataType.Currency)]
        public decimal? AmountReceived { get; set; }
        public double? CurrencyExchangeRate { get; set; }
        public Currency? SenderWalletCurrency { get; set; }
        public Currency? RecipientWalletCurrency { get; set; }

    }
}
