using LMSLibrary.Models;
using LMSLibrary2._0.DTOs;
using Microsoft.AspNetCore.Mvc;
using ServerSideForProj4.ECs;

namespace ServerSideForProj4.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TeacherAssistantController : ControllerBase
    {
        private readonly ILogger<TeacherAssistantController> _logger;

        public TeacherAssistantController(ILogger<TeacherAssistantController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetTeacherAssistant")]
        public List<Person> GetTeacherAssistant()
        {
            return FakeDatabase.People;
        }

        [HttpPost(Name = "AddOrUpdateTeacherAssistant")]
        public TeacherAssistantDTO AddOrUpdateTeacherAssistant([FromBody] TeacherAssistantDTO person)
        {
            return new TeacherAssistantEC().AddOrUpdateTeacherAssistant(person);
        }

        [HttpDelete(Name = "DeleteTeacherAssistant")]
        public TeacherAssistantDTO DeleteTeacherAssistant([FromBody] TeacherAssistantDTO person)
        {
            return new TeacherAssistantEC().RemoveTeacherAssistant(person);
        }
    }
}
