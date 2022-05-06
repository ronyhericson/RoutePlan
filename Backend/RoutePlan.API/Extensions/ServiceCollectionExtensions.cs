using Microsoft.Extensions.DependencyInjection;
using RoutePlan.API.CustomFormat;
using RoutePlan.Application.Services;
using RoutePlan.Application.Services.Interfaces;
using RoutePlan.Domain.Interfaces;
using RoutePlan.Infrastructure.Repositories;

namespace RoutePlan.API.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IRoutePlanRepository, RoutePlanRepository>();
            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IRoutePlanServices, RoutePlanServices>();
            return services;
        }

        public static IServiceCollection AddCustomFormat(this IServiceCollection services)
        {
            services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.Converters.Add(new DateTimeConverter());
            });

            return services;
        }
    }
}