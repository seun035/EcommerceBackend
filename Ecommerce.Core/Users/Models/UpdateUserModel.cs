using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Core.Users.Models
{
    public class  UpdateUserModel
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string DisplayName { get; set; }

        public Address Address { get; set; }
    }
}
