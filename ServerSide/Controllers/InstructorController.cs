using LMSLibrary.Models;
using LMSLibrary2._0.DTOs;
using Microsoft.AspNetCore.Mvc;
using ServerSideForProj4.ECs;

namespace ServerSideForProj4.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InstructorController : ControllerBase
    {
        private readonly ILogger<InstructorController> _logger;

        public InstructorController(ILogger<InstructorController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetInstructor")]
        public List<Person> GetInstructor()
        {
            return FakeDatabase.People;
        }

        [HttpPost(Name = "AddOrUpdateInstructor")]
        public InstructorDTO AddOrUpdateInstructor([FromBody] InstructorDTO person)
        {
            return new InstructorEC().AddOrUpdateInstructor(person);
        }

        [HttpDelete(Name = "DeleteInstructor")]
        public InstructorDTO DeleteInstructor([FromBody] InstructorDTO person)
        {
            return new InstructorEC().RemoveInstructor(person);
        }
    }
}
