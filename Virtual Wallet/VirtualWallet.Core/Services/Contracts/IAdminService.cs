using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Virtual_Wallet.VirtualWallet.Domain.Entities;

namespace VirtualWallet.Application.Services.Contracts
{
    public interface IAdminService
    {
        void PromoteToAdmin(int userId, User currentUser);
        void DemoteFromAdmin(int userId, User currentUser);
        void BlockUser(int id);
        void UnblockUser(int id);
    }
}
