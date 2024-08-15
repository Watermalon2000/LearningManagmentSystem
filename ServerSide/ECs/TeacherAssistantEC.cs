using LMSLibrary.Models;
using LMSLibrary2._0.DTOs;
using ServerSideForProj4.Controllers;

namespace ServerSideForProj4.ECs
{
    public class TeacherAssistantEC : PersonEC
    {
        public TeacherAssistantDTO AddOrUpdateTeacherAssistant(TeacherAssistantDTO dto)
        {
            if (dto.Id > 0)
            {
                var itemToUpdate = FakeDatabase.People.FirstOrDefault(c => c.Id == dto.Id);

                if (itemToUpdate != null)
                {
                    FakeDatabase.People.Remove(itemToUpdate);
                    FakeDatabase.People.Add(new TeacherAssistant(dto));
                }

            }
            else
            {
                var lastId = FakeDatabase.Courses.Select(c => c.Key).Max();
                dto.Id = ++currentId;
                FakeDatabase.People.Add(new TeacherAssistant(dto));
            }


            return dto;
        }

        public TeacherAssistantDTO RemoveTeacherAssistant(TeacherAssistantDTO dto)
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
