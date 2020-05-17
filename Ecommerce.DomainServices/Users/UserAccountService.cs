using Ecommerce.Core.Exceptions;
using Ecommerce.Core.Framework;
using Ecommerce.Core.Helpers;
using Ecommerce.Core.Users;
using Ecommerce.Core.Users.Models;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.DomainServices.Users
{
    public class UserAccountService : IUserAccountService
    {
        private readonly IUserRepository _userRepository;
        private readonly ICryptoService _cryptoService;

        public UserAccountService(IUserRepository userRepository, ICryptoService cryptoService)
        {
            _userRepository = userRepository;
            _cryptoService = cryptoService;
        }

        public async Task<User> LoginAsync(string email, string password)
        {
            ArgumentGuard.NotNull(email, nameof(email));
            ArgumentGuard.NotNull(password, nameof(password));

            var user = await _userRepository.GetAsync(u => u.Email == email.Trim().ToLower());

            var hashedPassword = _cryptoService.HashPasswordKeyDerivationPbkdf2(password, user.Salt);

            if (user.PasswordHash != hashedPassword)
            {
                throw new AppException(400, "Invalid credentials"); // change to validation error
            }

            return user;
        }

        public async Task RegisterAsync(CreateUserModel model)
        {
            ArgumentGuard.NotNull(model, nameof(model));

            var user = new User
            {
                Id = Guid.NewGuid(),
                DisplayName = model.DisplayName,
                Email = model.Email,
                PasswordHash = model.PasswordHash,
                Salt = model.Salt,
                CreatedDateUtc = DateTime.UtcNow
            };

            await _userRepository.AddAsync(user);
        }
    }
}
