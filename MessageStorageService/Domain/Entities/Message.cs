namespace MessageStorageService.Domain.Entities;

public class Message
{
    public Guid MessageId { get; set; }
    public int ConversationId { get; set; }
    public int SenderId { get; set; }
    public MessageType MessageType { get; set; }
    public string MessageBody { get; set; }
    public string? AttachmentUrl { get; set; }
    public DateTime SentAt { get; set; }
    public MessageStatus Status { get; set; }
}