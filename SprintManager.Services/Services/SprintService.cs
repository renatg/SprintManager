using AutoMapper;
using SprintManager.Data.Repositories.Interfaces;
using SprintManager.DTO;
using SprintManager.Models;
using SprintManager.Services.Interfaces;

namespace SprintManager.Services.Services;

public class SprintService : ISprintService
{
    private readonly ISprintRepository _sprintRepository;
    private readonly IMapper _mapper;

    public SprintService(ISprintRepository sprintRepository, IMapper mapper)
    {
        _sprintRepository = sprintRepository;
        _mapper = mapper;
    }
    public async Task<SprintDto> CreateAsync(SprintDto sprintDto)
    {
        var sprint = _mapper.Map<Sprint>(sprintDto);
        var newSprint = await _sprintRepository.InsertAsync(sprint);
        return _mapper.Map<SprintDto>(newSprint);
    }

    public async Task<SprintDto> EditAsync(SprintDto sprintDto)
    {
        var sprint = await EditSprint(_mapper.Map<Sprint>(sprintDto));
        return _mapper.Map<SprintDto>(sprint);
    }

    public async Task<SprintDto> StartAsync(int sprintId)
    {
        var sprint = await _sprintRepository.GetFirstWhereAsync(x => x.Id == sprintId);
        if (sprint == null)
            throw new Exception();

        sprint.Active = true;
        var editedSprint = await EditSprint(_mapper.Map<Sprint>(sprint));
        return _mapper.Map<SprintDto>(editedSprint);
    }

    public async Task<SprintDto> StopAsync(int sprintId)
    {
        var sprint = await _sprintRepository.GetFirstWhereAsync(x => x.Id == sprintId);
        if (sprint == null)
            throw new Exception();

        sprint.Active = false;
        var editedSprint = await EditSprint(_mapper.Map<Sprint>(sprint));
        return _mapper.Map<SprintDto>(editedSprint);
    }

    public async Task<IList<SprintDto>> GetAllSprintsAsync()
    {
        var sprints = await _sprintRepository.GetAllAsync();
        return _mapper.Map<IList<SprintDto>>(sprints);
    }

    public async Task<SprintDto> GetActiveSprintAsync()
    {
        var sprint = await _sprintRepository.GetFirstWhereAsync(x => x.Active);
        return _mapper.Map<SprintDto>(sprint);
    }

    private async Task<Sprint> EditSprint(Sprint sprint)
    {
        return await _sprintRepository.UpdateAsync(sprint);
    }
}