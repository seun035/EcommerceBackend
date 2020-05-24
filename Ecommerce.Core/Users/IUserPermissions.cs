using Ecommerce.Core.Users.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Core.Users
{
    public interface IUserPermissions
    {
        bool CanEdit { get; }

        bool CanView { get; }

        bool CanCreateProduct { get; }

        bool GetAccessResult(UserAccess userAccess);
    }
}
