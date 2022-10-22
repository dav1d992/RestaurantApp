namespace API.Models;
public class User : IdentityUser<int>
{
    // public int Id { get; set; }
    // public string UserName { get; set; }
    // public byte[] PasswordHash { get; set; }
    // public int PhoneNumber { get; set; }
    // public string Email { get; set; }
    // public byte[] PasswordSalt { get; set; }
    public string Gender { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public Address Address { get; set; }
    public ICollection<UserRole> Roles { get; set; }
    public ICollection<Restaurant> Restaurants { get; set; }
}