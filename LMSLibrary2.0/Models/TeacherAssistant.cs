using LMSLibrary2._0.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMSLibrary.Models
{
    public class TeacherAssistant : Person{

        public TeacherAssistant()
        {
            type = 3;
            Name = "";
            Classification = "";
        }
        public TeacherAssistant(Person person)
        {
            type = 3;
            Id = person.Id;
            Name = person.Name;
            Classification = person.Classification;
        }

        public TeacherAssistant(TeacherAssistantDTO person)
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
