using Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI_20212202_G1WRGM.Renderer.Interfaces
{
    //A little bit of dependency, mehh lemme try it out tho
    public interface IItemDisplay
    {
        IList<Item> Items { get; set; }
        Size size { get; set; }
        ICharacterDisplay CharacterDisplay { get; set; }
        void Resize(Size size);
        void SetupItems(IList<Item> items, ICharacterDisplay characterDisplay);
    }
}
