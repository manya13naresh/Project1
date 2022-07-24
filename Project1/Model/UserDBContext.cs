using Microsoft.EntityFrameworkCore;

namespace Project1.Model
{
    public class UserDBContext:DbContext
    {
        public UserDBContext(DbContextOptions<UserDBContext> options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<BillDetail> BillDetails { get; set; }


    }
}
