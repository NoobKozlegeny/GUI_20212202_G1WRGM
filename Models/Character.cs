using System;
using System.Drawing;

namespace Models
{
    public class Character
    {
        public string Name { get; set; }
        public int HealthPoints { get; set; }
        public int Armour { get; set; }
        public int Speed { get; set; }
        public Size Size { get; set; }
        public Point Position { get; set; }

        // Pk for EF
        public int Id { get; set; }
        // Fk + Navigation prop for EF
        public int MapLevel { get; set; }
        public virtual Map Map { get; set; }
    }
}
