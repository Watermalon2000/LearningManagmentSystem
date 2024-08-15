using LMSLibrary.Models;
using LMSLibrary2._0.DTO_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMSLibrary{
    public class Course{
        public Course(){
            Id = 0;
            Name = "";
            Code = "";
            Description = "";
            CreditHours = 3;
            Semester = "Fall";
            Year = 2023;
            Room = "";
            Roster = new List<Person>();
            AssignmentGroups = new List<AssignmentGroup>();
            Modules = new List<Module>();
            Announcements = new List<Announcement>();
        }
        public Course(CourseDTO dto)
        {
            Id = dto.Id;
            Name = dto.Name;
            Code = dto.Code;
            Description = dto.Description;
            CreditHours = dto.CreditHours;
            Semester = dto.Semester;
            Year = dto.Year;
            Room = dto.Room;
            Roster = dto.Roster;
            AssignmentGroups = dto.AssignmentGroups;
            Modules = dto.Modules;
            Announcements = dto.Announcements;
        }
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Person> Roster { get; set; }
        public List<AssignmentGroup> AssignmentGroups { get; set; }
        public List<Module> Modules { get; set; }
        public List<Announcement> Announcements { get; set; }
        public double CreditHours { get; set; }

        public string Semester { get; set; }

        public int Year { get; set; }

        public string Room { get; set; }

        public readonly string[] groupNames = {"Homework", "Discussion", "Quiz", "Tests", "In-Class", "Attendence" };
        public string FullDisplay(){
            return $"{Code} - {Name}\n\tCredit Hours: {CreditHours}\n\t{Description}\n\tRoom {Room} - Semester {Semester} {Year}";
        }

        public override string ToString()
        {
            return $"{Code} - {Name}";
        }
    }
}
