namespace webapi.Data.Models;

public class User : BaseModel
{
    public Role Role { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string HashPassword { get; set; }

}
