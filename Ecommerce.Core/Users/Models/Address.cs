using Ecommerce.Core.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Core.Users.Models
{
    public class Address: BaseEntity
    {
        public string Street { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public Guid UserId { get; set; }

        public User User { get; set; }
    }
}
