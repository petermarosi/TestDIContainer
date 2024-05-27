using Microsoft.Extensions.DependencyInjection;
using PresentationLayer.Interface;

namespace PresentationLayer;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddConsolePersonWriter(this IServiceCollection services)
    {
        services.AddTransient<IConsoleWriter, ConsolePersonWriter>();

        return services;
    }
}