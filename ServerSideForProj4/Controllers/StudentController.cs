using LMSLibrary;
using LMSLibrary.Models;
using LMSLibrary2._0.DTO_s;
using LMSLibrary2._0.DTOs;
using Microsoft.AspNetCore.Mvc;
using ServerSideForProj4.ECs;

namespace ServerSideForProj4.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly ILogger<StudentController> _logger;

        public StudentController(ILogger<StudentController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetStudent")]
        public List<Person> Get()
        {
            return FakeDatabase.People;
        }

        [HttpPost(Name = "AddOrUpdateStudent")]
        public StudentDTO AddOrUpdateStudent([FromBody] StudentDTO person)
        {
            return new StudentEC().AddOrUpdateStudent(person);
        }

        [HttpDelete(Name = "DeleteStudent")]
        public StudentDTO DeleteStudent([FromBody] StudentDTO person)
        {
            return new StudentEC().RemoveStudent(person);
        }
    }
}
