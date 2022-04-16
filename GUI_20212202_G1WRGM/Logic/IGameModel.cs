using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI_20212202_G1WRGM.Logic
{
    public interface IGameModel
    {
        public List<Item> StaticObject { get; set; }

        public List<Item> MovingObject { get; set; }

        public Character Player { get; set; }

        public List<Character> Enemies { get; set; }
    }
}
