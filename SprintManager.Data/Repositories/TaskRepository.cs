using SprintManager.Data.Repositories.Interfaces;
using Task = SprintManager.Models.Task;

namespace SprintManager.Data.Repositories;

public class TaskRepository : RepositoryBase<Task>, ITaskRepository
{
    public TaskRepository(AppDbContext context) : base(context)
    {
    }
}