using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualWallet.Common.QueryParameters
{
    public class TransactionsQueryParameters
    {
        public string? AllMyTransactions { get; set; }   //When user is Sender or Recipient
        public string? Sender { get; set; }              //When user is Sender
        public string? Reciever { get; set; }              //When user is Recipient
        public string? Withdrawl { get; set; }              //When Withdrawl
        public string? FeedWallet { get; set; }              //When user sends money to wallet from card


    }
}
