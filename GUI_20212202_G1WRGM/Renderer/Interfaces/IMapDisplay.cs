using Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI_20212202_G1WRGM.Renderer.Interfaces
{
    interface IMapDisplay
    {
        //Map map { get; set; }
        void Resize(Size size);
        void SetupMap(IList<Map> map);
    }
}
