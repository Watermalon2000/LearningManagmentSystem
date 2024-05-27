using LMSLibrary;
using Microsoft.AspNetCore.Mvc;
using LMSLibrary2._0.DTO_s;

namespace ServerSideForProj4.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CourseController : ControllerBase
    {

        private readonly ILogger<CourseController> _logger;

        public CourseController(ILogger<CourseController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetCourse")]
        public Dictionary<String, Course> Get()
        {
            return FakeDatabase.Courses;
        }

        [HttpPost(Name = "AddOrUpdateCourse")]
        public CourseDTO AddOrUpdateCourse([FromBody] CourseDTO course)
        {
            return new CourseEC().AddOrUpdateCourse(course);
        }

        [HttpDelete(Name = "DeleteCourse")]
        public CourseDTO DeleteCourse([FromBody] CourseDTO course)
        {
            return new CourseEC().RemoveCourse(course);
        }
    }
}