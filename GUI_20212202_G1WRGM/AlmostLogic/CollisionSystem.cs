using GUI_20212202_G1WRGM.Renderer;
using Microsoft.Toolkit.Mvvm.DependencyInjection;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace GUI_20212202_G1WRGM.AlmostLogic
{
    class CollisionSystem
    {
        public static ICollection<Rect> worldBuildings { get; set; } = Ioc.Default.GetService<WorldBuildingElementDisplay>().WorldBuildingElementGeometries;
       
        // something is fucked up here, afeter 1 collision something stuck 
        public static bool CollideForward(Rect player)
        {
            Rect forwardCollisionSpace = new Rect(player.Right, player.Y - 10, 3, player.Height-20);
            return worldBuildings.Any(worldElement => worldElement.IntersectsWith(forwardCollisionSpace));
        }
        public static bool CollideBackward()
        {
            return false;
        }
        public static bool CollideUpway(Rect player)
        {
            return worldBuildings.Any(worldElement => worldElement.IntersectsWith(player));
        }
        public static bool CollideDownway()
        {
            return false;
        }



    }
}
