namespace MessageStorageService.Domain.Entities;

public class Conversation
{
    public int ConversationId { get; set; }
    public string Type { get; set; }
    public int? LastMessageId { get; set; }
    public DateTime CreatedAt { get; set; }
}