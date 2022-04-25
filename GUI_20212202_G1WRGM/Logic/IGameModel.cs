using Models;
using Models.SystemComponents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace GUI_20212202_G1WRGM.Logic
{
    public interface IGameModel
    {
        public DispatcherTimer Time { get; }

        public List<Item> Items { get; set; }

        public List<Bullet> Bullets { get; set; }

        public Player Player { get; set; }

        public List<NPC> Enemies { get; set; }
    }
}
