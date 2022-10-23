
namespace API.Data;

public class DataContext : IdentityDbContext<User, Role, int,
        IdentityUserClaim<int>, UserRole, IdentityUserLogin<int>,
        IdentityRoleClaim<int>, IdentityUserToken<int>>
{
    public DataContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Address> Addresses { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Menu> Menus { get; set; }
    public DbSet<MenuItem> MenuItems { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderLine> OrderLines { get; set; }
    public DbSet<Restaurant> Restaurants { get; set; }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<UserRole>(x => x.HasKey(y =>
            new { y.UserId, y.RoleId }));

        builder.Entity<UserRole>()
            .HasOne(ur => ur.User)
            .WithMany(u => u.Roles)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<UserRole>()
            .HasOne(ur => ur.Role)
            .WithMany(r => r.UserRoles)
            .HasForeignKey(r => r.RoleId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<Order>()
            .HasMany(o => o.OrderLines)
            .WithOne()
            .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<OrderLine>()
            .HasOne(ol => ol.MenuItem)
            .WithOne()
            .HasForeignKey<MenuItem>(mi => mi.Id)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<Category>()
                .HasMany(c => c.MenuItems)
                .WithOne(mi => mi.Category)
                .HasForeignKey(mi => mi.Id)
                .OnDelete(DeleteBehavior.Cascade);

    }
}