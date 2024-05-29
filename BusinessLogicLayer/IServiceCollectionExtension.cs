using BusinessLogicLayer.Interface;
using DataAccessLayer.Interface;
using Microsoft.Extensions.DependencyInjection;

namespace BusinessLogicLayer;

public static class ServiceCollectionExtension
{
    //DI container
    public static IServiceCollection AddTransientPersonService(this IServiceCollection services)
    {
        services.AddTransient<IPersonService, PersonService>();

        return services;
    }

    //Poor man's DI
    public static IPersonService CreatePersonService(IPersonRepository personRepository)
    {
        return new PersonService(personRepository);
    }
}