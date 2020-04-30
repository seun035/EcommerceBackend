using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.Core.Auths;
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
        public void RegisterUser(UserRegistrationModel userRegistrationModel)
        {
            _accountService.RegisterUserAsync(userRegistrationModel);
        }

        [HttpPost("login")]
        public void LoginUser(UserLoginModel userLoginModel)
        {
            _accountService.LoginUserAsync(userLoginModel);
        }
    }
}