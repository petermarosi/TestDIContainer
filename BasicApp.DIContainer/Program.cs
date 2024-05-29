using BusinessLogicLayer;
using CommonServices;
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
    .AddTransientPersonFactory()
    .AddTransientXmlPersonMapper()
    .AddTransientPersonRepository(fileSystem)
    //BLL
    .AddTransientPersonService()
    //PL
    .AddTransientConsolePersonWriter();

//Common services
services.AddSingleton<ILogger, Logger>();

IServiceProvider provider = services.BuildServiceProvider();

IConsolePersonWriter personWriter = provider.GetRequiredService<IConsolePersonWriter>();
ILogger logger = provider.GetRequiredService<ILogger>();

personWriter.WriteAll(person => person.Name);
personWriter.WriteAll(person => person.Address);
logger.PrintAllMessages();