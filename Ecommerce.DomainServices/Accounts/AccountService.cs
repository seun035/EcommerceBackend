using Ecommerce.Core.Auths;
using Ecommerce.Core.Auths.Models;
using Ecommerce.Core.Framework;
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
        private readonly IJwtGenerator _jwtGenerator;
        private readonly ICryptoService _cryptoService;

        public AccountService(IUserAccountService userAccountService,
                              IJwtGenerator jwtGenerator,
                              ICryptoService cryptoService)
        {
            _userAccountService = userAccountService;
            _jwtGenerator = jwtGenerator;
            _cryptoService = cryptoService;
        }

        public async Task<AuthenticationResponse> LoginWithPasswordAsync(UserLoginModel userLoginModel)
        {
            ArgumentGuard.NotNull(userLoginModel, nameof(userLoginModel));

            var user = await  _userAccountService.LoginAsync(userLoginModel.Email, userLoginModel.Password);
            var token = _jwtGenerator.GenerateToken(user);

            return new AuthenticationResponse { Token = token };
        }

        public async Task RegisterWithPasswordAsync(UserRegistrationModel userRegistrationModel)
        {
            ArgumentGuard.NotNull(userRegistrationModel, nameof(userRegistrationModel));

            // validate userinfo

            var salt = _cryptoService.GenerateSalt(32);
            var passwordHash = _cryptoService.HashPasswordKeyDerivationPbkdf2(userRegistrationModel.Password, salt);

            var createUserModel = new CreateUserModel
            {
                DisplayName = userRegistrationModel.DisplayName,
                Email = userRegistrationModel.Email.Trim().ToLower(),
                PasswordHash = passwordHash,
                Salt = salt
            };

            await _userAccountService.RegisterAsync(createUserModel);
        }
    }
}
