using LMSLibrary.Models;
using LMSLibrary2._0.DTO_s;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace LMSLibrary2._0.DTOs
{
    public class InstructorDTO : PersonDTO
    {
        public InstructorDTO()
        {
            type = 2;
            Id = 0;
            Name = "";
            Classification = "";
        }
        public InstructorDTO(Person person)
        {
            type = 2;
            Id = person.Id;
            Name = person.Name;
            Classification = person.Classification;
        }

        public override string FullDisplay()
        {
            string display = $"Instructor:\t{Name} - {Classification}   ID: {Id}\n";
            for (int i = 0; i < Classes.Count; i++)
            {
                display += "\t" + Classes[i] + "\n";
            }
            return display;
        }

        public override string ToString()
        {
            return $"Instructor:\t{Name} - {Classification}   ID: {Id}";
        }
    }
}
