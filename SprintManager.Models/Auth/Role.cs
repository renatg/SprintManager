using System.ComponentModel.DataAnnotations;

namespace SprintManager.Models.Auth;

public class Role
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public virtual List<User> Users { get; set; } = null!;
}