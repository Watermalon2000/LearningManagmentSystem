using LMSLibrary;
using LMSLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using ServerSideForProj4.ECs;
using System.Xml.Linq;
using LMSLibrary2._0.DTO_s;
using LMSLibrary2._0.DTOs;

namespace ServerSideForProj4.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonController : ControllerBase
{
        private readonly ILogger<PersonController> _logger;

        public PersonController(ILogger<PersonController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetPerson")]
        public List<Person> Get()
        {
            return FakeDatabase.People;
        }

        [HttpPost(Name = "AddOrUpdatePerson")]
        public PersonDTO AddOrUpdatePerson([FromBody] Person person)
        {
            PersonDTO personDTO = new PersonDTO();
            if(person is Student)
            {
                personDTO = new StudentDTO(person);
            }else if (person is Instructor)
            {
                personDTO = new InstructorDTO(person);
            }
            else if (person is TeacherAssistant)
            {
                personDTO = new TeacherAssistantDTO(person);
            }
            else
            {
                personDTO = new PersonDTO(person);
            }
            return new PersonEC().AddOrUpdatePerson(personDTO);
        }

        [HttpDelete(Name = "DeletePerson")]
        public PersonDTO DeletePerson([FromBody] PersonDTO person)
        {
            return new PersonEC().RemovePerson(person);
        }
    }
}
