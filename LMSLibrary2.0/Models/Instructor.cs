using LMSLibrary2._0.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMSLibrary.Models{
    public class Instructor : Person{

        public Instructor()
        {
            type = 0;
            Name = "";
            Classification = "";
        }
        public Instructor(Person person) {
            type = 2;
            Id = person.Id;
            Name = person.Name;
            Classification = person.Classification;
        }

        public Instructor(InstructorDTO person)
        {
            type = 2;
            Id = person.Id;
            Name = person.Name;
            Classification = person.Classification;
        }
        // private string _classification;
        /*public new string Classification
         {
             get
             {
                 return _classification;
             }
             set
             {
                 if (value.ToLower().StartsWith("f"))
                 {
                     _classification = "Full-time";
                 }
                 else if (value.ToLower().StartsWith("a"))
                 {
                     _classification = "Adjunct";
                 }
                 else
                 {
                     _classification = value;
                 }
             }

         }*/

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
