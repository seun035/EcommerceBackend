﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Core.Users.Models
{
    public class UserRegistrationModel
    {
        public string DisplayName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }
    }
}
