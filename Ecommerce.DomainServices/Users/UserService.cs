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

        public async Task<User> GetUseInfoAsync(Guid userId)
        {
            ArgumentGuard.NotEmpty(userId, nameof(userId));

            var user = await _userRepository.GetUserAsync(u => u.Id == userId);
            return user;
        }

        public async Task UpdateUserAsync(UpdateUserModel model)
        {
            ArgumentGuard.NotNull(model, nameof(model));

            var user = await _userRepository.GetUserAsync(u => u.Id == model.Id);

            user.Address = model.Address;
            user.DisplayName = model.DisplayName;
            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            user.LastModifiedDateUtc = DateTime.UtcNow;

            await _userRepository.UpdateAsync(user);
        }
    }
}
