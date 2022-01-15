using SprintManager.DTO;

namespace SprintManager.Services.Interfaces;

public interface ISprintService
{
    Task<SprintDto> CreateAsync(SprintDto sprintDto);
    Task<SprintDto> EditAsync(SprintDto sprintDto);
    Task<SprintDto> StartAsync(int sprintId);
    Task<SprintDto> StopAsync(int sprintId);
    Task<IList<SprintDto>> GetAllSprintsAsync();
    Task<SprintDto> GetActiveSprintAsync();
}