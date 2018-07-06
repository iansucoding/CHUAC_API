using CHUACSystem.Api.Services;
using CHUACSystem.Service.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CHUACSystem.Api.Controllers
{
    [Route("api/[controller]")]
    public class TokenController : Controller
    {
        private AuthService _authService;

        public TokenController(AuthService authService)
        {
            _authService = authService;
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult CreateToken([FromBody]Login login)
        {
            var user = _authService.Authenticate(login);
            if (user != null)
            {
                var token = _authService.BuildToken(user);
                return Ok(new { token, user, isRememberMe = login .IsRememberMe});
            }
            return Unauthorized();
        }

        [HttpGet("get-user")]
        [Authorize]
        public IActionResult GetUserFromToken()
        {
            var claimsPrincipal = HttpContext.User;
            var user = _authService.GetUserFromClaimsPrincipal(claimsPrincipal);
            if (user == null)
            {
                return Unauthorized();
            }
            else
            {
                return new ObjectResult(user);
            }
        }
    }
}
