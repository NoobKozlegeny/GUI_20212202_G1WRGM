using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Player : Character
    {
        // yeah... forgot these ones too, fix them later
        // this inventory needs to be exctracted into single model cause it's fucking up DB relations
        // also client should have some representation about inventory which requires thing like slots, slotsnumber etc
        public virtual ICollection<Item> Inventory { get; set; }
        public virtual Item SelectedItem { get; set; }
    }
}
