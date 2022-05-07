using GUI_20212202_G1WRGM.Renderer;
using Microsoft.Toolkit.Mvvm.DependencyInjection;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace GUI_20212202_G1WRGM.AlmostLogic
{
    class CollisionSystem
    {
        public ICollection<WorldBuildingElement> worldBuildings { get; set; } = Ioc.Default.GetService<WorldBuildingElementDisplay>().WorldBuildingElements;
        // How to get the dynamically changing player object here to check collision?
        // get it from cDisplay and then always redraw through points from logic?
        // do it in logic and here only get the result geometry to check? 


        // 200 iq tactic 
        // in display before render contruct all geomertry stuff
        // and then use it only in render (i.e. for player it can be even stored by IoC singletone or just referenc the collection in display)
        // if logic, collision and everything else can acces constructed object before render then without useless calls and memory waste we can alter
        // (if we acces the constructed geometry position, center, etc)
        // Holisit this can work and even spare useless geometry construct time in every tick ???
        public bool CollideForward(DrawingGroup player)
        {
            return false;
        }
        public bool CollideBackward()
        {
            return false;
        }
        public bool CollideUpway()
        {
            return false;
        }
        public bool CollideDownway()
        {
            return false;
        }



    }
}
