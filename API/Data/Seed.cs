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

        Console.WriteLine(users);
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
            Console.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
            IdentityResult result01 = await userManager.CreateAsync(user, "Pa$$w0rd");
            Console.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");


            if (result01.Succeeded)
            {
                var normalUser = await userManager.FindByNameAsync(user.UserName);
                userManager.AddToRoleAsync(normalUser, "Member").Wait();
            }
        }

        var admin = new User
        {
            UserName = "admin"
        };

        await userManager.CreateAsync(admin, "Pa$$w0rd");
        await userManager.AddToRolesAsync(admin, new[] { "Admin" });
    }
}