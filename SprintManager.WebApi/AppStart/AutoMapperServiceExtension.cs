using AutoMapper;
using SprintManager.Profiles;

namespace SprintManager.WebApi.AppStart
{
    public static class AutoMapperServiceExtension
    {
        public static IServiceCollection AddAutoMapperCustom(this IServiceCollection services)
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

            return services;
        }
    }
}