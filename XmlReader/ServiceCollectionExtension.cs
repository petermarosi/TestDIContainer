using DataAccessLayer.Interface;
using DataAccessLayer.Xml;
using Microsoft.Extensions.DependencyInjection;
using System.IO.Abstractions;
using DataAccessLayer.Interfaces;

namespace DataAccessLayer;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddPersonRepository(this IServiceCollection services, IFileSystem fileSystem)
    {
        services.AddTransient<IBasicXmlReader>(_ => new BasicXmlReader(fileSystem));
        services.AddTransient<IXmlModelMapper<IPerson>, XmlPersonMapper>();
        services.AddTransient<IPersonRepository>(s => new PersonRepository(new PersonContext(
            fileSystem,
            "XMLFile1.xml",
            s.GetRequiredService<IXmlModelMapper<IPerson>>())));

        return services;
    }
}