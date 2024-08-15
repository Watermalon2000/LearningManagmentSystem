using LMSLibrary.Models;
using LMSLibrary2._0.DTOs;
using System;
using System.Collections.Generic;

namespace LMSLibrary{
    public class Student : Person{

        public Student()
        {
            type = 1;
            Id = 0;
            Name = "";
            Classification = "";
            Grade = 0;
            Classes = new List<ClassItem>();
        }
        public Student(Person person){
            type = 1;
            Id = person.Id;
            Name = person.Name;
            Classification = person.Classification;
            Grade = 0;
            Classes = new List<ClassItem>();
        }

        public Student(StudentDTO person)
        {
            type = 1;
            Id = person.Id;
            Name = person.Name;
            Classification = person.Classification;
            Grade = 0;
            Classes = new List<ClassItem>();
        }

        //private string _classification;
        /*public new string Classification {
            get{
                return _classification;
            }
            set{
                if (value.ToLower().StartsWith("f"))
                {
                    _classification = "Freshmen";
                }
                else if (value.ToLower().StartsWith("s") && value.ToLower()[1] == 'o')
                {
                    _classification = "Softmore";
                }
                else if (value.ToLower().StartsWith("j"))
                {
                    _classification = "Junior";
                }
                else if (value.ToLower().StartsWith("s") && value.ToLower()[1] == 'e')
                {
                    _classification = "Senior";
                }
                else if (value.ToLower().StartsWith("g"))
                {
                    _classification = "Graduate";
                }
                else
                {
                    _classification = value;
                }
            }
             
        }*/

        public double Grade{ get; set; }
        public override string FullDisplay()
        {
            string display = $"Student:\t\t{Name} - {Classification}   ID: {Id}\n\tGPA: {Grade}\n";
            for(int i = 0; i < Classes.Count; i++)
            {
                display += "\tGrade: " + Classes[i].CourseGrade + " \t" + Classes[i] +  "\n";
            }
            return display;
        }
        public override string ToString() {
            return $"Student:\t{Name} - {Classification}   ID: {Id}";
        }
    }
}
