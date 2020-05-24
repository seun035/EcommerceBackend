using Ecommerce.Core.Exceptions;
using Ecommerce.Core.Helpers;
using Ecommerce.Core.Users;
using Ecommerce.Core.Users.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Data.Repositories
{
    public class UserRepository: DataRepository<User>, IUserRepository
    {
        private readonly EcommerceDbContext _dbContext;

        public UserRepository(EcommerceDbContext dbContext)
            : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<User> GetUserAsync(Expression<Func<User, bool>> expression, bool allowNull = false)
        {
            ArgumentGuard.NotNull(expression, nameof(expression));

            var user = await _dbContext.Users.Include(x => x.Address).Include(r => r.Roles).SingleOrDefaultAsync(expression);

            if (user == null && !allowNull)
            {
                throw new ObjectNotFoundException($"user not found");
            }

            return user;
        }

        public User GetUser(Expression<Func<User, bool>> expression, bool allowNull = false)
        {
            ArgumentGuard.NotNull(expression, nameof(expression));

            var user = _dbContext.Users.Include(x => x.Address).Include(r => r.Roles).SingleOrDefault(expression);

            if (user == null && !allowNull)
            {
                throw new ObjectNotFoundException($"user not found");
            }

            return user;
        }
    }
}
