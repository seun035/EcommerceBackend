using Ecommerce.Core.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Core.Users.Models
{
    public class User : BaseEntity
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string DisplayName { get; set; }

        public string Email { get; set; }

        public Address Address { get; set; }

        public string Salt { get; set; }

        public string Password { get; set; }
    }
}
