using SprintManager.Data.Repositories.Interfaces;
using SprintManager.Models.Auth;

namespace SprintManager.Data.Repositories;

public class UserRepository: RepositoryBase<User>, IUserRepository
{
    public UserRepository(AppDbContext context) : base(context)
    {
    }
}