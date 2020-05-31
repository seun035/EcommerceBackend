using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.Core.Users;
using Ecommerce.Core.Users.Models;
using Ecommerce.UIApiServices.Users;
using Ecommerce.UIApiServices.Users.Models;
using Ecommerce.UIApiServices.Users.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.UIApi.Controllers
{
    [Route("users")]
    [ApiController]
    [Authorize]
    public class UsersController : ControllerBase
    {
        private readonly IUserComposerService _userComposerService;
        private readonly IUserManager _userManager;

        public UsersController(IUserComposerService userComposerService, IUserManager userManager)
        {
            _userComposerService = userComposerService;
            _userManager = userManager;
        }

        [HttpGet("{userId:Guid}")]
        public async Task<UserInfoViewModel> UserInfo(Guid userId)
        {
            return await _userComposerService.GetUseInfoAsync(userId);
        }

        [HttpPut("{userId:Guid}")]
        public async Task UpdateUserInfo([FromBody] SaveUserModel model, Guid userId)
        {
            await _userComposerService.UpadateUserAsync(model, userId);
        }

        [AllowAnonymous]
        [HttpGet("_usercontext")]
        public UserContextViewModel GetUserContext()
        {
            return _userComposerService.GetUserContext();
        }
    }
}