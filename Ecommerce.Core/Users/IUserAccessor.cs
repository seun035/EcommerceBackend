using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Core.Users
{
    public interface IUserAccessor
    {
        Guid GetCurrentUserId();
    }
}
