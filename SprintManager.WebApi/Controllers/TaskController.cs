using Microsoft.AspNetCore.Mvc;
using SprintManager.DTO;
using SprintManager.Services.Interfaces;

namespace SprintManager.WebApi.Controllers;

[ApiController]
public class TaskController : ControllerBase
{
    private readonly ITaskService _taskService;

    public TaskController(ITaskService taskService)
    {
        _taskService = taskService;
    }

    [HttpGet]
    [Route("[controller]/getBackLog")]
    public async Task<IEnumerable<TaskDto>> GetBackLogAsync()
    {
        return await _taskService.GetAllTasks();
    }

    [HttpPost]
    [Route("[controller]/create")]
    public async Task<TaskDto> CreateTaskAsync(TaskDto taskDto)
    {
        return await _taskService.CreateAsync(taskDto);
    }
    
    [HttpPut]
    [Route("[controller]/edit")]
    public async Task<TaskDto> EditTaskAsync(TaskDto taskDto)
    {
        return await _taskService.EditAsync(taskDto);
    }
    
    [HttpPost]
    [Route("[controller]/changeStatus")]
    public async Task<TaskDto> ChangeStatusAsync(TaskStatusDto taskStatusDto)
    {
        return await _taskService.ChangeStatus(taskStatusDto);
    }
    
    [HttpPost]
    [Route("[controller]/changePriority")]
    public async Task<TaskDto> ChangePriorityAsync(TaskPriorityDto taskPriorityDto)
    {
        return await _taskService.ChangePriority(taskPriorityDto);
    }
}