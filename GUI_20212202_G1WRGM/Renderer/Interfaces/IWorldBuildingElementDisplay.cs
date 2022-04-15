using Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI_20212202_G1WRGM.Renderer.Interfaces
{
    interface IWorldBuildingElementDisplay
    {
        IList<WorldBuildingElement> WorldBuildingElements { get; set; }
        Size size { get; set; }
        void Resize(Size size);
        void SetupWorldBuildingElements(IList<WorldBuildingElement> worldBuildingElements);
    }
}
