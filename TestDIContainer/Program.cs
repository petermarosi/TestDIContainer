using System.IO.Abstractions;
using BusinessLogicLayer.Interface;
using DataAccessLayer.Interface;
using PresentationLayer.Interface;

using static BusinessLogicLayer.ServiceCollectionExtension;
using static DataAccessLayer.ServiceCollectionExtension;
using static PresentationLayer.ServiceCollectionExtension;

//DAL
IPersonRepository personRepository = CreatePersonRepository(new FileSystem());

//BLL
IPersonService personService = CreatePersonService(personRepository);

//PL
IConsolePersonWriter personConsolePersonWriter = CreatePersonConsoleWriter(personService);

personConsolePersonWriter.WriteAll(person => person.Name);
personConsolePersonWriter.WriteAll(person => person.Address);