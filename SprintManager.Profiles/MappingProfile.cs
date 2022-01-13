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
        CreateMap<User, UserDto>().ForMember(x => x.Password, opt => opt.MapFrom(c => c.PasswordHash));
        CreateMap<UserDto, User>().ForMember(x => x.PasswordHash, opt => opt.MapFrom(c => c.Password));
        CreateMap<Role, RoleDto>();
        CreateMap<Task, TaskDto>();
        CreateMap<TaskDto, Task>();
        CreateMap<Sprint, SprintDto>();
    }
}