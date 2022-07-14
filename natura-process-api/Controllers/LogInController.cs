using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using natura_process_api.Models;
using natura_process_api.Data;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace natura_process_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogInController : ControllerBase
    {
        public IConfiguration _configuration;
        public readonly Context _context;

        public LogInController(IConfiguration configuration, Context context)
        {
            _configuration = configuration;
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Post(User user)
        {
            if(!await AuthenticateUser(user.UserName, user.Password)) return Unauthorized("Invalid username or password.");
            var jwt = _configuration.GetSection("Jwt").Get<Jwt>();
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames. Sub, jwt. Subject),
                new Claim(JwtRegisteredClaimNames.Jti, Guid. NewGuid().ToString()),
                new Claim (JwtRegisteredClaimNames. Iat, DateTime. UtcNow.ToString()),
                new Claim("Id", user.Id.ToString()),
                new Claim("UserName", user.UserName), new Claim ("Password", user. Password)
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwt.key));
            var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(jwt.Issuer, jwt.Audience, claims, expires: DateTime.Now.AddMinutes(20), signingCredentials: signIn);
            return Ok("Bearer "+new JwtSecurityTokenHandler().WriteToken(token));
        }

        private async Task<bool> AuthenticateUser(string username, string passowrd)
        {
            return (await _context.User.FirstOrDefaultAsync(user => user.UserName == username && user.Password == passowrd)) != null;
        }
    }
}
