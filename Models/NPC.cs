using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class NPC : Character
    {
        // Holisit i forgot about this one, how to map this since TPH will store this in parent entity but it has other connections
        // Maybe map it to parent and tell EF TPH stays and it will work?? bumm magic...
        public virtual Weapon FireArm { get; set; }
    }
}
