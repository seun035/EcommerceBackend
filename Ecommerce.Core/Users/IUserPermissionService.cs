using Ecommerce.Core.Users.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Core.Users
{
    public interface IUserPermissionService
    {
        bool HasAccess(UserAccess userAccess);

        void AssertAccess(UserAccess userAccess);

       IUserPermissions GetPermissions();

    }
}
