using SprintManager.Data.Repositories.Interfaces;
using SprintManager.Models;

namespace SprintManager.Data.Repositories;

public class SprintRepository : RepositoryBase<Sprint>, ISprintRepository
{
    public SprintRepository(AppDbContext context) : base(context)
    {
    }
}