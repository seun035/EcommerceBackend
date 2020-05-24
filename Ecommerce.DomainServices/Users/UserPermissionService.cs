using Ecommerce.Core.Helpers;
using Ecommerce.Core.Users;
using Ecommerce.Core.Users.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.DomainServices.Users
{
    public class UserPermissionService : IUserPermissionService
    {
        private readonly IUserContext _userContext;

        public UserPermissionService(IUserContext userContext)
        {
            _userContext = userContext;
        }

        public void AssertAccess(UserAccess userAccess)
        {
            var permissions = GetPermissions();
            var result = permissions.GetAccessResult(userAccess);

            result.AssertPermissionAccess();
        }

        public IUserPermissions GetPermissions()
        {
            return new UserPermissions(_userContext);
        }

        public bool HasAccess(UserAccess userAccess)
        {
            var permissions = GetPermissions();
            return permissions.GetAccessResult(userAccess);
        }
    }
}
