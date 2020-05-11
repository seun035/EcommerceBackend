using Ecommerce.Core.Data;
using Ecommerce.Core.Users.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Core.Users
{
    public interface IUserRepository: IDataRepository<User>
    {
        Task<User> GetUserByEmailAsync(string email, bool allowNull = false);
    }
}
