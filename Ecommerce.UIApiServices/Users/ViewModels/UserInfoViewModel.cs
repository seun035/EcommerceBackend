using Ecommerce.Core.Users.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.UIApiServices.Users.ViewModels
{
    public class UserInfoViewModel
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string DisplayName { get; set; }

        public string Email { get; set; }

        public Address Address { get; set; }
    }
}
