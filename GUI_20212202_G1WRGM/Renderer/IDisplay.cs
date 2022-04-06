using Models;
using System.Drawing;

namespace GUI_20212202_G1WRGM.Renderer
{
    public interface IDisplay
    {
        Map map { get; set; }
        Size size { get; set; }

        void Resize(Size size);
        void SetupMap(Map map);
    }
}