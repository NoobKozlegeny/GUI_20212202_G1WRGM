using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Map
    {
        public Uri PathToImg { get; set; }
        public Size Size { get; set; }
        // Pk for EF 
        public int Level { get; set; }
        // Navigation props for EF
        public virtual ICollection<Character> Characters { get; set; }
        public virtual ICollection<Item> Items { get; set; }
        public virtual ICollection<WorldBuildingElement> WorldElements { get; set; }

        public Map()
        {
            Characters = new List<Character>();
            Items = new List<Item>();
            WorldElements = new List<WorldBuildingElement>();
        }

    }
}
