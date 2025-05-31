using GroupService.Domain.Entities;
using GroupService.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace GroupService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TestController:ControllerBase
{

    private readonly IGroupRepository _groupRepository;

    public TestController(IGroupRepository groupRepository)
    {
        _groupRepository = groupRepository;
    }
    [HttpPost("add")]
    public async Task<IActionResult> Add(Group group)
    {
        await _groupRepository.AddGroupAsync(group);
        return Ok();
    }

    [HttpGet("all")]
    public async Task<IActionResult> GetAll()
    {
        var groups = await _groupRepository.GetAllGroupsAsync();
        return Ok(groups);
    }
}