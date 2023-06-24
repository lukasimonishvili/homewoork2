using BCryptNet = BCrypt.Net.BCrypt;
using Mapster;
using DOMAIN;
using System.Linq;
using API.Helpers;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System;
using Microsoft.Extensions.Options;

namespace API.Services
{
    public class AuthService : RootService
    {
        private readonly AppSettings _appSettings;

        public AuthService(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }

        public bool AddRespodent(RespodentAutheDTO respodentDto)
        {
            var respodentDB = respodentContext.Respodents.FirstOrDefault(r => r.Username == respodentDto.Username);

            if (respodentDB != null)
            {
                return false;
            }

            var respodent = respodentDto.Adapt<Respodent>();
            respodent.Role = Roles.User;
            respodent.Password = BCryptNet.HashPassword(respodent.Password);

            respodentContext.Respodents.Add(respodent);
            respodentContext.SaveChanges();
            return true;
        }

        public string LoginUser(LoginDto loginDto)
        {
            var respodentDB = respodentContext.Respodents.FirstOrDefault(r => r.Username == loginDto.Username);

            if (respodentDB == null)
            {
                return null;
            }

            if (!BCryptNet.Verify(loginDto.Password, respodentDB.Password))
            {
                return null;
            }

            var respodentDto = respodentDB.Adapt<RespodentDTO>();
            return GenerateToken(respodentDto);
        }

        private string GenerateToken(RespodentDTO respodent)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, respodent.Id.ToString()),
                    new Claim("FirstName", respodent.FirstName),
                    new Claim("LastName", respodent.LastName),
                    new Claim("Username", respodent.Username),
                    new Claim("Role", respodent.Role)

                }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);
            return tokenString;
        }

        public string RefreshToken(string tokenString)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.ReadJwtToken(tokenString);

            var uniqueNameClaim = token.Claims.FirstOrDefault(claim => claim.Type == "unique_name");

            if (uniqueNameClaim != null)
            {
                var respodentDb = respodentContext.Respodents.FirstOrDefault(r => r.Id == Convert.ToInt32(uniqueNameClaim.Value));
                var respodentDto = respodentDb.Adapt<RespodentDTO>();
                return GenerateToken(respodentDto);
            }

            return null;
        }

        public string GetRoleFromToken(string tokenString)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.ReadJwtToken(tokenString);
            var uniqueNameClaim = token.Claims.FirstOrDefault(claim => claim.Type == "Role");

            if (uniqueNameClaim == null)
            {
                return null;
            }
            return uniqueNameClaim.Value;
        }
    }
}
