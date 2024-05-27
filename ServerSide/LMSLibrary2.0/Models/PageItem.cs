using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMSLibrary.Models{
    public class PageItem : ContentItem{
        public PageItem(ContentItem contentItem)
        {
            Name = contentItem.Name;
            Description = contentItem.Description;
            HTMLBody = "";
        }
        public PageItem(){
            HTMLBody = "";
        }
       public string HTMLBody { get; set; }

        public override string ToString()
        {
            return $"{Name}\n\t{ Description}\n\t{HTMLBody}";
        }
    }
}
