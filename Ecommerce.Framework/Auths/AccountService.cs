using Ecommerce.Core.Auths;
using Ecommerce.Core.Users.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Framework.Auths
{
    public class AccountService : IAccountService
    {
        public Task LoginUserAsync(UserLoginModel userLoginModel)
        {
            throw new NotImplementedException();
        }

        public Task RegisterUserAsync(UserRegistrationModel userRegistrationModel)
        {
            throw new NotImplementedException();
        }
    }
}
