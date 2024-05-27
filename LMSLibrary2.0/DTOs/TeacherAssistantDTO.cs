using LMSLibrary.Models;
using LMSLibrary2._0.DTO_s;

namespace LMSLibrary2._0.DTOs
{
    public class TeacherAssistantDTO : PersonDTO
    {
        public TeacherAssistantDTO()
        {
            type = 3;
            Id = 0;
            Name = "";
            Classification = "";
        }
        public TeacherAssistantDTO(Person person)
        {
            type = 3;
            Id = person.Id;
            Name = person.Name;
            Classification = person.Classification;
        }
        public override string FullDisplay()
        {
            string display = $"TA:\t\t{Name} - {Classification}   ID: {Id}\n";
            for (int i = 0; i < Classes.Count; i++)
            {
                display += "\t" + Classes[i] + "\n";
            }
            return display;
        }

        public override string ToString()
        {
            return $"TA:\t\t{Name} - {Classification}   ID: {Id}";
        }
    }
}
