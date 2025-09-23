using Data.Context;
using Data.IRepository;
using Data.Service;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class TokenRepository : ITokenRepository
    {
        private readonly WriteDbContext _db;
        private readonly IApiClientRepository _apiClientRepository;


        public TokenRepository(WriteDbContext db, IApiClientRepository apiClientRepository)
        {
            _db = db;
            _apiClientRepository = apiClientRepository;
        }

        public string GenerateAccessToken(IEnumerable<Claim> claims, int expiryMinutes = 1)
        {
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Config.JWTWebKey));
            var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

            var tokeOptions = new JwtSecurityToken(
                issuer: Config.JWTWebIssuer,
                audience: Config.JWTWebAudience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(expiryMinutes),
                signingCredentials: signinCredentials
            );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
            return tokenString;
        }

        public string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(randomNumber);
            return Convert.ToBase64String(randomNumber);
        }


    }

}
