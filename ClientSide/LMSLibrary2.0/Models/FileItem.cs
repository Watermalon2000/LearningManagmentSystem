using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMSLibrary.Models{
    public class FileItem : ContentItem{

        public FileItem(ContentItem contentItem)
        {
            Name = contentItem.Name;
            Description = contentItem.Description;
            FilePath = "";
        }
        public FileItem(){
            FilePath = "";
        }
        public string FilePath { get; set; }

        public override string ToString()
        {
            return $"{ Name}\n\t{ Description}\n\t{FilePath}";
        }
    }
}
