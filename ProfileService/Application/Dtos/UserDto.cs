namespace ProfileService.Dtos;

public class UserDto
{
    public int Id { get; set; }
    public string Email { get; set; }
    public string Name { get; set; }
    public string Username { get; set; }
    public string? PhoneNumber { get; set; }
    public string? About { get; set; }
    public string? ProfilePictureUrl { get; set; }
}
