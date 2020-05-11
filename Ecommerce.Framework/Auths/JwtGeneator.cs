using Ecommerce.Core.Auths;
using Ecommerce.Core.Users.Models;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Ecommerce.Framework.Auths
{
    public class JwtGeneator : IJwtGenerator
    {
        public string GenerateToken(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.UniqueName, user.Email),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Super Secret Key"));
            var signInCredential = new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256Signature);

            var token = new JwtSecurityToken(claims: claims, signingCredentials: signInCredential, expires: DateTime.Now.AddDays(7));

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
