using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualWallet.Common.AdditionalHelpers
{
    public static class Alerts
    {
        public const string UserNotFound = "User with {0} {1} does not exist!";
        public const string InvalidCredentials = "Invalid Credentials!";
        public const string UserNotVerified = "You are not verified! Please check your mail for verification link.";
        public const string ItemNotFound = "Item not found.";
        public const string InvalidAttenpt = "Invalid attempt!";
        public const string NoItemToShow = "No item to show";
        public const string NotFound = "{0} with {1} {2} not found.";
        public const string InsufficientAmount = "Insufficient Amount!";
        public const string BlockedUser = "Access Denied - User Account Blocked!";
        public const string FailedCurrencyRate = "Failed to fetch exchange rates from the API.";
        public const string MoneyToYourself = "You are trying to send money to yourself.";
        public const string NotAutorised  = "You are not autorised for this service!";
        public const string ExistingWallet  = "You are not allowed to have more than one wallet!";
        public const string WalletNotEmpty  = "This wallet's balance is {0} and has {1} blocked! Wallet must be empty in order to be deleted!";
        public const string CardAlreadyExpired  = "Your card has already expired!";
        public const string CardAlreadyAdded  = "Your card has already been added!";
    }
}
