using Microsoft.EntityFrameworkCore;
using SprintManager.Models.Auth;
using SprintManager.Models;

namespace SprintManager.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
    {
        
    }

    public DbSet<User> Users { get; set; } = null!;
    public DbSet<Role> Roles { get; set; } = null!;
    public DbSet<Models.Task> Tasks { get; set; } = null!;
    public DbSet<Sprint> Sprints { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseLazyLoadingProxies();
    }
}