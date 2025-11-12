using CoreAngular1.Data;
using CoreAngular1.Infrastructure;
using CoreAngular1.MetaModel.Users;
using CoreAngular1.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
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
        public IActionResult Register(CachedUsers user)
        {
            if (_context.CachedUsers.Any(u => u.UserName == user.UserName))
                return BadRequest(new { message = "User Exist !!" });

            _context.CachedUsers.Add(user);
            _context.SaveChanges();
            return Ok(new { message = "User registered" });
        }


        [HttpGet("ping")]
        public IActionResult Ping()
        {


            // تست جدول CachedRoles
            var roles = _context.CachedRoles.ToList();
            var roledds = _context.Departments.ToList();
  

            Console.WriteLine($"تعداد Roles: {roles.Count}");
            foreach (var r in roles)
            {
                Console.WriteLine($"{r.Id} - {r.Name}");
            }

            // تست جدول Tickets
            var tickets = _context.Tickets.ToList();
            Console.WriteLine($"تعداد Tickets: {tickets.Count}");
            //

 
            return Ok(new { message = "API is alive!" });
        }

        [HttpPost("login")]
        public IActionResult Login(UserLoginInput login)
        {


            var user = _context.CachedUsers.FirstOrDefault(u => u.UserName == login.UserName);
            if (user == null)
            {
      
                return BadRequest(new { message = "نام کاربری  یا رمز عبور معبر نمی باشد !" });

            }
       


            var pass = StringCryptor.Encrypt(login.Password, user.UserName);

            if (pass != user.Password)
                return BadRequest(new { message = "نام کاربری یا رمز عبور اشتباه است" });



            var users = (from u in _context.CachedUsers
                         join ud in _context.CachedUserDependencies on u.Id equals ud.UserId
                         join w in _context.CachedWarehouses on ud.WarehouseId equals w.Id
                         where u.UserName == login.UserName && u.Password == pass
                         select new
                         {
                             u.Id,
                             u.UserName,
                             u.FirstName,
                             u.LastName,
                             ud.WarehouseId,
                             WarehouseName = w.Name
                         }).FirstOrDefault();



            var key = Encoding.ASCII.GetBytes(_config["Jwt:Key"]);

            var claims = new List<Claim>
            {
                     new Claim(ClaimTypes.Name, users.UserName),
                    new Claim("UserId", users.Id.ToString()),
                    new Claim("FirstName", users.FirstName ?? ""),
                    new Claim("LastName", users.LastName ?? ""),
                    new Claim("WarehouseId", users.Id.ToString()), // اگه خواستی WarehouseId واقعی بذار
                    new Claim("WarehouseName", users.WarehouseName ?? "")
            };

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddMinutes(10),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);


            return Ok(new
            {
                Token = tokenString,
                ExpireAt = tokenDescriptor.Expires,
                users.UserName,
                users.FirstName,
                users.LastName,
                users.WarehouseName
            });
        }





        [HttpGet("check")]
        [Microsoft.AspNetCore.Authorization.Authorize]
        public IActionResult Check()
        {

     

            // تست جدول CachedRoles
            var roles = _context.CachedRoles.ToList();
            Console.WriteLine($"تعداد Roles: {roles.Count}");
            foreach (var r in roles)
            {
                Console.WriteLine($"{r.Id} - {r.Name}");
            }

            // تست جدول Tickets
            var tickets = _context.Tickets.ToList();
            Console.WriteLine($"تعداد Tickets: {tickets.Count}");

            return BadRequest(new { message = "نام کاربری  یا رمز عبور معبر نمی باشد !" });

        } 


    }
}
