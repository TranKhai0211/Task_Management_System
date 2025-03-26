using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Task_Management_System.Entities.Authentication
{
    public class Jwt_Service
    {
        private readonly string _secret_Key;
        private readonly string _issuer;
        private readonly string _audience;
        private readonly int _expire_Minutes;

        public Jwt_Service(IConfiguration config)
        {
            _secret_Key = config["JwtSettings:SecretKey"];
            _issuer = config["JwtSettings:Issuer"];
            _audience = config["JwtSettings:Audience"];
            _expire_Minutes = int.Parse(config["JwtSettings:ExpireMinutes"]);
        }

        public string Generate_Token(string userId, string role)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secret_Key));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, userId),                                 // Có thể sai ở đoạn này do dùng nhầm thư viện
                new Claim(ClaimTypes.Role, role),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var token = new JwtSecurityToken(
                _issuer,
                _audience,
                claims,
                expires: DateTime.UtcNow.AddMinutes(_expire_Minutes),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
