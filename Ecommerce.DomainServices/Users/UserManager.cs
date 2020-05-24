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
        private readonly IUserPermissionService _userPermissionService;

        public UserManager(IUserService userService, IUserPermissionService userPermissionService)
        {
            _userService = userService;
            _userPermissionService = userPermissionService;
        }

        public async Task<User> GetUseInfoAsync(Guid userId)
        {
            _userPermissionService.AssertAccess(UserAccess.CanView);
            return await _userService.GetUseInfoAsync(userId);
        }

        public async Task UpdateUserAsync(UpdateUserModel model)
        {
            _userPermissionService.AssertAccess(UserAccess.CanEdit);
            await _userService.UpdateUserAsync(model);
        }
    }
}
