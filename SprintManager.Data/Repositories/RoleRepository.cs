using SprintManager.Data.Repositories.Interfaces;
using SprintManager.Models.Auth;

namespace SprintManager.Data.Repositories;

public class RoleRepository: RepositoryBase<Role>, IRoleRepository
{
    public RoleRepository(AppDbContext context) : base(context)
    {
    }
}