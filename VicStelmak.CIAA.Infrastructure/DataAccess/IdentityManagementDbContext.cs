using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using VicStelmak.CIAA.Infrastructure.Identity;

namespace VicStelmak.CIAA.Infrastructure.DataAccess
{
    public class IdentityManagementDbContext : IdentityDbContext<CustomIdentityUser, CustomIdentityRole, string>
    {
        public IdentityManagementDbContext(DbContextOptions<IdentityManagementDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
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
}


