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
        public async Task<Guid> RegisterUser(UserRegistrationModel userRegistrationModel)
        {
           return await _accountService.RegisterUserAsync(userRegistrationModel);
        }

        [HttpGet("login")]
        public async Task<AuthenticationResponse> LoginUser(UserLoginModel userLoginModel)
        {
            return await _accountService.LoginUserAsync(userLoginModel);
        }
    }
}