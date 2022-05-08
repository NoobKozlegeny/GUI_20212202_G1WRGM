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
        public static ICollection<Rect> worldBuildings { get; set; }
        static CollisionSystem()
        {
            worldBuildings = Ioc.Default.GetService<WorldBuildingElementDisplay>().WorldBuildingElementGeometries;

        }
        // fixed, should work as intended, fucking bool prop messed up in logic task 
        public static bool CollideForward(Rect player)
        {
            var x = player.Right;
            var y = player.Y-15;
            var height = player.Height - 30;

            Rect forwardCollisionSpace = new Rect(x, y, 3, height);
            return worldBuildings.Any(worldElement => worldElement.IntersectsWith(forwardCollisionSpace));
        }
        public static bool CollideBackward(Rect player)
        {
            var x = player.Left;
            var y = player.Y-15;
            var height = player.Height - 30;

            Rect backwardCollisionSpace = new Rect(x,y,3,height);
            return worldBuildings.Any(worldElement => worldElement.IntersectsWith(backwardCollisionSpace));
        }
        public static bool CollideUpway(Rect player)
        {
            var x = player.X - 10;
            var y = player.Y;
            var width = player.Width - 20;

            Rect upwayCollisionSpace = new Rect(x,y,width,3);
            return worldBuildings.Any(worldElement => worldElement.IntersectsWith(upwayCollisionSpace));
        }
        public static bool CollideDownway(Rect player)
        {
            var x = player.Left + 10;
            var y = player.Bottom;
            var width = player.Width - 20;

            Rect downwayCollisionSpace = new Rect(x,y,width,3);
            return worldBuildings.Any(worldElement => worldElement.IntersectsWith(downwayCollisionSpace));
        }



    }
}
