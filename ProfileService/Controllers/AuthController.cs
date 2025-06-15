using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using ProfileService.Application.Interfaces;
using ProfileService.Dtos;

namespace ProfileService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly Services.ProfileService _profileService;

    public AuthController(Services.ProfileService profileService)
    {
        _profileService = profileService;
    }

    [HttpPost("signup")]
    public async Task<ActionResult<ApiResponseDto<SignUpResponseDto>>> SignUp([FromBody] SignUpRequestDto request)
    {
        try
        {
            var user = await _profileService.SignUpAsync(
                request.Email,
                request.Password,
                request.Username,
                request.Name,
                request.PhoneNumber,
                request.About
            );
            
            var response = new ApiResponseDto<SignUpResponseDto>
            {
                Success = true,
                Message = "User registered successfully",
                Data = new SignUpResponseDto
                {
                    UserId = user.Id,
                    Email = user.email,
                    Username = user.Name,
                    Message = "Registration successful"
                }
            };
            
            return Ok(response);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(new ApiResponseDto<SignUpResponseDto>
            {
                Success = false,
                Message = ex.Message
            });
        }
        catch (InvalidOperationException ex)
        {
            return Conflict(new ApiResponseDto<SignUpResponseDto>
            {
                Success = false,
                Message = ex.Message
            });
        }
    }

    [HttpPost("login")]
    public async Task<ActionResult<ApiResponseDto<LoginResponseDto>>> Login([FromBody] LoginRequestDto request)
    {
        try
        {
            var user = await _profileService.LoginAsync(request.Email, request.Password);
            
            var response = new ApiResponseDto<LoginResponseDto>
            {
                Success = true,
                Message = "Login successful",
                Data = new LoginResponseDto
                {
                    UserId = user.Id,
                    Email = user.email,
                    Username = user.Name,
                    Token = "JWT_TOKEN_HERE" // You'll need to implement JWT token generation
                }
            };
            
            return Ok(response);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(new ApiResponseDto<LoginResponseDto>
            {
                Success = false,
                Message = ex.Message
            });
        }
        catch (InvalidOperationException ex)
        {
            return Unauthorized(new ApiResponseDto<LoginResponseDto>
            {
                Success = false,
                Message = ex.Message
            });
        }
    }
}
