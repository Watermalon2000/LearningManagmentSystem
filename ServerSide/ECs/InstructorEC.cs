using LMSLibrary;
using LMSLibrary.Models;
using LMSLibrary2._0.DTOs;

namespace ServerSideForProj4.ECs
{
    public class InstructorEC : PersonEC
    {
        public InstructorDTO AddOrUpdateInstructor(InstructorDTO dto)
        {
            if (dto.Id > 0)
            {
                var itemToUpdate = FakeDatabase.People.FirstOrDefault(c => c.Id == dto.Id);

                if (itemToUpdate != null)
                {
                    FakeDatabase.People.Remove(itemToUpdate);
                    FakeDatabase.People.Add(new Instructor(dto));
                }

            }
            else
            {
                var lastId = FakeDatabase.Courses.Select(c => c.Key).Max();
                dto.Id = ++currentId;
                FakeDatabase.People.Add(new Instructor(dto));
            }


            return dto;
        }

        public InstructorDTO RemoveInstructor(InstructorDTO dto)
        {

            if (dto.Id > 0)
            {
                var itemToUpdate = FakeDatabase.People.FirstOrDefault(c => c.Id == dto.Id);

                if (itemToUpdate != null)
                {
                    FakeDatabase.People.Remove(itemToUpdate);
                }

            }
            return dto;
        }
    }
}
