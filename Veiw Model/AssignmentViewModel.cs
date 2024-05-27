using LMSLibrary;
using LMSLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_3___3.Veiw_Model
{
    public class AssignmentViewModel
    {
        public AssignmentViewModel(List<Assignment> assignments)
        {
            Assignment = new Assignment();
            Assignments = assignments;
        }

        public AssignmentViewModel(List<Assignment> assignments, String selected)
        {
            Assignment = new Assignment();
            for (int i = 0; i < assignments.Count(); i++)
            {
                if (selected.IndexOf(assignments[i].Name.ToString(), StringComparison.InvariantCultureIgnoreCase) >= 0)
                {
                    Assignment = assignments[i];
                }
            }
            Assignments = assignments;
        }

        public Assignment Assignment { get; set; }
        public List<Assignment> Assignments;

        public String Name
        {
            get { return Assignment.Name; }
            set { Assignment.Name = value; }
        }

        public String Description
        {
            get { return Assignment.Description; }
            set { Assignment.Description = value; }
        }

        public int TotalAvailablePoints
        {
            get { return Assignment.TotalAvailablePoints; }
            set { Assignment.TotalAvailablePoints = value; }
        }

        public String DueDate
        {
            get { return Assignment.DueDate.ToString(); }
            set { Assignment.DueDate = DateTime.Parse(value); }
        }

        public void AddAssignment()
        {
            Assignments.Add(Assignment);
        }

        public void ModifyAssignment()
        {

        }

        public void RemoveAssignment()
        {
            Assignments.Remove(Assignment);
        }
    }
}
