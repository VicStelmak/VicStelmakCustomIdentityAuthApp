using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using VicStelmak.CIAA.Infrastructure.Identity;

namespace VicStelmak.CIAA.Infrastructure.DataAccess;

public class CustomIdentityDbContext : IdentityDbContext<CustomIdentityUser, CustomIdentityRole, string>
{
    public CustomIdentityDbContext(DbContextOptions<CustomIdentityDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);

        base.OnModelCreating(builder);

        builder.Entity<CustomIdentityUser>()
        .HasMany(p => p.Roles).WithOne()
        .HasForeignKey(p => p.UserId)
        .IsRequired()
        .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<CustomIdentityUser>()
            .HasMany(e => e.Claims)
            .WithOne().HasForeignKey(e => e.UserId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<CustomIdentityRole>()
            .HasMany(r => r.Claims).WithOne()
            .HasForeignKey(r => r.RoleId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);
    }
}

