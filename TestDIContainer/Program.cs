using System.IO.Abstractions;
using BusinessLogicLayer.Interface;
using DataAccessLayer.Interface;
using PresentationLayer.Interface;

//DAL
IPersonRepository personRepository = DataAccessLayer.CompositeRoot.CreatePersonRepository(new FileSystem());

//BLL
IPersonService personService = BusinessLogicLayer.CompositeRoot.CreatePersonService(personRepository);

//PL
IConsoleWriter personConsoleWriter = PresentationLayer.CompositeRoot.CreatePersonConsoleWriter(personService);

personConsoleWriter.Write();