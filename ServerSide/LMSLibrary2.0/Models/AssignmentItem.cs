using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMSLibrary.Models
{
    public class AssignmentItem : ContentItem{

        public AssignmentItem(ContentItem contentItem)
        {
            Name = contentItem.Name;
            Description = contentItem.Description;
            assignment = new Assignment();
        }

        public AssignmentItem()
        {
            assignment = new Assignment();
        }
        public Assignment assignment { get; set; }

        public int group { get; set; }

        public override string ToString()
        {
            return $"{Name}\n\t{ Description}\n\t{assignment}";
        }
    }
}
