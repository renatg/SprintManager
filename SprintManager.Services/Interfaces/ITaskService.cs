using SprintManager.DTO;

namespace SprintManager.Services.Interfaces;

public interface ITaskService
{
    Task<TaskDto> CreateAsync(TaskDto taskDto);
    Task<TaskDto> EditAsync(TaskDto taskDto);
    Task<TaskDto> ChangeStatus(TaskStatusDto taskStatusDto);
    Task<TaskDto> ChangePriority(TaskPriorityDto taskPriorityDto);
    Task<List<TaskDto>> GetAllTasks();
    Task<TaskDto> AddToSprint(TaskToSprintDto taskToSprintDto);
}