using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Core.Users.Models
{
    public class UserRegistrationModel
    {
        public string Email { get; set; }

        public string Password { get; set; }

        public Address Address { get; set; }
    }
}
