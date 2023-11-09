using Microsoft.AspNetCore.Identity;

namespace webapi.Data
{
    public class UserRegisterDTO
    {
      public string UserName { get; set; } 
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
    }
}
