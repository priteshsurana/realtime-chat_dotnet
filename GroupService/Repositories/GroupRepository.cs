using GroupService.Domain.Entities;
using GroupService.Infrastructure.Db;
using Microsoft.EntityFrameworkCore;

namespace GroupService.Repositories;

public class GroupRepository: IGroupRepository
{
    private readonly GroupDbContext _dbContext;

    public GroupRepository(GroupDbContext context)
    {
        _dbContext = context;
    }
    
    public async Task<Group> GetGroupByIdAsync(Guid id) => await _dbContext.Groups.FindAsync(id);

    public async Task AddGroupAsync(Group group)
    {
        _dbContext.Groups.Add(group);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<List<Group>> GetAllGroupsAsync() => await _dbContext.Groups.ToListAsync();
}