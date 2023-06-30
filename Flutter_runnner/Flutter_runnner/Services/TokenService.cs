using Flutter_runnner;
using Flutter_runnner.Interfaces;

using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

using System.Security.Claims;
using System.Text;

namespace Flutter_runnner.Services
{
    public class TokenService : ITokenService
    {
        private readonly SymmetricSecurityKey securityKey;
        public TokenService(IConfiguration configuration) {
            securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["TokenKey"]));
        }

       public string CreateToken(User user)
            {
                var claims = new List<Claim>
         {
            new Claim(JwtRegisteredClaimNames.NameId, user.id.ToString()),
            new Claim(JwtRegisteredClaimNames.Name, user.Name + " " + user.Surname),
            new Claim(JwtRegisteredClaimNames.Email, user.Email),
           
         };

                var creds = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512Signature);

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(claims),
                    Expires = DateTime.Now.AddDays(7),
                    SigningCredentials = creds
                };

                var tokenHandler = new JwtSecurityTokenHandler();
                var token = tokenHandler.CreateToken(tokenDescriptor);

                return tokenHandler.WriteToken(token);
            }

        }
    }

