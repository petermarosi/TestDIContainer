using BusinessLogicLayer.Interface;
using Microsoft.Extensions.DependencyInjection;
using PresentationLayer.Interface;

namespace PresentationLayer;

public static class ServiceCollectionExtension
{
    //DI container
    public static IServiceCollection AddTransientConsolePersonWriter(this IServiceCollection services)
    {
        services.AddTransient<IConsolePersonWriter, ConsolePersonPersonWriter>();

        return services;
    }

    //Poor man's DI
    public static IConsolePersonWriter CreatePersonConsoleWriter(IPersonService personService)
    {
        return new ConsolePersonPersonWriter(personService);
    }
}