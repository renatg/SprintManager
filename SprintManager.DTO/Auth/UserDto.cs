namespace SprintManager.DTO.Auth;
public class UserDto
{
    public int Id { get; set; }
    public string Login { get; set; }
    public string PasswordHash { get; set; }
    public string email { get; set; }
    public int RoleId { get; set; }
}