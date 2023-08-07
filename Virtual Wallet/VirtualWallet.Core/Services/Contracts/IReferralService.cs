using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualWallet.Application.Services.Contracts
{
    internal interface IReferralService
    {
        string GenerateAndSaveReferral(int referrerUserId, string referredEmail);
        bool IsValidReferral(string referralLink);
        void CompleteReferral(string referralLink);
    }
}
