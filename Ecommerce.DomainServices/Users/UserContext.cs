using Ecommerce.Core.Users;
using Ecommerce.Core.Users.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ecommerce.DomainServices.Users
{
    public class UserContext : IUserContext
    {
        private readonly IUserAccessor _userAccessor;
        private readonly IUserRepository _userRepository;
        private readonly IDictionary<Guid, User> _userMap;
        private readonly User _user;

        public UserContext(IUserAccessor userAccessor, IUserRepository userRepository)
        {
            _userAccessor = userAccessor;
            _userRepository = userRepository;
            _userMap = new Dictionary<Guid, User>();
            _user = GetUser();
        }

        public Guid UserId => _user.Id;

        public bool IsAuthenticated => _user.Id != Guid.Empty;

        public string Email => _user.Email;

        public string DisplayName => _user.DisplayName;

        public Role[] Roles => _user.Roles.Select(r => r.Role).ToArray();

        private User GetUser()
        {
            var userId = _userAccessor.GetCurrentUserId();

            if (userId == Guid.Empty)
            {
                return new User
                {
                    Id = userId,
                    Email = string.Empty,
                    DisplayName = string.Empty,
                    Roles = new List<UserRole> { new UserRole { Role = Role.None } }
                };
            }

            if (_userMap.ContainsKey(userId))
            {
                return _userMap[userId];
            }

            var user = _userRepository.GetUser(u => u .Id == userId);

            return _userMap[userId] = user;

        }
    }
}
