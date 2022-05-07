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
        public int? SelectedItemId { get; set; }
        public virtual Item SelectedItem 
        { 
            get 
            {
                return Items.Where(x => x.Id == SelectedItemId).First();
            }
            set
            {

            }
        }
        public Uri PathToSelectedItemImg { get; set; }


        public int Id { get; set; }
        public virtual ICollection<Item> Items { get; set; }
        public int? PlayerId { get; set; }
        public virtual Player Player { get; set; }

        public Inventory()
        {
            Items = new HashSet<Item>();
        }
    }
}
