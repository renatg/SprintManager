using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using AutoMapper;
using SprintManager.DTO.Auth;
using SprintManager.Models.Auth;
using SprintManager.Services.Interfaces;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.IdentityModel.Tokens;
using SprintManager.Data.Repositories.Interfaces;

namespace SprintManager.Services.Services;

public class AuthService : IAuthService
{
    private readonly IMapper _mapper;
    private readonly IUserRepository _userRepository;
    private readonly IRoleRepository _roleRepository;

    private const KeyDerivationPrf Pbkdf2Prf = KeyDerivationPrf.HMACSHA1;
    private const int Pbkdf2IterCount = 1000;
    private const int Pbkdf2SubkeyLength = 256 / 8;
    private const int SaltSize = 128 / 8;

    public AuthService(IUserRepository userRepository, IRoleRepository roleRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _roleRepository = roleRepository;
        _mapper = mapper;
    }
    public async Task<UserDto> RegistrationAsync(UserDto userDto)
    {
        userDto.Password = HashPassword(userDto.Password);
        var user = _mapper.Map<User>(userDto);
        var newUser = await _userRepository.InsertAsync(user);
        return _mapper.Map<UserDto>(newUser);
    }

    public async Task<string?> LoginAsync(CredentialsDto credentials)
    {
        var identity = await GetIdentityAsync(credentials);
        if (identity == null)
        {
            return null;
        }

        return GetJwt(identity);
    }

    public async Task<List<RoleDto>> GetAllRolesAsync()
    {
        var roles = await _roleRepository.GetAllAsync();
        return _mapper.Map<List<RoleDto>>(roles);
    }
    
    private async Task<ClaimsIdentity?> GetIdentityAsync(CredentialsDto credentials)
    {
        var user = await _userRepository.GetFirstWhereAsync(x =>
            x.Login == credentials.Login);
        
        if (user == null || !VerifyHashedPassword(user.PasswordHash, credentials.Password))
            return null;
            
        var claims = new List<Claim>
        {
            new Claim(ClaimsIdentity.DefaultNameClaimType, credentials.Login),
        };
        
        claims.Add(new Claim("role", user.Role.Name));
            
        ClaimsIdentity claimsIdentity =
            new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
                ClaimsIdentity.DefaultRoleClaimType);
        return claimsIdentity;
    }

    private string GetJwt(ClaimsIdentity identity)
    {
        var now = DateTime.UtcNow;
        
        var jwt = new JwtSecurityToken(
            issuer: AuthOptions.ISSUER,
            audience: AuthOptions.AUDIENCE,
            notBefore: now,
            claims: identity.Claims,
            expires: now.Add(TimeSpan.FromMinutes(AuthOptions.LIFETIME)),
            signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
        
        return new JwtSecurityTokenHandler().WriteToken(jwt);
    }

    private static string HashPassword(string password)
    {
        var salt = new byte[SaltSize];
        
        using (var rngCsp = new RNGCryptoServiceProvider())
        {
            rngCsp.GetBytes(salt);
        }
        
        var subkey = KeyDerivation.Pbkdf2(password, salt, Pbkdf2Prf, Pbkdf2IterCount, Pbkdf2SubkeyLength);

        var outputBytes = new byte[SaltSize + Pbkdf2SubkeyLength];
        
        Buffer.BlockCopy(salt, 0, outputBytes, 0, SaltSize);
        Buffer.BlockCopy(subkey, 0, outputBytes, SaltSize, Pbkdf2SubkeyLength);
        return Convert.ToBase64String(outputBytes);
    }
    
    private static bool VerifyHashedPassword(string hashedPassword, string password)
    {
        var hash = Convert.FromBase64String(hashedPassword);

        if (hash.Length != SaltSize + Pbkdf2SubkeyLength)
        {
            return false; 
        }

        var salt = new byte[SaltSize];
        Buffer.BlockCopy(hash, 0, salt, 0, salt.Length);

        var expectedSubkey = new byte[Pbkdf2SubkeyLength];
        Buffer.BlockCopy(hash, salt.Length, expectedSubkey, 0, expectedSubkey.Length);

        var actualSubkey = KeyDerivation.Pbkdf2(password, salt, Pbkdf2Prf, Pbkdf2IterCount, Pbkdf2SubkeyLength);

        return CryptographicOperations.FixedTimeEquals(actualSubkey, expectedSubkey);
    }
}