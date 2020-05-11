using Ecommerce.Core.Helpers;
using Ecommerce.Core.Users;
using Ecommerce.Core.Users.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.DomainServices.Users
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Guid> CreateUserAsync(CreateUserModel model)
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
            return user.Id;
        }

    }
}
