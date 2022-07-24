using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project1.Model;

namespace Project1.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly IConfiguration _configuration;
        private readonly UserDBContext _context;
      //  public static User user = new User();

        public UserController(IConfiguration configuration, UserDBContext context)
        {
            _context = context;
            _configuration = configuration;

        }
        [HttpPost]
        [Route("billdetails"), Authorize(Roles = "User")]
        public async Task<IActionResult> BillDetails(BillDetail bill)
        {
            var user = _context.Users.Where(x => x.UserName == bill.BillName);
            if (user!=null)
            {
                _context.BillDetails.Add(bill);
                await _context.SaveChangesAsync();
                return Ok("STATUS:Pending");
            }
            else
            {
                return BadRequest("User not Found");
            }
        }
        [HttpGet]
        [Route("viewBill/{BillName}"), Authorize(Roles = "User")]
        public ActionResult<BillDetail> GetStatus(string? BillName)
        {
            var bills = _context.BillDetails.Where(x => x.BillName == BillName);
            return Ok(bills);
        }


    }
}
