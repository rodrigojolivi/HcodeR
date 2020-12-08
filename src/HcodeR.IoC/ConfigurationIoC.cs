using HcodeR.Application.Contracts;
using HcodeR.Application.Services;
using HcodeR.Domain.Contracts.Repositories;
using HcodeR.Domain.Contracts.Services;
using HcodeR.Domain.Services;
using HcodeR.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace HcodeR.IoC
{
    public static class ConfigurationIoC
    {
        public static IServiceCollection AddConfigurationIoC(this IServiceCollection services)
        {
            // Application
            services.AddScoped<IClienteAppService, ClienteAppService>();

            // Services
            services.AddScoped<IClienteService, ClienteService>();

            // Repositories
            services.AddScoped<IClienteRepository, ClienteRepository>();
            
            return services;
        }
    }
}
