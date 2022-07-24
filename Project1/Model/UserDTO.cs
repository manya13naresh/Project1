using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project1.Model
{
    public class UserDTO
    {
        public string UserName { get; set; } = string.Empty;

        public string Password { get; set; }= string.Empty;
        
         public string Role { get; set; } = "User";

    }
}
