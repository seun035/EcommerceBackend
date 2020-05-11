using Ecommerce.Core.Exceptions;
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

        public UserAccountService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public string GenerateSalt()
        {
            byte[] salt = new byte[128 / 8];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }

            return Encoding.Default.GetString(salt);
        }

        public string HashPassword(string password, string passwordSalt)
        {
            ArgumentGuard.NotNull(password, nameof(password));
            ArgumentGuard.NotNull(passwordSalt, nameof(passwordSalt));

            var salt = Encoding.Default.GetBytes(passwordSalt);

            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
            password: password,
            salt: salt,
            prf: KeyDerivationPrf.HMACSHA1,
            iterationCount: 10000,
            numBytesRequested: 256 / 8));

            return hashed;
        }

        public async Task<User> LoginAsync(string email, string password)
        {
            ArgumentGuard.NotNull(email, nameof(email));
            ArgumentGuard.NotNull(password, nameof(password));

            var user = await _userRepository.GetAsync(u => u.Email == email.Trim().ToLower());

            var hashedPassword = HashPassword(password, user.Salt);

            if (user.PasswordHash != hashedPassword)
            {
                throw new AppException(400, "Invalid credentials");
            }

            return user;
        }
    }
}
