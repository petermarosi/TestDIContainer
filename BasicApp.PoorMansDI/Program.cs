using System.IO.Abstractions;
using BusinessLogicLayer.Interface;
using CommonServices;
using DataAccessLayer.Interface;
using PresentationLayer.Interface;

using static BusinessLogicLayer.ServiceCollectionExtension;
using static DataAccessLayer.ServiceCollectionExtension;
using static PresentationLayer.ServiceCollectionExtension;

//Common services
IFileSystem fileSystem = new FileSystem();
ILogger logger = new Logger();

//DAL
IPersonRepository personRepository = CreatePersonRepository(fileSystem, logger);

//BLL
IPersonService personService = CreatePersonService(personRepository);

//PL
IConsolePersonWriter personConsolePersonWriter = CreatePersonConsoleWriter(personService);

personConsolePersonWriter.WriteAll(person => person.Name);
personConsolePersonWriter.WriteAll(person => person.Address);
logger.PrintAllMessages();