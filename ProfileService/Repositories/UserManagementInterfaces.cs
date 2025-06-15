using ProfileService.Domain;
using ProfileService.Dtos;

namespace ProfileService.Application.Interfaces
{
    public interface IUserRepository
    {
        Task<User?> GetByEmailAsync(string email);
        Task<User?> GetByIdAsync(int id);
        Task<User> CreateAsync(User user);
        Task UpdateAsync(User user);
    }

    public interface IAuthService
    {
        Task<ApiResponseDto<SignUpResponseDto>> SignUpAsync(SignUpRequestDto request);
        Task<ApiResponseDto<LoginResponseDto>> LoginAsync(LoginRequestDto request);
    }

    public interface IPasswordHasher
    {
        string HashPassword(string password);
        bool VerifyPassword(string password, string hash);
    }

    public interface IJwtService
    {
        string GenerateToken(User user);
    }
}