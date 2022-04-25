using GUI_20212202_G1WRGM.Controller;
using GUI_20212202_G1WRGM.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace GUI_20212202_G1WRGM.Renderer.Interfaces
{
    public interface IGameControlDisplay
    {
        public IGameModel Model { get;}
        public Drawing Build();
    }
}
