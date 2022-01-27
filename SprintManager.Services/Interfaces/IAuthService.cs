using SprintManager.DTO.Auth;

namespace SprintManager.Services.Interfaces;

public interface IAuthService
{
    Task<UserDto> RegistrationAsync(UserDto userDto);
    Task<JwtDto?> LoginAsync(CredentialsDto credentials);
    Task<List<RoleDto>> GetAllRolesAsync();

    Task<bool> CheckLoginUnique(string login);
}