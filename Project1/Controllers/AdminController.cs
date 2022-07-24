using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project1.Model;

namespace Project1.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly UserDBContext _context;

        public AdminController(IConfiguration configuration, UserDBContext context)
        {
            _context = context;
            _configuration = configuration;

        }
        [HttpGet]
        [Route("getUsers"), Authorize(Roles = "admin")]
        public ActionResult<User> GetUsers()
        {
            var users = _context.Users.Where(x => x.Role == "User");
            var user = users.Select(u => new
            {
                Id = u.Id,
                UserName = u.UserName,
               
            });
            return Ok(user);

        }
        [HttpGet]
        [Route("getBills"), Authorize(Roles = "admin")]
        public IEnumerable<BillDetail> GetBills()
        {

            var bills = _context.BillDetails.ToList();
            return (bills);
        }
        

    }
}
