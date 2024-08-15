using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMSLibrary.Models
{
    public class AssignmentGroup
    {
        public AssignmentGroup(){
            Name = "";
            AssignmentList = new List<Assignment>();
            Weight = 0;
        }
        public String Name { get; set; }
        public List<Assignment> AssignmentList { get; set; }
        public double Weight { get; set; }

        public int GroupNum { get; set; }

        public string FullDisplay()
        {
            String display = $"{Name} - {Weight}%\n\t";
            for(int i = 0; i < AssignmentList.Count; i++)
            {
                display += AssignmentList[i];
            }
            return display;
        }

        public override string ToString()
        {
            return $"{Name} - {Weight}%";
        }

    }
}
