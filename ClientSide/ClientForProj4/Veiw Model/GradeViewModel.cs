using LMSLibrary;
using LMSLibrary.Models;
using Project_3___3.Dialogs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;
using Windows.ApplicationModel.UserActivities.Core;
using Windows.Devices.PointOfService;
using Windows.Globalization.PhoneNumberFormatting;
using Windows.UI.Xaml.Controls.Primitives;

namespace Project_3___3.Veiw_Model
{
    public class GradeViewModel
    {
        public GradeViewModel(Course course, ObservableCollection<Student> students, AssignmentGroup assignmentGroup, String selected)
        {
            foreach(var currentAssign in assignmentGroup.AssignmentList)
            {
                if (selected.IndexOf(currentAssign.Name.ToString(), StringComparison.InvariantCultureIgnoreCase) >= 0)
                {
                    Assignment = currentAssign;
                }
            }
            AssignmentGroup = assignmentGroup;
            Students = students;
            Course = course;
        }

        public int Points { get; set; }

        public String Search { get; set; }

        public ObservableCollection<Student> Students { get; set; }

        public Assignment Assignment { get; set;}


        public Course Course { get; set; }

        public AssignmentGroup AssignmentGroup { get; set; }

        public void AssignGrade(String selected)
        {
            foreach (var student in Students)
            {
                if (selected.IndexOf(student.Id.ToString(), StringComparison.InvariantCultureIgnoreCase) >= 0)
                {
                    foreach (var classItem in student.Classes)
                    {
                        if (Course.Name.IndexOf(classItem.CourseName.ToString(), StringComparison.InvariantCultureIgnoreCase) >= 0)
                        {
                            GradeItem gi = new GradeItem();
                            gi.Weight = AssignmentGroup.Weight;
                            gi.Points = Points;
                            gi.PossiblePoints = Assignment.TotalAvailablePoints;
                            gi.ClassCode = Course.Code;
                            gi.AssignName = Assignment.Name;
                            gi.AssignGroup = AssignmentGroup.GroupNum;
                            gi.NumGroups = Course.AssignmentGroups.Count;
                            classItem.AssignmentGrades.Add(gi);
                            double grandTotal = 0;
                            for(int i = 0; i < classItem.AssignmentGrades[classItem.AssignmentGrades.Count - 1].NumGroups; i++) {
                                double groupTotal = 0;
                                double weight = 0;
                                int num = 0;
                                foreach (var assignmentGrade in classItem.AssignmentGrades)
                                {
                                    if (assignmentGrade.AssignGroup == i)
                                    {
                                        weight = assignmentGrade.Weight;
                                        groupTotal += (assignmentGrade.Points / assignmentGrade.PossiblePoints);
                                        num++;
                                    }
                                }
                                if (num != 0)
                                {
                                    grandTotal += (groupTotal / num) * weight;
                                }
                            }
                            classItem.CourseGrade = grandTotal;
                        }
                    }
                }
            }

        }

        public void SearchStudents()
        {

            for (int i = 0; i < Students.Count(); i++)
            {
                if (Search == null)
                {

                }
                else if (Students[i].Name.IndexOf(Search, StringComparison.InvariantCultureIgnoreCase) >= 0 ||
                    Students[i].Classification.IndexOf(Search, StringComparison.InvariantCultureIgnoreCase) >= 0)
                {

                }
                else
                {
                    Students.Remove(Students[i]);
                    i--;
                }
            }
        }
    }
}
