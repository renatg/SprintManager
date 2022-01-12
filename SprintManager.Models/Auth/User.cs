using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace SprintManager.Models.Auth;

[Index ("Login", IsUnique = true, Name = "Login_Unique_Index") ]
public class User
{
    public int Id { get; set; }
    
    [Required]
    public string Login { get; set; }
    
    [Required]
    public string PasswordHash { get; set; }
    
    [Required]
    public string email { get; set; }
    
    [Required]
    public int RoleId { get; set; }
    public virtual Role Role { get; set; }
    public virtual List<Task> Tasks { get; set; }
}