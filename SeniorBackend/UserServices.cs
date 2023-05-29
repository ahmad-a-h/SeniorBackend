using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using SeniorBackend.Models.IdentityModels;

namespace SeniorBackend
{
    public class UserServices : IUserServices
    {
        private readonly IConfiguration _configuration;

        public UserServices(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GenerateJwt(App_User user, IList<string> roles)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["Secret"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            tokenDescriptor.Subject = new ClaimsIdentity(new Claim[]{
                new Claim(ClaimTypes.Name, user.Firstname+" "+user.Lastname),
                new Claim("id", user.Id),
                new Claim("username", user.UserName)
            });
            if (roles != null)
            {
                foreach (var role in roles)
                {
                    var roleClaim = new Claim(ClaimTypes.Role, role);
                    tokenDescriptor.Subject.AddClaim(roleClaim);
                }
            }

            var token = tokenHandler.CreateToken(tokenDescriptor);
            var jwtToken = tokenHandler.WriteToken(token);

            return jwtToken;
        }
    }
}
