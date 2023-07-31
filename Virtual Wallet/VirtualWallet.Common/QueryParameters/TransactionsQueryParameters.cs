using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        [RegularExpression(@"((0[1-9]|[1-2][0-9]|3[0-1])-(0[1-9]|1[0-2])-[0-9]{4})|((0[1-9]|1[0-2])-[0-9]{4})", ErrorMessage = "Incorrect date format!")]
        public string? FilterByDate { get; set; }


    }
}
