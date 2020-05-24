using Ecommerce.Core.Users;
using Ecommerce.Core.Users.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ecommerce.DomainServices.Users
{
    public class UserPermissions : IUserPermissions
    {
        private readonly IUserContext _userContext;
        private readonly IDictionary<UserAccess, Lazy<bool>> _accessMap;

        public UserPermissions(IUserContext userContext)
        {
            _userContext = userContext;
            _accessMap = new Dictionary<UserAccess, Lazy<bool>> 
            {
                { UserAccess.CanEdit, new Lazy<bool>(EditUser) },
                { UserAccess.CanView, new Lazy<bool>(EditUser) },
                { UserAccess.CanCreateProduct, new Lazy<bool>(CreateProduct) }
            };
        }

        public bool CanEdit => _accessMap[UserAccess.CanEdit].Value;

        public bool CanView => _accessMap[UserAccess.CanView].Value;

        public bool CanCreateProduct => _accessMap[UserAccess.CanCreateProduct].Value;

        public bool GetAccessResult(UserAccess userAccess)
        {
            return _accessMap[userAccess].Value;
        }

        private bool EditUser()
        {
            if (!_userContext.IsAuthenticated)
            {
                return false;
            }

            if (_userContext.Roles.Contains(Role.Admin))
            {
                return true;
            }

            return false;
        }

        private bool CreateProduct()
        {
            if (!_userContext.IsAuthenticated)
            {
                return false;
            }

            if (_userContext.Roles.Contains(Role.Admin))
            {
                return true;
            }

            return false;
        }
    }
}
