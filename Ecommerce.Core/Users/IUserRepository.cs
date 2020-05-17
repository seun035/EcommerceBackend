using Ecommerce.Core.Data;
using Ecommerce.Core.Users.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Core.Users
{
    public interface IUserRepository: IDataRepository<User>
    {
        Task<User> GetUserAsync(Expression<Func<User, bool>> expression, bool allowNull = false);
    }
}
