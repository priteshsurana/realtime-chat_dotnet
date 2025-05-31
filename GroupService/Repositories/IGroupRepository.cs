using GroupService.Domain.Entities;

namespace GroupService.Repositories;

public interface IGroupRepository
{
    Task<Group> GetGroupByIdAsync(Guid groupId);
    Task AddGroupAsync(Group group);
    Task<List<Group>> GetAllGroupsAsync();
}