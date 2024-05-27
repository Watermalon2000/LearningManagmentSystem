using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMSLibrary.Models
{
    public class GradeItem {
        public GradeItem()
        {
            Weight = 0;
            Points = 0;
            ClassCode = "";
        }
        public double Weight { get; set; }
        public double Points { get; set; }
        public double PossiblePoints { get; set; }
        public String ClassCode { get; set; }
        public String AssignName { get; set; }
        public int AssignGroup { get; set; }
        public int NumGroups {get; set;}

        public string FullDisplay()
        {
            return $"{AssignName} - Grade {Points}/{PossiblePoints}\t{Points / PossiblePoints * 100}%\n{ClassCode}\t{AssignGroup}";
        }

        public override string ToString()
        {
            return $"{AssignName} - Grade {Points}/{PossiblePoints}\t{Points/PossiblePoints*100}%";
        }
    }
}
