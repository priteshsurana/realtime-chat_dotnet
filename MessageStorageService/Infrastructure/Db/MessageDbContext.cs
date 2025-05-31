using MessageStorageService.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MessageStorageService.Infrastructure.Db;

public class MessageDbContext : DbContext
{
    public MessageDbContext(DbContextOptions<MessageDbContext> options) : base(options)
    {
    }
    
    public DbSet<Conversation> Conversations => Set<Conversation>();
    public DbSet<Message> Messages => Set<Message>();
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Conversation>().HasKey(c => c.ConversationId);
        modelBuilder.Entity<Message>().HasKey(m => m.MessageId);
    }
}