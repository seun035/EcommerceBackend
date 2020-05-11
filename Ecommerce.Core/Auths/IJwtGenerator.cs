using Ecommerce.Core.Users.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Core.Auths
{
    public interface IJwtGenerator
    {
        string GenerateToken(User user);
    }
}
