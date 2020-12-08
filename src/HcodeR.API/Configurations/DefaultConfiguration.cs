using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace HcodeR.API.Configurations
{
    public static class DefaultConfiguration
    {
        public static IServiceCollection AddDefaultConfiguration(this IServiceCollection services)
        {
            services.AddControllers()
                .AddNewtonsoftJson();           
           
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });

            return services;
        }
    }
}
