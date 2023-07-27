using Virtual_Wallet.VirtualWallet.Domain.Entities;
using VirtualWallet.Domain.Enums;

namespace Virtual_Wallet.Models.Dtos
{
    public class TransactionShowDto
    {
        public TransactionType TransactionType { get; set; }
        public DateTime Date { get; set; }
        public User Sender { get; set; }
        public User Recipient { get; set; }

    }
}
