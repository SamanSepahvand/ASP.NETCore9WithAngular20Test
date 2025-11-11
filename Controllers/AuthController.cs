using CoreAngular1.Data;
using CoreAngular1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CoreAngular1.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IConfiguration _config;

        public AuthController(AppDbContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }

        [HttpPost("register")]
        public IActionResult Register(User user)
        {
            if (_context.Users.Any(u => u.Username == user.Username))
                return BadRequest(new { message = "User Exist !!" });

            _context.Users.Add(user);
            _context.SaveChanges();
            return Ok(new { message = "User registered" });
        }


        [HttpGet("ping")]
        public IActionResult Ping()
        {
            //
            return Ok(new { message = "API is alive!" });
        }

        [HttpPost("login")]
        public IActionResult Login(User login)
        {

        
            var user = _context.Users.FirstOrDefault(u => u.Username == login.Username && u.Password == login.Password);
            if (user == null)
              return BadRequest(new { message = "Unauthorized !" });

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_config["Jwt:Key"]!);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                new Claim(ClaimTypes.Name, user.Username)
            }),
               // Expires = DateTime.UtcNow.AddHours(2),
                Expires = DateTime.UtcNow.AddMinutes(1), // <-- اعتبار 1 دقیقه
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return Ok(new { token = tokenHandler.WriteToken(token) });
        }

        [HttpGet("check")]
        [Microsoft.AspNetCore.Authorization.Authorize]
        public IActionResult Check() => Ok("Token is valid");
    }
}
