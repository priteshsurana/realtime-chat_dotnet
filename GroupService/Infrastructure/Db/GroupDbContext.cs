using System.Text.Json;
using GroupService.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GroupService.Infrastructure.Db;

public class GroupDbContext:DbContext
{
    public GroupDbContext(DbContextOptions<GroupDbContext> options) : base(options)
    {
    }
    
    public DbSet<Group> Groups => Set<Group>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Group>().HasKey(g => g.Id);
        modelBuilder.Entity<Group>().Property(g => g.Name).IsRequired();
        
        // modelBuilder.Entity<Group>()
        //     .Property(g => g.Members)
        //     .HasConversion(
        //         v => JsonSerializer.Serialize(v, null),
        //         v => JsonSerializer.Deserialize<List<string>>(v, null));
    }
    
    
}