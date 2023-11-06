using Microsoft.IdentityModel.Tokens;
using MusicLike.Models.Users;
using MusicLike.Models.UserType;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MusicLike.Services
{
    public class AuthService
    {
        private string secretKey;
        public AuthService(IConfiguration config)
        {
            secretKey = config.GetSection("jwtSettings:secretKey").ToString() ?? null!;
        }

        public string GenerateJwtToken(Users user)
        {
            var claims = new ClaimsIdentity();
            claims.AddClaim(new Claim("id", user.Id.ToString()));
            if (user.UserType != null)
            {
                claims.AddClaim(new Claim(ClaimTypes.Role, user.UserType.Name));

            }
            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = claims,
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey)), SecurityAlgorithms.HmacSha256Signature)
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenConfig = tokenHandler.CreateToken(tokenDescriptor);
            string token = tokenHandler.WriteToken(tokenConfig);
            return token;
        }
    }
}
