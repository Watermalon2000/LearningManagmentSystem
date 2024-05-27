using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMSLibrary.Models
{
    public class Announcement
    {
        public Announcement()
        {
            Name = "";
            Content = "";
        }
        public string Name { get; set; }
        public string Content { get; set; }

        public override string ToString()
        {
            return $"{Name}\n\t{Content}";
        }
    }
}
