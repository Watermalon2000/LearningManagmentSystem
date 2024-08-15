using LMSLibrary;
using LMSLibrary.Models;
using System.Collections.Generic;

namespace LMSLibrary2._0.DTO_s
{
    public class CourseDTO
    {
        public CourseDTO(Course course)
        {
            Id = course.Id;
            Name = course.Name;
            Code = course.Code;
            Description = course.Description;
            CreditHours = course.CreditHours;
            Semester = course.Semester;
            Year = course.Year;
            Room = course.Room;
            Roster = course.Roster;
            AssignmentGroups = course.AssignmentGroups;
            Modules = course.Modules;
            Announcements = course.Announcements;
        }
        public CourseDTO()
        {
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

        public readonly string[] groupNames = { "Homework", "Discussion", "Quiz", "Tests", "In-Class", "Attendence" };
        public string FullDisplay()
        {
            return $"{Code} - {Name}\n\tCredit Hours: {CreditHours}\n\t{Description}\n\tRoom {Room} - Semester {Semester} {Year}";
        }

        public override string ToString()
        {
            return $"{Code} - {Name}";
        }

    }
}
