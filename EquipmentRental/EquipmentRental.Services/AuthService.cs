using EquipmentRental.Models;
using EquipmentRental.Repositories.Interfaces;
using EquipmentRental.Services.Communication;
using EquipmentRental.Services.Interfaces;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentRental.Services
{
    public class AuthService : IJwtAuthService
    {
        private readonly string _key;
        private readonly string _issuer;
        private readonly string _audience;
        private readonly IUnitOfWork _unitOfWork;
        public AuthService(IUnitOfWork unitOfWork, string key, string issuer, string audience)
        {
            _unitOfWork = unitOfWork;
            _key = key;
            _issuer = issuer;
            _audience = audience;
        }
        public async Task<UserResponse> AuthenticationAsync(User loginCredentials)
        {
            var existingUser = await _unitOfWork.UserRepository.FindByEmailAsync(loginCredentials.Email);
            if (existingUser is null)
                return new UserResponse("User credentials is not correct.");

            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: loginCredentials.Password,
                salt: Convert.FromBase64String(existingUser.Salt),
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 100000,
                numBytesRequested: 256 / 8));

            if (!existingUser.Email.Equals(loginCredentials.Email) || !existingUser.Password.Equals(hashed))
            {
                return new UserResponse("User credentials is not correct."); ;
            }

            return new UserResponse(existingUser);
        }

        public Guid? CheckUserId(Guid id, string userIdFromToken)
        {
            if (!userIdFromToken.Equals(id.ToString()))
                return null;

            return id;
        }

        public string GenerateJWT(User userInfo)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            var tokenKey = Encoding.ASCII.GetBytes(_key);

            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Issuer = _issuer,
                Audience = _audience,
                Subject = new ClaimsIdentity(
                    new Claim[]
                    {
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim("id", userInfo.Id.ToString()),
                        new Claim(JwtRegisteredClaimNames.Email, userInfo.Email),
                        new Claim("role",userInfo.UserType)
                    }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
