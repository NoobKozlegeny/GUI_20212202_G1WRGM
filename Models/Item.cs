using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Item
    {
       
        public string Name { get; set; }
        public Point Position { get; set; }
        // Pk for EF
        public int Id { get; set; }
        // Fk + NavProp for EF
        public int? MapLevel { get; set; }
        public virtual Map Map { get; set; }
        public int? InventoryId { get; set; }
        public virtual Inventory Inventory { get; set; }
        public Uri PathToImg { get; set; }
        public bool IsPickedUp { get; set; }
        public Size Size { get; set; }
        public Point DirectionToLook { get; set; }
    }
}
