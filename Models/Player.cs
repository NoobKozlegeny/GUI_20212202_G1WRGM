using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Player : Character
    {
        private static int ROLLINGTIME = 250;
        private int rollingCounter = 0;
        private bool isroll = false;

        public bool IsInvincibly { get; set; }
        public virtual Inventory Inventory { get; set; }
        //public Item SelectedItem { get => Inventory.SelectedItem; }
        public bool WillShoot { get; set; } = false;
        public bool isRolling(int deltatime)
        {
            
            if (!this.isroll && ROLLINGTIME > this.rollingCounter)
                return false;
            this.rollingCounter += deltatime;
            if (ROLLINGTIME <= this.rollingCounter)
            {
                return false;
            }
            return true;
        }

        public bool DoRoll()
        {
            if (IsGrounded)
            {
                this.isroll = true;
            }
            return isroll;
        }

        public void RollOver()
        {
            this.isroll = false;
            this.rollingCounter = 0;
        }
    }
}
