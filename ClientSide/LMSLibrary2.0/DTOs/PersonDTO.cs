using LMSLibrary.Models;
using System;
using System.Collections.Generic;

namespace LMSLibrary2._0.DTO_s
{
    public class PersonDTO
    {
        public static int currentId = 0;
        public PersonDTO()
        {
            type = 0;
            Name = "";
            Id = 0;
            Classification = "";
            Classes = new List<ClassItem>();
            Semester = "Spring";
            Year = 2023;
        }

        public PersonDTO(Person person)
        {
            type = person.type;
            Name = person.Name;
            Id = person.Id;
            Classification = person.Classification;
            Classes = person.Classes;
            Semester = person.Semester;
            Year = person.Year;
        }

        public List<ClassItem> Classes { get; set; }
        public string Name { get; set; }
        public string Classification { get; set; }

        public String Semester { get; set; }
        public int type { get; set; }

        public int Year { get; set; }

        private int _id;
        public int Id
        {
            get
            {
                return _id;
            }
            set { _id = value; }
        }

        public virtual string FullDisplay()
        {
            string display = $"{Name} - {Classification}   ID: {Id}\n";
            display += "\tClasses\n";
            for (int i = 0; i < Classes.Count; i++)
            {
                display += "\t  " + Classes[i] + "\n";
            }
            return display;
        }

        public override string ToString()
        {
            return $"{Name} - {Classification}   ID: {Id}";
        }
    }
}

