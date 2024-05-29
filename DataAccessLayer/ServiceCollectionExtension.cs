﻿using DataAccessLayer.Interface;
using DataAccessLayer.Xml;
using Microsoft.Extensions.DependencyInjection;
using System.IO.Abstractions;
using CommonServices;
using DataAccessLayer.Interfaces;

namespace DataAccessLayer;

public static class ServiceCollectionExtension
{
    //DI container
    public static IServiceCollection AddTransientBasicXmlReader(this IServiceCollection services, IFileSystem fileSystem)
    {
        services.AddTransient<IBasicXmlReader>(_ => new BasicXmlReader(fileSystem));
        
        return services;
    }

    public static IServiceCollection AddTransientPersonFactory(this IServiceCollection services)
    {
        services.AddTransient<IPersonFactory>(s => new PersonFactoryProxy(
            new PersonFactory(),
            s.GetRequiredService<ILogger>()));

        return services;
    }

    public static IServiceCollection AddTransientXmlPersonMapper(this IServiceCollection services)
    {
        services.AddTransient<IXmlModelMapper<IPerson>>(s => new XmlPersonMapper(
            s.GetRequiredService<IBasicXmlReader>(),
            s.GetRequiredService<IPersonFactory>()));

        return services;
    }

    public static IServiceCollection AddTransientPersonRepository(this IServiceCollection services, IFileSystem fileSystem)
    {
        services.AddTransient<IPersonRepository>(s => new PersonRepository(new PersonContext(
            fileSystem,
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
                    new PersonFactoryProxy(new PersonFactory(), logger))));
    }
}