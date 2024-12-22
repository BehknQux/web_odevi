using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace e_commerce_app.Models;

public class ApplicationDbContext : IdentityDbContext<IdentityUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<CartItem> CartItems { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        // Users tablosu ve kolon isimlendirmesi
        modelBuilder.Entity<IdentityUser>(entity =>
        {
            entity.ToTable("users");
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.UserName).HasColumnName("name");
            entity.Property(e => e.Email).HasColumnName("email");
            entity.Property(e => e.PasswordHash).HasColumnName("password"); // PasswordHash -> password
        });

        // Category için yapılandırma
        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(c => c.Id);
            entity.Property(c => c.Name).IsRequired().HasMaxLength(100);
            entity.HasData(
                new Category { Id = 1, Name = "Technology" },
                new Category { Id = 2, Name = "Science" },
                new Category { Id = 3, Name = "Health" },
                new Category { Id = 4, Name = "Education" }
            );
        });

        // Product için yapılandırma
        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(p => p.Id);
            entity.Property(p => p.Name).IsRequired().HasMaxLength(200);
            entity.Property(p => p.Price).IsRequired().HasColumnType("decimal(18,2)");
            entity.Property(p => p.Description).HasMaxLength(1000);
            entity.HasOne(p => p.Category)
                  .WithMany(c => c.Products)
                  .HasForeignKey(p => p.CategoryId)
                  .OnDelete(DeleteBehavior.Cascade).IsRequired(false);

            // Seed Data for Products
            entity.HasData(
                new Product
                {
                    Id = 1,
                    Name = "Smartphone",
                    Description = "A high-end smartphone with 128GB storage.",
                    Price = 999.99m,
                    Stock = 50,
                    CategoryId = 1
                },
                new Product
                {
                    Id = 2,
                    Name = "Laptop",
                    Description = "A powerful laptop for professionals.",
                    Price = 1499.99m,
                    Stock = 30,
                    CategoryId = 1
                },
                new Product
                {
                    Id = 3,
                    Name = "Microscope",
                    Description = "A professional-grade microscope for science labs.",
                    Price = 499.99m,
                    Stock = 20,
                    CategoryId = 2
                },
                new Product
                {
                    Id = 4,
                    Name = "Fitness Tracker",
                    Description = "A wearable fitness tracker to monitor health.",
                    Price = 199.99m,
                    Stock = 100,
                    CategoryId = 3
                },
                new Product
                {
                    Id = 5,
                    Name = "E-Learning Course",
                    Description = "An online course for advanced mathematics.",
                    Price = 59.99m,
                    Stock = 1000,
                    CategoryId = 4
                }
            );
        });

        // Seed Data for Users
        var hasher = new PasswordHasher<IdentityUser>();

        var adminUser = new IdentityUser
        {
            Id = "1", // Sabit ID
            UserName = "admin@admin.com",
            NormalizedUserName = "ADMIN@ADMIN.COM",
            Email = "admin@admin.com",
            NormalizedEmail = "ADMIN@ADMIN.COM",
            EmailConfirmed = true
        };
        adminUser.PasswordHash = "Admin123!";

        var normalUser = new IdentityUser
        {
            Id = "2", // Sabit ID
            UserName = "atesgolemi@gmail.com",
            NormalizedUserName = "ATESGOLEMI@GMAIL.COM",
            Email = "atesgolemi@gmail.com",
            NormalizedEmail = "ATESGOLEMI@GMAIL.COM",
            EmailConfirmed = true
        };
        normalUser.PasswordHash = "hamza";

        // Add Users to Model
        modelBuilder.Entity<IdentityUser>().HasData(adminUser, normalUser);

        // Seed Data for Roles
        modelBuilder.Entity<IdentityRole>().HasData(
            new IdentityRole
            {
                Id = "1",
                Name = "Admin",
                NormalizedName = "ADMIN"
            },
            new IdentityRole
            {
                Id = "2",
                Name = "User",
                NormalizedName = "USER"
            }
        );
    }
}
