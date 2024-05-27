using LMSLibrary2._0.DTO_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMSLibrary.Models{
    public class Person{
        public static int currentId = 0;
        public Person(){
            type = 0;
            Name = "";
            Id = 0;
            Classification = "";
            Classes = new List<ClassItem>();
            Semester = "Spring";
            Year = 2023;
        }

        public Person(PersonDTO dto)
        {
            type = dto.type;
            Name = dto.Name;
            Id = dto.Id;
            Classification = dto.Classification;
            Classes = dto.Classes;
            Semester = dto.Semester;
            Year = dto.Year;
        }

        public List<ClassItem> Classes { get; set; }
        public string Name { get; set; }
        public string  Classification{ get; set; }

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
