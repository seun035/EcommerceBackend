using Ecommerce.Core.Users.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.UIApiServices.Users.Models
{
    public class SaveUserModel
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string DisplayName { get; set; }

        public Address Address { get; set; }
    }
}
