namespace API.Models;
public class Role : IdentityRole<int>
{
    public ICollection<UserRole> UserRoles { get; set; }
}