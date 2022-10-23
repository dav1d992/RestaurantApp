namespace API.Models;

public class User : IdentityUser<int>
{
    public string Gender { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public Address Address { get; set; }
    public ICollection<UserRole> Roles { get; set; }
    public ICollection<Restaurant> Restaurants { get; set; }
}