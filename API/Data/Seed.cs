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
                new Role{Name = "Admin"},
                new Role{Name = "Worker"},
            };

        foreach (var role in roles)
        {
            await roleManager.CreateAsync(role);
        }

        // foreach (var user in users)
        // {
        //     user.UserName = user.UserName.ToLower();
        //     await userManager.CreateAsync(user, "Pa$$w0rd");
        //     await userManager.AddToRoleAsync(user, "Member");
        // }

        foreach (var user in users)
        {
            IdentityResult result01 = userManager.CreateAsync(user, "Pa$$w0rd").Result;
            if (result01.Succeeded)
            {
                var normalUser = userManager.FindByNameAsync(user.UserName).Result;
                userManager.AddToRoleAsync(normalUser, "Member").Wait();
            }
        }

        var admin = new User
        {
            UserName = "admin"
        };

        await userManager.CreateAsync(admin, "Pa$$w0rd");
        await userManager.AddToRolesAsync(admin, new[] { "Admin", "Worker" });
    }
}