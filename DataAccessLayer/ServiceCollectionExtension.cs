using DataAccessLayer.Interface;
using DataAccessLayer.Xml;
using Microsoft.Extensions.DependencyInjection;
using System.IO.Abstractions;
using CommonServices;
using DataAccessLayer.Interfaces;

namespace DataAccessLayer;

public static class ServiceCollectionExtension
{
    //DI container
    public static IServiceCollection AddDalInternalServices(this IServiceCollection services)
    {
        services
            .AddTransient<IBasicXmlReader, BasicXmlReader>()
            .AddTransient<IPersonFactory, PersonFactory>()
            //Decorate is Scrutor feature, PersonFactory needs to be defined first to be able to decorate it
            .Decorate<IPersonFactory, PersonFactoryLoggerDecorator>()
            .AddTransient<IXmlModelMapper<IPerson>, XmlPersonMapper>()
            .AddTransient<IPersonRepository>(s => new PersonRepository(new PersonContext(
                s.GetRequiredService<IFileSystem>(),
                "XMLFile1.xml",
                s.GetRequiredService<IXmlModelMapper<IPerson>>())));

        return services;
    }

    //Poor man's DI
    public static IPersonRepository CreatePersonRepository(IFileSystem fileSystem, ILogger logger)
    {
        return new PersonRepository(
            new PersonContext(fileSystem, "XMLFile1.xml",
                new XmlPersonMapper(
                    new BasicXmlReader(fileSystem),
                    new PersonFactoryLoggerDecorator(new PersonFactory(), logger))));
    }
}