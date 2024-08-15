using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMSLibrary{
    public class Assignment{
        public Assignment() {
            Name = "";
            Description = "";
            TotalAvailablePoints = 0;
            DueDate = DateTime.Now;
        }
        public string Name { get; set; }
        public string Description { get; set; }
        public int TotalAvailablePoints { get; set; }
        public DateTime DueDate { get; set; }

        public string FullDisplay()
        {
            return $"{Name} - {Description}\n\t  {DueDate}\n\t  {TotalAvailablePoints}";
        }

        public override string ToString(){
            return $"{Name} - {Description}\n\t  {DueDate}\n\t  {TotalAvailablePoints}";
            //return $"{Name} - {Description}";
        }
    }
}
