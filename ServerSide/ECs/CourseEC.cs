using LMSLibrary;
using LMSLibrary2._0.DTO_s;

namespace ServerSideForProj4
{
    public class CourseEC
    {
        public static int currentId = FakeDatabase.Courses.Count;
        public CourseDTO AddOrUpdateCourse(CourseDTO dto)
        {
            if (dto.Id > 0)
            {
                var itemToUpdate = FakeDatabase.Courses.FirstOrDefault( c => c.Value.Id == dto.Id);

                if (itemToUpdate.Key != null)
                {
                    //var indexOfItem = FakeDatabase.Courses.IndexOf(itemToUpdate);
                    FakeDatabase.Courses.Remove(itemToUpdate.Key);
                    FakeDatabase.Courses.Add(dto.Code, new Course(dto));
                }

            }
            else
            {
                var lastId = FakeDatabase.Courses.Select(c => c.Key).Max();
                dto.Id = ++currentId;
                FakeDatabase.Courses.Add(dto.Code, new Course(dto));
            }


            return dto;
        }

        public CourseDTO RemoveCourse(CourseDTO dto)
        {

            if (dto.Id > 0)
            {
                var itemToUpdate = FakeDatabase.Courses.FirstOrDefault(c => c.Value.Id == dto.Id);

                if (itemToUpdate.Key != null)
                {
                    FakeDatabase.Courses.Remove(itemToUpdate.Key);
                }

            }
            return dto;
        }
    }
}
