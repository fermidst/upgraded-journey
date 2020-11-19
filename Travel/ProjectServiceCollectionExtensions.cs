using AutoMapper;
using Travel.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Travel.Services;

namespace Travel
{
    internal static class ProjectServiceCollectionExtensions
    {
        public static IServiceCollection AddProjectMappers(this IServiceCollection services) =>
            services.AddAutoMapper(typeof(Startup));

        public static IServiceCollection AddProjectServices(this IServiceCollection services,
            IConfiguration configuration) =>
            services
                .AddDbContext<TravelDbContext>(builder =>
                    builder.UseSqlite(configuration.GetConnectionString("TravelDbContext")))
                .AddScoped<ITravelDbContext, TravelDbContext>()
                .AddScoped<ITicketService, TicketService>()
                .AddScoped<IBuyerService, BuyerService>();
    }
}