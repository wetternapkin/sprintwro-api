using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Sprintwro.Interface.Authentication;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Sprintwro.Interface.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : Controller
    {
        private readonly AuthConfig _authConfig;

        public UserController(IOptions<AuthConfig> options)
        {
            _authConfig = options.Value;
        }

        [HttpPost("auth")]
        public IActionResult Authenticate(AuthRequest request)
        {
            var user = Domain.User.Create(new Domain.UserId(), Domain.Pseudonym.Create(request.Pseudonym));

            var jwt = GenerateJwtToken(user);

            return Ok(jwt);
        }

        private string GenerateJwtToken(Domain.User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_authConfig.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()), new Claim(ClaimTypes.Surname, user.Pseudonym.ToString()) }),
                Expires = DateTime.UtcNow.AddHours(5),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
