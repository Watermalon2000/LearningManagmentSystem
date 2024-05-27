using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMSLibrary.Models
{
    public class ClassItem
    {
        public ClassItem() {
            CourseCode = "";
            CourseName = "";
            CourseGrade = 0;
            CoursePosition = 0;
            CreditHours = 0;
            Semester = "Fall";
            Year = 2023;
            Room = "";
            AssignmentGrades = new List<GradeItem>();
        }
        public String CourseCode { get; set; }
        public String CourseName { get; set; }
        public double CourseGrade { get; set; }
        
        public int CoursePosition { get; set; }

        public double CreditHours { get; set; }

        public string Semester { get; set; }

        public int Year { get; set; }

        public string Room { get; set; }

        public List<GradeItem> AssignmentGrades { get; set; }


        public override String ToString(){
            String display = $"{CourseCode} - {CourseName}\tCredit Hours: {CreditHours}\n";
            display += $"\tRoom {Room}\tSesmester {Semester} {Year}";
            for (int x = 0; x < AssignmentGrades.Count; x++)
            {
                display += "\t\t" + (AssignmentGrades[x]) + "\n";
            }
            return display;
        }
    }
}
