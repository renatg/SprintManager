using AutoMapper;
using SprintManager.DTO;
using SprintManager.DTO.Auth;
using SprintManager.Models.Auth;
using SprintManager.Models;
using Task = SprintManager.Models.Task;

namespace SprintManager.Profiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<User, UserDto>();
        CreateMap<Role, RoleDto>();
        CreateMap<Task, TaskDto>();
        CreateMap<Sprint, SprintDto>();
    }
}