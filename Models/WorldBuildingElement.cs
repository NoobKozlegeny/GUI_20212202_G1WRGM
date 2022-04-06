using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class WorldBuildingElement
    {
        public string Name { get; set; }
        public Uri PathToImg { get; set; }
        public Point Position { get; set; }
        // Pk for EF
        public int Id { get; set; }
        // Fk + Navigation prop for EF
        public int? MapLevel { get; set; }
        public virtual Map Map { get; set; }
    }
}
