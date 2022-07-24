using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Project1.Model;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;

namespace Project1.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LoginController : ControllerBase

    {
        private readonly IConfiguration _configuration;
        private readonly UserDBContext _context;
        public static User user = new User();
        public LoginController(IConfiguration configuration, UserDBContext context)
        {
            _context = context;
            _configuration = configuration;

        }
        [HttpPost]
        public async Task<ActionResult<string>> Login(UserDTO request)
        {
            var checkuser = await _context.Users.FirstOrDefaultAsync(x => x.UserName == request.UserName);
            if (checkuser != null)
            {
                if (!VerifyPasswordHash(request.Password, checkuser.PasswordHash, checkuser.PasswordSalt))
                {
                    return BadRequest("Wrong password.");
                }
                else
                {
                    string token = CreateToken(checkuser);
                    return Ok(token);


                }
            }

            return BadRequest("User not found");


        }
        private string CreateToken(User user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Role, user.Role)
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(
                _configuration.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds);

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }
        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(passwordHash);
            }
        }

    }
}
