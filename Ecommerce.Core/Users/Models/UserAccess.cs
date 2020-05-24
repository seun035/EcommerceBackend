using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Core.Users.Models
{
    public enum UserAccess
    {
        None = 0,
        CanView = 1,
        CanEdit = 2,
        CanCreateProduct
    }
}
