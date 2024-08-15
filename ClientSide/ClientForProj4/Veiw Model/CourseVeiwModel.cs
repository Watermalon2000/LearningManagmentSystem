using LMSLibrary;
using LMSLibrary.Models;
using Newtonsoft.Json;
using SupportTicketApplication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Windows.Graphics.Printing3D;

namespace Project_3___3.Veiw_Model
{
    public class CourseVeiwModel
    {
        public CourseVeiwModel(Dictionary<String, Course> courses) {
            Course = new Course();
            Courses = courses;
        }

        public CourseVeiwModel(Dictionary<String, Course> courses, string selected)
        {
            Courses = courses;
            foreach (var course in Courses)
            {
                if (selected.IndexOf(course.Key, StringComparison.InvariantCultureIgnoreCase) >= 0)
                {
                    Course = Courses[course.Key];
                }
            }
        }

        public Course Course
        {
            get; set;
        }

        private Dictionary<String, Course> Courses;

        public String Code{
            get { return Course.Code; }
            set{ Course.Code = value; }
        }

        public String Name
        {
            get
            {
                return Course.Name;
            }
             set {
            
                Course.Name = value;
            }

        }

        public double CreditHours
        {
            get
            {
                return Course.CreditHours;
            }
            set
            {

                Course.CreditHours = value;
            }

        }

        public String Description
        {
            get
            {
                return Course.Description;
            }
            set
            {

                Course.Description = value;
            }

        }

        public String Room
        {
            get { return Course.Room; }
            set { Course.Room = value; }
        }

        public String Semester
        {
            get { return Course.Semester; }
            set { Course.Semester = value; }
        }


        public int Year
        {
            get { return Course.Year; }
            set { Course.Year = value; }
        }

        public void AddCourse()
        {
            var response = new WebRequestHandler().Post("http://localhost:5291/Course", Course);
            var obj = JsonConvert.DeserializeObject<Course>(response.Result);
            Course.Id = obj.Id;
            Courses.Add(Course.Code, Course);
        }

        public void ModifyCourse()
        {
            var respose = new WebRequestHandler().Post("http://localhost:5291/Course", Course);
        }

        public void RemoveCourse()
        {
            Courses.Remove(Course.Code);
            var respose = new WebRequestHandler().Delete("http://localhost:5291/Course", Course);
        }

        public Course SelectCourse()
        {
            return Course;
        }
    }
}
