using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project1.Model;
using System.Linq;

namespace Project1.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AccountManagerController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly UserDBContext _context;

        public AccountManagerController(IConfiguration configuration, UserDBContext context)
        {
            _context = context;
            _configuration = configuration;

        }
        [HttpGet]
        [Route("getBills"), Authorize(Roles = "Account Manager")]
        public IEnumerable<BillDetail> GetBills()
        {
            var bills = _context.BillDetails.ToList();
            return (bills);
        }
        [HttpGet]
        [Route("getStatus/{BillStatus}"), Authorize(Roles = "Account Manager")]
        public ActionResult<BillDetail> GetStatus(string? BillStatus)
        { 
            var bills = _context.BillDetails.Where(x => x.BillStatus == BillStatus);
            var bill = bills.Select(u => new
            {
                BillId = u.BillId,
                BillName = u.BillName,
                BillAmount = u.BillAmount,
                Reason = u.Reason

            });
            return Ok(bill);
        }
        [HttpPut]
        [Route("updateStatus/{BillId}"), Authorize(Roles = "Account Manager")]
        public async Task<ActionResult<BillDetail>> UpdateApp(int? BillId, [FromBody] BillDetail bill)
        {
            var user = _context.BillDetails.Where(x => x.BillName == bill.BillName).SingleOrDefault();
            if (user != null)
            {
                if (user.BillId == BillId)
                { 
                    user.BillStatus = bill.BillStatus;
                    Send.Producer(user.BillStatus);
                    

                    _context.SaveChanges();
                    return Ok("Successfully updated the status");
                }
                else
                {
                    return Ok("Wrong BillId");
                }
            }
            else
            {
                return BadRequest("User Not Found");
            }


        }


    }
}





