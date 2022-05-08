using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Player : Character
    {

        public bool IsInvincibly { get; set; }
        public virtual Inventory Inventory { get; set; }
        //public Item SelectedItem { get => Inventory.SelectedItem; }

        
    }
}
