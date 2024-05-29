using BusinessLogicLayer;
using DataAccessLayer;
using Microsoft.Extensions.DependencyInjection;
using PresentationLayer;
using PresentationLayer.Interface;
using System.IO.Abstractions;

ServiceCollection services = new();
IFileSystem fileSystem = new FileSystem();

services
    //DAL
    .AddTransientBasicXmlReader(fileSystem)
    .AddTransientXmlPersonMapper()
    .AddTransientPersonRepository(fileSystem)
    //BLL
    .AddTransientPersonService()
    //PL
    .AddTransientConsolePersonWriter();

IServiceProvider provider = services.BuildServiceProvider();

IConsolePersonWriter personWriter = provider.GetRequiredService<IConsolePersonWriter>();

personWriter.WriteAll(person => person.Name);
personWriter.WriteAll(person => person.Address);