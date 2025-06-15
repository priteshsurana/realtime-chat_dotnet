namespace ProfileService.Domain;

public class SignUpRequest
{
    public required string Email { get; set; }
    public required string Password { get; set; }
    public required string Username { get; set; }
    public required string Name { get; set; }
    public string? PhoneNumber { get; set; }
    public string? About { get; set; }
}
