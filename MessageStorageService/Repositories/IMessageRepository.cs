using MessageStorageService.Domain.Entities;

namespace MessageStorageService.Repositories;

public interface IMessageRepository
{
    Task SaveMessageAsync(Message message);
    Task<List<Message>> GetRecentMessagesAsync(Guid conversationId, int limit);
}