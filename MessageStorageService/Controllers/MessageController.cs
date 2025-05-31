using MessageStorageService.Domain.Entities;
using MessageStorageService.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace MessageStorageService.Controllers;

public class MessageController: ControllerBase
{
    private readonly IMessageRepository _messageRepository;
    
    public MessageController(IMessageRepository messageRepository)
    {
        _messageRepository = messageRepository;
    }

    [HttpPost("add")]
    public async Task<IActionResult> Add([FromBody] Message message)
    {
        await _messageRepository.SaveMessageAsync(message);
        return Ok();
    }

    [HttpGet("recent")]
    public async Task<IActionResult> GetRecentMessages(Guid conversationId, int limit)
    {
        var messages = await _messageRepository.GetRecentMessagesAsync(conversationId, limit);
        return Ok(messages);
    }
}