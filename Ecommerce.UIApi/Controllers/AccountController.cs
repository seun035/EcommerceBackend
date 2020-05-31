using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.Core.Auths;
using Ecommerce.Core.Auths.Models;
using Ecommerce.Core.Users.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.UIApi.Controllers
{
    [Route("account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }
        
        [HttpPost("register")]
        public async Task RegisterAsync(UserRegistrationModel userRegistrationModel)
        {
           await _accountService.RegisterWithPasswordAsync(userRegistrationModel);
        }

        [HttpPost("login")]
        public async Task<AuthenticationResponse> LoginAsync(UserLoginModel userLoginModel)
        {
            return await _accountService.LoginWithPasswordAsync(userLoginModel);
        }
    }
}