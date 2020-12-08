using AutoMapper;
using HcodeR.Application.Mapper;
using Microsoft.Extensions.DependencyInjection;

namespace HcodeR.API.Configurations
{
    public static class AutoMapperConfiguration
    {
        public static IServiceCollection AddAutoMapperConfiguration(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(DomainToDto), typeof(DtoToDomain));

            return services;
        }
    }
}
