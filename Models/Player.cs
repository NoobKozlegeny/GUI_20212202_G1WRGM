using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Player : Character
    {
        
        public virtual Inventory Inventory { get; set; }
    }
}
