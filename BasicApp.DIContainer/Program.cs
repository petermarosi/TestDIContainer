using BusinessLogicLayer;
using DataAccessLayer;
using Microsoft.Extensions.DependencyInjection;
using PresentationLayer;
using PresentationLayer.Interface;
using System.IO.Abstractions;

ServiceCollection services = new();

services
    //DAL
    .AddPersonRepository(new FileSystem())
    //BLL
    .AddPersonService()
    //PL
    .AddConsolePersonWriter();

IServiceProvider provider = services.BuildServiceProvider();

IConsoleWriter writer = provider.GetRequiredService<IConsoleWriter>();

writer.Write();