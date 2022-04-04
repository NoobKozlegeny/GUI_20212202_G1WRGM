using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public enum BuffType
    {
        Health,
        Damage,
        Ammo
    }
    public class Buff : Item
    {
        public BuffType Affected { get; set; }
        public TimeSpan? Duration { get; set; }
    }
}
