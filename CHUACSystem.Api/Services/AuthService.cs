using CHUACSystem.Service.Interfaces;
using CHUACSystem.Service.ViewModels;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace CHUACSystem.Api.Services
{
    public class AuthService
    {
        private IConfiguration _config;
        private IUserService _userService;

        public AuthService(IConfiguration config, IUserService userService)
        {
            _config = config;
            _userService = userService;
        }
        public UserView Authenticate(Login login)
        {
            return _userService.SignIn(login.Email, login.Password);
        }

        public string BuildToken(UserView user)
        {
            var claims = new[]
            {
                new Claim("userId", user.Id.ToString()),
                new Claim("userEmail", user.Email),
                new Claim("guid", Guid.NewGuid().ToString()),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                _config["Jwt:Issuer"], // issuer
                _config["Jwt:Issuer"], // audience 
                claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public UserView GetUserFromClaimsPrincipal(ClaimsPrincipal claims)
        {
            if (claims.HasClaim(c => c.Type == "userId"))
            {
                Claim emailClaim = claims.Claims.FirstOrDefault(c => c.Type == "userEmail");
                long userId = long.Parse(claims.Claims.FirstOrDefault(c => c.Type == "userId").Value);
                return _userService.GetById(userId);
            }
            return null;
        }
    }
}
