using Ecommerce.Core.Users;
using Ecommerce.Core.Users.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.DomainServices.Users
{
    public class UserContext : IUserContext
    {
        private readonly IUserAccessor _userAccessor;
        private readonly IUserRepository _userRepository;
        private readonly IDictionary<Guid, User> _userMap;

        public UserContext(IUserAccessor userAccessor, IUserRepository userRepository)
        {
            _userAccessor = userAccessor;
            _userRepository = userRepository;
            _userMap = new Dictionary<Guid, User>();
        }

        //TODO: Implement user role and add it to usercontext

        public Guid UserId => GetUser().Id;

        public bool IsAuthenticated => GetUser().Id != Guid.Empty;

        public string Email => GetUser().Email;

        public string DisplayName => GetUser().DisplayName;


        private User GetUser()
        {
            var userId = _userAccessor.GetCurrentUserId();

            if (userId == Guid.Empty)
            {
                return new User 
                { 
                    Id = userId,
                    Email = string.Empty,
                    DisplayName = string.Empty 
                };
            }

            if (_userMap.ContainsKey(userId))
            {
                return _userMap[userId];
            }

            var user = _userRepository.Get(userId);

            return _userMap[userId] = user;

        }
    }
}
