using Microsoft.AspNetCore.Identity;

namespace webapi.Data.Models;

public class User : IdentityUser
{
    public TravelModel? CurrentTravel { get; set; }
    public IEnumerable<Comment>? comments { get; set; } = null;


}
