using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProfileService.Domain;

namespace ProfileService.Services;

public class ProfileService
{
    private readonly DbContext _context; // You'll need to inject your actual DbContext
    
    public ProfileService(DbContext context)
    {
        _context = context;
    }

    public async Task<User> SignUpAsync(string email, string password, string username, string name, string? phoneNumber = null, string? about = null)
    {
        // Validate email and password
        if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            throw new ArgumentException("Email and password are required");

        // Check if user already exists
        var existingUser = await _context.Set<User>()
            .FirstOrDefaultAsync(u => u.email == email);
            
        if (existingUser != null)
            throw new InvalidOperationException("User with this email already exists");

        // Hash password - You should use a proper password hashing library like BCrypt
        var hashedPassword = HashPassword(password);

        var user = new User
        {
            email = email,
            password = hashedPassword,
            Name = name,
            PhoneNumber = phoneNumber,
            About = about
        };

        await _context.Set<User>().AddAsync(user);
        await _context.SaveChangesAsync();

        return user;
    }

    public async Task<User> LoginAsync(string email, string password)
    {
        if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            throw new ArgumentException("Email and password are required");

        var user = await _context.Set<User>()
            .FirstOrDefaultAsync(u => u.email == email);

        if (user == null)
            throw new InvalidOperationException("User not found");

        // Verify password - You should use the same password hashing library as in SignUp
        if (!VerifyPassword(password, user.password))
            throw new InvalidOperationException("Invalid password");

        return user;
    }

    public Task<IActionResult> UpdateProfileAsync(User user)
    {
        throw new NotImplementedException();
    }
    
    private string HashPassword(string password)
    {
        // TODO: Implement proper password hashing here
        // Example: return BCrypt.HashPassword(password);
        throw new NotImplementedException("Implement proper password hashing");
    }

    private bool VerifyPassword(string password, string hashedPassword)
    {
        // TODO: Implement proper password verification here
        // Example: return BCrypt.Verify(password, hashedPassword);
        throw new NotImplementedException("Implement proper password verification");
    }
}
