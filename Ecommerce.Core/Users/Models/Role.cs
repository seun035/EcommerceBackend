using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Core.Users.Models
{
    public enum Role
    {
        None = 0,
        User = 1000,
        Merchant = 1100,
        Admin = 1200,
    }
}
