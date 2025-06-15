namespace ProfileService.Dtos;

public class SignUpRequestDto
{
    //TODO: Add [Required] [MinLength()] where required
    public required string Email { get; set; }
    public required string Password { get; set; }
    public required string Username { get; set; }
    public required string Name { get; set; }
    public string? PhoneNumber { get; set; }
    public string? About { get; set; }
}
