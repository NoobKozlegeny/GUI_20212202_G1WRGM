using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Weapon : Item
    {
        public int Damage { get; set; }
        public TimeSpan FireRate { get; set; }
        public int AmmoAmount { get; set; }
    }
}
