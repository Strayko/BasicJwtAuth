
using Microsoft.IdentityModel.Tokens;
using SofthouseDev.Api.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace SofthouseDev.Api.Managers
{
    public static class JwtManager
    {
        private static JwtSecurityTokenHandler _tokenHandler = new JwtSecurityTokenHandler();
        private static byte[] _key = Bytes();

        public static string GenerateToken(User user)
        {
            var claimsIdentity = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim("IsActive", user.Active.ToString())
            });

            var signingCredentials = new SigningCredentials(new SymmetricSecurityKey(_key), SecurityAlgorithms.HmacSha256Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = claimsIdentity,
                Issuer = JwtCredentials.Issuer,
                Audience = JwtCredentials.Audience,
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = signingCredentials
            };

            var token = _tokenHandler.CreateToken(tokenDescriptor);
            return _tokenHandler.WriteToken(token);
        }

        private static byte[] Bytes()
        {
            var key = Convert.FromBase64String(JwtCredentials.Secret);
            return key;
        }
    }
}
