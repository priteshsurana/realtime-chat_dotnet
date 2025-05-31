using MessageStorageService.Domain.Entities;
using MessageStorageService.Infrastructure.Db;
using Microsoft.EntityFrameworkCore;

namespace MessageStorageService.Repositories;

public class MessageRepository:IMessageRepository
{
    private readonly MessageDbContext _messageDbContext;
    public MessageRepository(MessageDbContext messageDbContext)
    {
        _messageDbContext = messageDbContext;
    }
     public async Task SaveMessageAsync(Message message)
     {
         _messageDbContext.Messages.Add(message);
         await _messageDbContext.SaveChangesAsync();
     }
     
     public async Task<List<Message>> GetRecentMessagesAsync(Guid conversationId, int limit)
     {
         return await _messageDbContext.Messages.Where(m => m.MessageId == conversationId)
             .OrderByDescending(m => m.SentAt)
             .Take(limit).ToListAsync();
     }
}