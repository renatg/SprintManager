using Microsoft.AspNetCore.Mvc;
using SprintManager.DTO;
using SprintManager.Services.Interfaces;
using SprintManager.Services.Services;

namespace SprintManager.WebApi.Controllers;

[ApiController]
public class SprintController : ControllerBase
{
    private readonly ISprintService _sprintService;

    public SprintController(ISprintService sprintService)
    {
        _sprintService = sprintService;
    }
    
    [HttpGet]
    [Route("[controller]/getActive")]
    public async Task<SprintDto> GetActiveAsync()
    {
        return await _sprintService.GetActiveSprintAsync();
    }

    [HttpGet]
    [Route("[controller]/getAll")]
    public async Task<IEnumerable<SprintDto>> GetAllAsync()
    {
        return await _sprintService.GetAllSprintsAsync();
    }

    [HttpPost]
    [Route("[controller]/create")]
    public async Task<SprintDto> CreateAsync(SprintDto sprintDto)
    {
        return await _sprintService.CreateAsync(sprintDto);
    }

    [HttpPut]
    [Route("[controller]/edit")]
    public async Task<SprintDto> EditAsync(SprintDto sprintDto)
    {
        return await _sprintService.EditAsync(sprintDto);
    }

    [HttpPut]
    [Route("[controller]/start")]
    public async Task<SprintDto> StartAsync(int sprintId)
    {
        return await _sprintService.StartAsync(sprintId);
    }
    
    [HttpPut]
    [Route("[controller]/stop")]
    public async Task<SprintDto> StopAsync(int sprintId)
    {
        return await _sprintService.StopAsync(sprintId);
    }
}