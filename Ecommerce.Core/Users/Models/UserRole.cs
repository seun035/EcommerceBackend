using Ecommerce.Core.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Core.Users.Models
{
    public class UserRole
    {
        public Role Role { get; set; }

        public Guid UserId { get; set; }

        public User User { get; set; }
    }
}
