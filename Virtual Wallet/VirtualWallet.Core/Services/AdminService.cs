using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Virtual_Wallet.VirtualWallet.Common.Exceptions;
using Virtual_Wallet.VirtualWallet.Domain.Entities;
using Virtual_Wallet.VirtualWallet.Persistence.Repository;
using Virtual_Wallet.VirtualWallet.Persistence.Repository.Contracts;
using VirtualWallet.Application.Services.Contracts;

namespace VirtualWallet.Application.Services
{
    public class AdminService : IAdminService
    {

        private readonly IUserRepository userRepository;

        public AdminService(IUserRepository userRepository, IAdminService adminService) 
        {
            this.userRepository = userRepository;
        }

        public void PromoteToAdmin(int userId, User currentUser)
        {
            if (!currentUser.IsAdmin)
            {
                throw new UnauthorizedAccessException("Only admins can promote users to admin status.");
            }

            var userToPromote = userRepository.GetUserById(userId);

            if (userToPromote == null)
            {
                throw new EntityNotFoundException($"User with id {userId} does not exist.");
            }

            userToPromote.IsAdmin = true;

            userRepository.UpdateUser(userToPromote);
        }

        public void DemoteFromAdmin(int userId, User currentUser)
        {
            if (!currentUser.IsAdmin)
            {
                throw new UnauthorizedAccessException("Only admins can demote users from admin status.");
            }

            var userToDemote = userRepository.GetUserById(userId);

            if (userToDemote == null)
            {
                throw new EntityNotFoundException($"User with id {userId} does not exist.");
            }

            userToDemote.IsAdmin = false;

            userRepository.UpdateUser(userToDemote);
        }
        public void BlockUser(int id)
        {
            var user = userRepository.GetUserById(id);
            if (user == null)
            {
                throw new EntityNotFoundException("Not found");
            }

            user.IsBlocked = true;
            userRepository.UpdateUser(user);
        }

        public void UnblockUser(int id)
        {
            var user = userRepository.GetUserById(id);
            if (user == null)
            {
                throw new EntityNotFoundException("Not found");
            }

            user.IsBlocked = false;
            userRepository.UpdateUser(user);
        }
    }
}
