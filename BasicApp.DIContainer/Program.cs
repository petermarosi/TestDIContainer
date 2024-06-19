using BusinessLogicLayer;
using CommonServices;
using DataAccessLayer;
using Microsoft.Extensions.DependencyInjection;
using PresentationLayer;
using PresentationLayer.Interface;
using System.IO.Abstractions;

ServiceCollection services = new();

//Add internal services
services
    .AddDalInternalServices()
    .AddBllInternalServices()
    .AddPlInternalServices();

//Common services
services.AddSingleton<ILogger, Logger>();
services.AddSingleton<IFileSystem, FileSystem>();

IServiceProvider provider = services.BuildServiceProvider();

IConsolePersonWriter personWriter = provider.GetRequiredService<IConsolePersonWriter>();
ILogger logger = provider.GetRequiredService<ILogger>();

personWriter.WriteAll(person => person.Name);
personWriter.WriteAll(person => person.Address);
logger.PrintAllMessages();