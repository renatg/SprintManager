using AutoMapper;
using SprintManager.Data.Repositories.Interfaces;
using SprintManager.DTO;
using SprintManager.Services.Interfaces;
using Task = SprintManager.Models.Task;

namespace SprintManager.Services.Services;

public class TaskService : ITaskService
{
    private readonly ITaskRepository _taskRepository;
    private readonly IMapper _mapper;

    public TaskService(ITaskRepository taskRepository, IMapper mapper)
    {
        _taskRepository = taskRepository;
        _mapper = mapper;
    }
    public async Task<TaskDto> CreateAsync(TaskDto taskDto)
    {
        var task = _mapper.Map<Task>(taskDto);
        var newTask = await _taskRepository.InsertAsync(task);
        return _mapper.Map<TaskDto>(newTask);
    }

    public async Task<TaskDto> EditAsync(TaskDto taskDto)
    {
        var task = _mapper.Map<Task>(taskDto);
        return await UpdateTaskAsync(task);
    }

    public async Task<TaskDto> ChangeStatusAsync(TaskStatusDto taskStatusDto)
    {
        var task = await _taskRepository.GetFirstWhereAsync(x => x.Id == taskStatusDto.TaskId);
        if (task == null)
            throw new Exception("");
        
        task.TaskStatus = taskStatusDto.Status;
        return await UpdateTaskAsync(task);
    }

    public async Task<TaskDto> ChangePriorityAsync(TaskPriorityDto taskPriorityDto)
    {
        var task = await _taskRepository.GetFirstWhereAsync(x => x.Id == taskPriorityDto.TaskId);
        if (task == null)
            throw new Exception("");

        task.Priority = taskPriorityDto.Priority;
        return await UpdateTaskAsync(task);
    }

    public async Task<List<TaskDto>> GetAllTasksAsync()
    {
        var tasks = await _taskRepository.GetAllAsync();
        return _mapper.Map<List<TaskDto>>(tasks);
    }

    public async Task<List<TaskDto>> GetAllTasksBySprintAsync(int sprintId)
    {
        var tasks = await _taskRepository.FindAllByWhereAsync(x => x.SprintId == sprintId);
        return _mapper.Map<List<TaskDto>>(tasks);
    }

    public async Task<TaskDto> AddToSprintAsync(TaskToSprintDto taskToSprintDto)
    {
        var task = await _taskRepository.GetFirstWhereAsync(x => x.Id == taskToSprintDto.TaskId);
        if (task == null)
            throw new Exception("");

        task.SprintId = taskToSprintDto.SprintId;
        return await UpdateTaskAsync(task);
    }

    private async Task<TaskDto> UpdateTaskAsync(Task task)
    {
        var updatedTask = await _taskRepository.UpdateAsync(task);
        return _mapper.Map<TaskDto>(updatedTask);
    }
}