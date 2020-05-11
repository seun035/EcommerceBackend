using Ecommerce.Core.Exceptions;
using Ecommerce.Core.Helpers;
using Ecommerce.Core.Users;
using Ecommerce.Core.Users.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<User> GetUserByEmailAsync(string email, bool allowNull = false)
        {
            ArgumentGuard.NotNull(email, nameof(email));

            var user = await _dbContext.Users.Include(x => x.Address).SingleOrDefaultAsync(u => u.Email == email);

            if (user == null && !allowNull)
            {
                throw new ObjectNotFoundException($"user not found with email: {email}");
            }

            return user;
        }
    }
}
