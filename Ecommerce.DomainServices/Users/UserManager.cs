using Ecommerce.Core.Users;
using Ecommerce.Core.Users.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.DomainServices.Users
{
    public class UserManager : IUserManager
    {
        private readonly IUserService _userService;

        public UserManager(IUserService userService)
        {
            _userService = userService;
        }
        public async Task<User> GetUseInfoAsync(Guid userId)
        {
            //TODO: Permission check
            return await _userService.GetUseInfoAsync(userId);
        }

        public async Task UpdateUserAsync(UpdateUserModel model)
        {
            //TODO: Permission check
            await _userService.UpdateUserAsync(model);
        }
    }
}
