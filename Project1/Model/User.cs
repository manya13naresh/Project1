using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project1.Model
{
    public class User
    {

        [Key]
        public int Id { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string UserName { get; set; } = string.Empty;
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string Role { get; set; } = "User";

        
    }
}
