using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMSLibrary{
    public class Module{
        public Module() {
            Name = "";
            Description = "";
            Content = new List<ContentItem>();
        }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<ContentItem> Content { get; set; }

        public string FullDisplay()
        {
            String display = $"{Name}\n{Description}\n";
            for (int i = 0; i < Content.Count; i++)
            {
                display += "  " + Content[i] + "\n";
            }
            return display;
        }
        public override string ToString()
        {
            return $"{Name}\n\t{Description}";
        }
    }
}
