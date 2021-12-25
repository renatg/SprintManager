using Microsoft.EntityFrameworkCore;
using SprintManager.Models.Auth;
using SprintManager.Models;

namespace SprintManager.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
    {
        
    }
    
    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<Models.Task> Tasks { get; set; }
    public DbSet<Sprint> Sprints { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseLazyLoadingProxies();
    }
}