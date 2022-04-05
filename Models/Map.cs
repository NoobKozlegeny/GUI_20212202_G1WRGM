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
        public int Level { get; set; }
        public Size Size { get; set; }
        public ICollection<Character> Characters { get; set; }
        public ICollection<Item> Items { get; set; }
        public ICollection<WorldBuildingElements> WorldElements { get; set; }

        public Map()
        {
            Characters = new List<Character>();
            Items = new List<Item>();
            WorldElements = new List<WorldBuildingElements>();
        }

    }
}
