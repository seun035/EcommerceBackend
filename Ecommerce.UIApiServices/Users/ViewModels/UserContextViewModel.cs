using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.UIApiServices.Users.ViewModels
{
    public class UserContextViewModel
    {
        public Guid UserId { get; set; }

        public bool IsAuthenticated { get; set; }

        public string Email { get; set; }

        public string DisplayName { get; set; }
    }
}
