namespace API.Data;

public class Seed
{
    public static async Task SeedUsers(UserManager<User> userManager,
        RoleManager<Role> roleManager)
    {
        if (await userManager.Users.AnyAsync()) return;

        var userData = await System.IO.File.ReadAllTextAsync("Data/UserSeedData.json");
        var users = JsonSerializer.Deserialize<List<User>>(userData);
        if (users == null) return;

        var roles = new List<Role>
            {
                new Role{Name = "Member"},
                new Role{Name = "Manager"},
                new Role{Name = "Worker"},
            };

        foreach (var role in roles)
        {
            await roleManager.CreateAsync(role);
        }

        foreach (var user in users)
        {
            user.UserName = user.UserName.ToLower();
            await userManager.CreateAsync(user, "Pa$$w0rd");
            await userManager.AddToRoleAsync(user, "Member");
        }

        var manager = new User
        {
            UserName = "manager"
        };

        await userManager.CreateAsync(manager, "Pa$$w0rd");
        await userManager.AddToRolesAsync(manager, new[] { "Manager" });
    }



}