using Ecommerce.Core.Auths;
using Ecommerce.Core.Auths.Models;
using Ecommerce.Core.Helpers;
using Ecommerce.Core.Users;
using Ecommerce.Core.Users.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.DomainServices.Accounts
{
    public class AccountService : IAccountService
    {
        private readonly IUserAccountService _userAccountService;
        private readonly IUserService _userService;
        private readonly IJwtGenerator _jwtGenerator;

        public AccountService(IUserAccountService userAccountService, IUserService userService, IJwtGenerator jwtGenerator)
        {
            _userAccountService = userAccountService;
            _userService = userService;
            _jwtGenerator = jwtGenerator;
        }

        public async Task<AuthenticationResponse> LoginUserAsync(UserLoginModel userLoginModel)
        {
            ArgumentGuard.NotNull(userLoginModel, nameof(userLoginModel));

            var user = await  _userAccountService.LoginAsync(userLoginModel.Email, userLoginModel.Password);
            var token = _jwtGenerator.GenerateToken(user);

            return new AuthenticationResponse { Token = token };
        }

        public async Task<Guid> RegisterUserAsync(UserRegistrationModel userRegistrationModel)
        {
            ArgumentGuard.NotNull(userRegistrationModel, nameof(userRegistrationModel));

            // validate userinfo

            var salt = _userAccountService.GenerateSalt();
            var passwordHash = _userAccountService.HashPassword(userRegistrationModel.Password, salt);

            var createUserModel = new CreateUserModel
            {
                DisplayName = userRegistrationModel.DisplayName,
                Email = userRegistrationModel.Email.Trim().ToLower(),
                PasswordHash = passwordHash,
                Salt = salt
            };

            return await _userService.CreateUserAsync(createUserModel);
        }
    }
}
