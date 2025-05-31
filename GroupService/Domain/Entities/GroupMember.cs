namespace GroupService.Domain.Entities;

public class GroupMember
{
    public int UserId { get; set; }
    public Guid GroupId { get; set; }
    public Role Role { get; set; }
    public DateTime joinedAt { get; set; }
}