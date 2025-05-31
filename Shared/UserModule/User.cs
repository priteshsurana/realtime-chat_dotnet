namespace Shared.UserModule;

public class User
{
    public Guid UserId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public string About { get; set; } = string.Empty;
    public string ProfilePictureUrl { get; set; } = string.Empty;

}