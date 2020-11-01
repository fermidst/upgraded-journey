using AutoMapper;
using HRSystem.Infrastructure;
using HRSystem.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HRSystem
{
    internal static class ProjectServiceCollectionExtensions
    {
        public static IServiceCollection AddProjectMappers(this IServiceCollection services) =>
            services.AddAutoMapper(typeof(Startup));
        public static IServiceCollection AddProjectServices(this IServiceCollection services,
            IConfiguration configuration) =>
            services
                .AddDbContext<HRSystemDbContext>(builder =>
                    builder.UseSqlite(configuration.GetConnectionString("HRSystemDbContext")))
                .AddScoped<IHRSystemDbContext, HRSystemDbContext>()
                .AddScoped<IEmployeeService, EmployeeService>();
    }
}