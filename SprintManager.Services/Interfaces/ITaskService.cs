using SprintManager.DTO;

namespace SprintManager.Services.Interfaces;

public interface ITaskService
{
    Task<TaskDto> CreateAsync(TaskDto taskDto);
    Task<TaskDto> EditAsync(TaskDto taskDto);
    Task<TaskDto> ChangeStatusAsync(TaskStatusDto taskStatusDto);
    Task<TaskDto> ChangePriorityAsync(TaskPriorityDto taskPriorityDto);
    Task<List<TaskDto>> GetAllTasksAsync();
    Task<List<TaskDto>> GetAllTasksBySprintAsync(int sprintId);
    Task<TaskDto> AddToSprintAsync(TaskToSprintDto taskToSprintDto);
}