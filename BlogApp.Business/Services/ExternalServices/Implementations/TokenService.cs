using BlogApp.Business.DTOs.AccountDTOs;
using BlogApp.Business.Services.ExternalServices.Interfaces;
using BlogApp.Core.Entities.Account;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Business.Services.ExternalServices.Implementations
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _configuration;

        public TokenService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<TokenResponeDTO> CreateTokenAsync(AppUser user, int expireMin = 60)
        {

            List<Claim> ourClaims = new()
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(ClaimTypes.GivenName, user.Name),
            };

            SymmetricSecurityKey key = new(Encoding.UTF8.GetBytes(
                _configuration["JWT:SigningKey"]
                ));

            SigningCredentials credentials = new(key, SecurityAlgorithms.HmacSha256);

            JwtSecurityToken jwt = new(
                issuer: _configuration["JWT:Issuer"],
                audience: _configuration["JWT:Audience"],
                claims: ourClaims,
                notBefore: DateTime.UtcNow,
                expires: DateTime.UtcNow.AddMinutes(expireMin),
                signingCredentials: credentials
                );

            JwtSecurityTokenHandler handler = new();
            string ourToken = handler.WriteToken(jwt);

            return new()
            {
                Token = ourToken,
                ExpireDate = jwt.ValidTo,
                Username = user.UserName
            };
        }
    }
}
