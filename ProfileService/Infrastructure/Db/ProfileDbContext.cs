using Microsoft.EntityFrameworkCore;
using ProfileService.Domain;

namespace ProfileService.Infrastructure.Db;

public class ProfileDbContext:DbContext
{
    public ProfileDbContext(DbContextOptions<ProfileDbContext> options) : base(options)
    {
    }
    
    public DbSet<User> Users => Set<User>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.email).IsRequired();
            entity.HasIndex(e => e.email).IsUnique();
            entity.Property(e => e.password).IsRequired();
            entity.Property(e => e.Name).IsRequired();
            entity.Property(e => e.PhoneNumber).IsRequired(false);
            entity.Property(e => e.About).IsRequired(false);
            entity.Property(e => e.ProfilePictureUrl).IsRequired(false);
        });

    }

    
}