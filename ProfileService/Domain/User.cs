namespace ProfileService.Domain;

public class User
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string PhoneNumber { get; set; }
    
    public string email { get; set; }
    public string password { get; set; }
    public string? About { get; set; }
    public string? ProfilePictureUrl { get; set; }

}
