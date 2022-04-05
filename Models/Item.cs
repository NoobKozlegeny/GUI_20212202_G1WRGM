using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Point Position { get; set; }

        public int MapLevel { get; set; }
        public virtual Map Map { get; set; }
    }
}
