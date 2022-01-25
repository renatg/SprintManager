using System.Net;
using Microsoft.AspNetCore.Mvc;
using SprintManager.DTO.Auth;
using SprintManager.Services.Interfaces;

namespace SprintManager.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthorizationController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthorizationController(IAuthService authService)
    {
        _authService = authService;
    }
    
    [HttpPost]
    [Route("registration")]
    public async Task<IActionResult> Registration([FromBody] UserDto userDto)
    {
        try
        {
            await _authService.RegistrationAsync(userDto);
        }
        catch (Exception e)
        {
            return StatusCode((int) HttpStatusCode.Conflict, e.Message);
        }
        
        return Ok();
    }

    [HttpPost]
    [Route("login")]
    public async Task<IActionResult> LoginAsync([FromBody] CredentialsDto credentialsDto)
    {
        var jwt = await _authService.LoginAsync(credentialsDto);
        if (jwt == null)
        {
            return BadRequest(new { errorText = "Invalid username or password." });
        }

        return Ok(jwt);
    }

    [HttpGet]
    [Route("GetAllRoles")]
    public IEnumerable<RoleDto> GetAllRoles()
    {
        return _authService.GetAllRolesAsync().Result;
    }

    [HttpGet]
    [Route("checkLoginUnique")]
    public async Task<bool> CheckLoginUnique(string login)
    {
        return await _authService.CheckLoginUnique(login);
    }
}