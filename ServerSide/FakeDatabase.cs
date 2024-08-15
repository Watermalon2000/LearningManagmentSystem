using LMSLibrary;
using LMSLibrary.Models;
using System.Security.Cryptography.X509Certificates;

namespace ServerSideForProj4
{
    public static class FakeDatabase{

        public static Dictionary<String, Course> Courses = new Dictionary<string, Course>
        { {
                "COP2220",
                new Course{ Id = 1, Name = "Into to C++", Code = "COP2220", Description = "Coding is the best", Room = "HCB208", Semester = "Fall", Year = 2023,
                    AssignmentGroups = new List<AssignmentGroup> { new AssignmentGroup { Name = "Quizes", Weight = 25, GroupNum = 0} ,
                    new AssignmentGroup { Name = "Tests", Weight = 25, GroupNum = 1} ,  new AssignmentGroup { Name = "Homework", Weight = 50, GroupNum = 2} },
                    Modules = {new  Module { Name = "Introduction", Description = "You can get to know me"} }
                } },
            {   
                "CHM1045",
                new Course{ Id = 2, Name = "Chemistry", Code = "CHM1045", Description = "Chemicals and things", Room = "HCB219", Year=2023}
            }
        };

        public static List<Person> People = new List<Person>
        { 
                new Student{ Id = 1, type = 1, Name = "Benjamin Payne", Classification = "Junior"} ,

                new Instructor{ Id = 2, type = 2, Name = "Billy Bob", Classification = "Full"} ,

               new TeacherAssistant{ Id = 3, type = 3, Name = "Fredrick", Classification = "Graduate"}
        };
    }
}
