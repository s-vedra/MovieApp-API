using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MovieApp.Config;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MovieApp.HelperMethods
{
    public class GenerateToken : IGenerateToken
    {
        private readonly AppSettings _settings;
        public GenerateToken(IOptions<AppSettings> settings)
        {
            _settings = settings.Value;
        }
        public string Token(int id, string username)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_settings.SecretKey);
            var securityTokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(
                   new Claim[]
                   {
                        new Claim(ClaimTypes.NameIdentifier, id.ToString()),
                        new Claim(ClaimTypes.Name, username)
                   }
               ),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(securityTokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
