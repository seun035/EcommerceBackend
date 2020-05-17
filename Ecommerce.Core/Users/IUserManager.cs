using Ecommerce.Core.Users.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Core.Users
{
    public interface IUserManager
    {
        Task<User> GetUseInfoAsync(Guid userId);

        Task UpdateUserAsync(UpdateUserModel model);
    }
}
