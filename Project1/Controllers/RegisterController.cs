using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project1.Model;
using System.Security.Cryptography;

namespace Project1.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly UserDBContext _context;
        public static User user = new User();
        public RegisterController(IConfiguration configuration, UserDBContext context)
        {
            _context = context;
            _configuration = configuration;

        }
        [HttpPost]
        public async Task<ActionResult<User>> Register(UserDTO request)
        {
           // var checkUser = await _context.Users.FirstOrDefaultAsync(x => x.UserName == request.UserName);
           // if (checkUser == null)
          //  {
                CreatePasswordHash(request.Password, out byte[] passwordHash, out byte[] passwordSalt);

                user.UserName = request.UserName;
                user.PasswordHash = passwordHash;
                user.PasswordSalt = passwordSalt;
                user.Role = request.Role;
                _context.Users.Add(user);
                await _context.SaveChangesAsync();
                return Ok("User Created Successfully");
          //  }
          //  else
          //  {
               
                
            //        return BadRequest("User already exsits");
                

         //   }



        }
        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
    }
}
