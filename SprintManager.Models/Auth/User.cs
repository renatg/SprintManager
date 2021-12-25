using System.ComponentModel.DataAnnotations;

namespace SprintManager.Models.Auth;

public class User
{
    public int Id { get; set; }
    public string Login { get; set; }
    public string PasswordHash { get; set; }
    public string email { get; set; }
    public int RoleId { get; set; }
    public virtual Role Role { get; set; }
}