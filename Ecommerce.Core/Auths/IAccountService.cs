using Ecommerce.Core.Auths.Models;
using Ecommerce.Core.Users.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Core.Auths
{
    public interface IAccountService
    {
        Task RegisterWithPasswordAsync(UserRegistrationModel userRegistrationModel);

        Task<AuthenticationResponse> LoginWithPasswordAsync(UserLoginModel userLoginModel);
    }
}
