namespace GroupService.Domain.Entities;

public class Group
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string OwnerId { get; set; }
    public string ProfilePicURL { get; set; }
    public bool IsPublic { get; set; }
    public List<GroupMember> Members { get; set; } = new ();
    public DateTime createdAt { get; set; }
}