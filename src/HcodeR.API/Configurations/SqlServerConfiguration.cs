using HcodeR.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HcodeR.API.Configurations
{
    public static class SqlServerConfiguration
    {
        public static IServiceCollection AddSqlServerConfiguration(
            this IServiceCollection services, 
            IConfiguration configuration)
        {
            services.AddDbContext<HcodeRContext>(options =>
               options.UseSqlServer(configuration["ConnectionStrings:DefaultConnection"]));

            return services;
        }
    }
}
