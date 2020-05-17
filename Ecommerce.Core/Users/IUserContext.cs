using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Core.Users
{
    public interface IUserContext
    {
        Guid UserId { get; }

        bool IsAuthenticated { get; }

        string Email { get; }

        string DisplayName { get; }
    }
}
