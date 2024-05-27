using BusinessLogicLayer.Interface;
using Microsoft.Extensions.DependencyInjection;

namespace BusinessLogicLayer;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddPersonService(this IServiceCollection services)
    {
        services.AddTransient<IPersonService, PersonService>();

        return services;
    }
}