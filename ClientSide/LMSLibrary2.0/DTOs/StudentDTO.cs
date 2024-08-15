using LMSLibrary.Models;
using LMSLibrary2._0.DTO_s;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace LMSLibrary2._0.DTOs
{
    public class StudentDTO : PersonDTO
    {
        public StudentDTO()
        {
            type = 1;
            Id = 0;
            Name = "";
            Classification = "";
            Grade = 0;
            Classes = new List<ClassItem>();
        }
        public StudentDTO(Person person)
        {
            type = 1;
            Id = person.Id;
            Name = person.Name;
            Classification = person.Classification;
            Grade = 0;
            Classes = new List<ClassItem>();
        }

        public double Grade { get; set; }

        public override string FullDisplay()
        {
            string display = $"Student:\t\t{Name} - {Classification}   ID: {Id}\n\tGPA: {Grade}\n";
            for (int i = 0; i < Classes.Count; i++)
            {
                display += "\tGrade: " + Classes[i].CourseGrade + " \t" + Classes[i] + "\n";
            }
            return display;
        }
        public override string ToString()
        {
            return $"Student:\t{Name} - {Classification}   ID: {Id}";
        }
    }
}
