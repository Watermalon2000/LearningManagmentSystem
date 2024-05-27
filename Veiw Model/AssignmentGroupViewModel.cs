using LMSLibrary.Models;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_3___3.Veiw_Model
{
    public class AssignmentGroupViewModel
    {
        public AssignmentGroupViewModel(List<AssignmentGroup> assignmentGroups)
        {
            AssignmentGroup = new AssignmentGroup();
            AssignmentGroups = assignmentGroups;
        }

        public AssignmentGroupViewModel(List<AssignmentGroup> assignmentGroups, String selected)
        {
            AssignmentGroup = new AssignmentGroup();
            for (int i = 0; i < assignmentGroups.Count(); i++)
            {
                if (selected.IndexOf(assignmentGroups[i].Name.ToString(), StringComparison.InvariantCultureIgnoreCase) >= 0)
                {
                    AssignmentGroup = assignmentGroups[i];
                    GroupNum = i;
                }
            }
            AssignmentGroups = assignmentGroups;
        }

        public AssignmentGroup AssignmentGroup { get; set; }
        public List<AssignmentGroup> AssignmentGroups;

        public String Name
        {
            get { return AssignmentGroup.Name; }
            set { AssignmentGroup.Name = value; }
        }

        public double Weight
        {
            get { return AssignmentGroup.Weight; }
            set { AssignmentGroup.Weight = value; }
        }

        public int GroupNum
        {
            get { return AssignmentGroup.GroupNum; }
            set{ AssignmentGroup.GroupNum = value; }
        }

        public void AddAssignmentGroup()
        {
            GroupNum = AssignmentGroups.Count;
            AssignmentGroups.Add(AssignmentGroup);
        }

        public void ModifyAssignmentGroup()
        {

        }

        public void RemoveAssignmentGroup()
        {
            AssignmentGroups.Remove(AssignmentGroup);
        }

        public AssignmentGroup SelectAssignmentGroup()
        {
            return AssignmentGroup;
        }
    }
}
