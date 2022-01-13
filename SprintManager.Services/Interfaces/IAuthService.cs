using SprintManager.DTO.Auth;

namespace SprintManager.Services.Interfaces;

public interface IAuthService
{
    Task<UserDto> RegistrationAsync(UserDto userDto);
    string? Login(CredentialsDto credentials);
    Task<List<RoleDto>> GetAllRolesAsync();
}