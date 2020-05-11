using Ecommerce.Core.Users.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Core.Users
{
    public interface IUserAccountService
    {
        string HashPassword(string password, string passwordSalt);

        string GenerateSalt();

        Task<User> LoginAsync(string email, string password);
    }
}
