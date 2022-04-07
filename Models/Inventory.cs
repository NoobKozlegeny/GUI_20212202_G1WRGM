using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Inventory
    {
        public int SlotNumber { get; set; }
        public Item SelectedItem { get; set; }


        public int Id { get; set; }
        public virtual ICollection<Item> Items { get; set; }
        public int? PlayerId { get; set; }
        public virtual Player Player { get; set; }
    }
}
